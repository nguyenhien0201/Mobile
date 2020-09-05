using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Mvc;


namespace Mobile.Models
{
    public class Signal: BsonData.Document
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int State { get; set; }
    }
    
    public class Device: BsonData.Document
    {
        public string Name { get; set; }
        public string MAC { get; set; }
        
    }
}
