using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cemetery.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public IFormFile ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
