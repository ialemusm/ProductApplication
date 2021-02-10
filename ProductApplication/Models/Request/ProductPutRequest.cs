using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApplication.Models.Request
{
    public class ProductPutRequest
    {
        public int id { get; set; }
        public int condition { get; set; }
        public int status { get; set; }
    }
}
