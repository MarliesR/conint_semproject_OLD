﻿using System;
using System.Net;
using System.IO;
using System.Text;



namespace conint_server
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://codingvision.net/c-simple-http-server
            //https://www.youtube.com/watch?v=tfhIJg79pwI&ab_channel=lifemichael
            Console.WriteLine("Hello World!");
            HttpListener server = new HttpListener();

            //prefixes required
            server.Prefixes.Add("http://localhost:1300/server/");
            server.Start();

            Console.WriteLine("Listening");
            while (true)
            {
                //server wartet auf request
                HttpListenerContext context = server.GetContext(); 

                //file machen und zu json convertieren
                StockFile data = new StockFile("../../../data/BTC-USD.csv");
                string Answer = data.getJsonFile();

                //Länge der antwort berechnen
                context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(Answer); 
                context.Response.StatusCode = (int)HttpStatusCode.OK;

                using(Stream stream = context.Response.OutputStream)
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        //antwort zurücksenden
                        writer.Write(Answer); 
                    }
                }
                Console.WriteLine("Answer sent");
            }

        }
    }
}