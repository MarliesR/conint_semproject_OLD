using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text;



namespace conint_server
{
    public class StockFile
    {
        private string path;
        private string JsonFile;

        public StockFile(string filepath)
        {
            path = filepath;
            convertToJSON();
        }
 
        public void convertToJSON()
        {
            
            List<DataSet> csv = new();
            //liest CSV File aus, skippt erste Zeile (benennung der spalten), mach aus jeder Zeile ein DataSet Objekt und fügt es zur Liste hinzu
            csv = System.IO.File.ReadAllLines(path).Skip(1).Select( v=> DataSet.FromCSV(v)).ToList();  
            JsonFile = JsonConvert.SerializeObject(csv);
        }
         
        public string getJsonFile()
        {
            return JsonFile;
        }
    }
}
