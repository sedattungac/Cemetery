﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cemetery.Entity.Entity
{
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
