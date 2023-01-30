using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadPractice.Core.Models.Mapping
{
    public class InvoiceDetailMapping : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.ToTable("InvoiceDetail");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Qty).HasColumnName("Qty");
            builder.Property(x => x.Price).HasColumnName("Price");
            builder.Property(x => x.SubTotal).HasColumnName("SubTotal");
            builder.Property(x => x.Total).HasColumnName("Total");
            builder.Property(x => x.CustomerId).HasColumnName("CustomerId");
            builder.Property(x => x.InvoiceId).HasColumnName("InvoiceId");

            builder.HasOne(i => i.Invoice)
                .WithMany(id => id.InvoiceDetails)
                .HasForeignKey(i => i.InvoiceId);
        }
    }
}
