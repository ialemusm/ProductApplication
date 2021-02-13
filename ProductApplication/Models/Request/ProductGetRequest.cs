using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApplication.Models.Request
{
    public class ProductGetRequest
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public string? ProdCondition { get; set; }
        public int? ProdStatus { get; set; }
    }
}
