using InvoiceApp2.Models;
using Microsoft.EntityFrameworkCore;
namespace InvoiceApp2.Data
{
    

   
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options) { }

            public DbSet<Invoice> Invoices { get; set; } // represents "Invoices" table
        }
    
}
