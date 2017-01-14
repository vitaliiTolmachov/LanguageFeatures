using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace LanguageFeatures.Models
{
    public class Product
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int ProductId { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}