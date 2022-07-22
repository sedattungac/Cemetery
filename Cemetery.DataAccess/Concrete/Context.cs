using Cemetery.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cemetery.DataAccess.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=AKSLT047; database=DbCemetery;integrated security=true");
            //optionsBuilder.UseSqlServer("Data Source=77.245.159.136;Initial Catalog=veteriner;User ID=veteriner;Password=A.sd12345678987654321;persist security info=True");
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
