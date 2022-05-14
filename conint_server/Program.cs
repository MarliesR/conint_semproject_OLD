using System;
using System.Net;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

namespace conint_server
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Server starting...");
            HttpListener server = new HttpListener();

            //prefixes required
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                server.Prefixes.Add("http://*:1300/server/");
            }
            else
            {
                server.Prefixes.Add("http://localhost:1300/server/");
            }
            
            server.Start();

            Console.WriteLine("Listening");
            while (true)
            {
                //server wartet auf request
                HttpListenerContext context = server.GetContext();

                //file machen und zu json convertieren
                StockFile data = new StockFile("../../../data/BTC-USD.csv");
                string Answer = data.getJsonFile();

                //string Answer = "hi";
                //Länge der antwort berechnen
                context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(Answer); 
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                context.Response.Headers.Add("Content-Type", "application/json");

                using (Stream stream = context.Response.OutputStream)
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
