using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cemetery.Entity.Entity
{
    public class Personal
    {
        [Key]
        public int PersonalId { get; set; }
        public string FullName { get; set; }
        public string Telephone { get; set; }
        public string ImageUrl { get; set; }
    }
}
