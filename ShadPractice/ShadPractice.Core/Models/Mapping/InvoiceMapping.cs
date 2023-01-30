using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadPractice.Core.Models.Mapping
{
    public class InvoiceMapping : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoice");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TotalItbis).HasColumnName("TotalItbis");
            builder.Property(x => x.SubTotal).HasColumnName("SubTotal");
            builder.Property(x => x.Total).HasColumnName("Total");
            builder.Property(x => x.CustomerId).HasColumnName("CustomerId");

            builder.HasOne(c => c.Customers)
                .WithMany(i => i.Invoices)
                .HasForeignKey(c => c.CustomerId);
        }
    }
}
