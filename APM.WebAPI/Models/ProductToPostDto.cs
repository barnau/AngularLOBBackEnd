using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APM.WebAPI.Models
{
    public class ProductToPostDto
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public List<string> Tags { get; set; }
        public string ImageUrl { get; set; }
    }
}