using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Spectrum.Model.Model;

namespace Spectrum.DatabaseContext.DatabaseContext
{
    public class ProjectDbContext: DbContext
    {
        public ProjectDbContext()
        {
           Configuration.LazyLoadingEnabled = false; // Disable Lazy Loading
        }
        
        public DbSet<Category> Category { set; get; }
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Product> Product { set; get; }
        public DbSet<Purchase> Purchases { set; get; }
        public DbSet<PurchaseDetails> PurchaseDetailses { set; get; }
        public DbSet<Supplier> Supplier { set; get; }
        public DbSet<Sales> Sales { set; get; }
        public DbSet<SalesDetails> SalesDetails { set; get; }



    }
}
