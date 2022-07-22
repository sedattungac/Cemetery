using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cemetery.Models
{
    public class ProductCategoryViewModel
    {
        public int ProductCategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}
