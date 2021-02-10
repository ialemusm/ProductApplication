using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApplication.Models.Request
{
    public class ProductPostRequest
    {
        public string name { get; set; }
        public int condition { get; set; }
    }
}
