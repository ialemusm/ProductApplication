using System;
using System.Collections.Generic;

#nullable disable

namespace ProductApplication.Models
{
    public partial class Product
    {
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public int? ProdCondition { get; set; }
        public int? ProdStatus { get; set; }
    }
}
