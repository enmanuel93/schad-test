using Microsoft.EntityFrameworkCore;
using ShadPractice.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShadPractice.Core.Contexts
{
    public class TestInvoiceContext: DbContext
    {
        public TestInvoiceContext(DbContextOptions<TestInvoiceContext> options):
            base(options)
        {

        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<CustomerTypes> customerTypess { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<InvoiceDetail> invoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
