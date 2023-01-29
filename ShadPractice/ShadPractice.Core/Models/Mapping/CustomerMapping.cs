using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadPractice.Core.Models.Mapping
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CustName).HasColumnName("CustName");
            builder.Property(x => x.Adress).HasColumnName("Adress");
            builder.Property(x => x.Status).HasColumnName("Status").HasColumnType("bit");
            builder.Property(x => x.CustomerTypeId).HasColumnName("CustomerTypeId");

            builder.HasOne(ct => ct.CustomerTypes)
                .WithMany(c => c.Customers)
                .HasForeignKey(ct => ct.CustomerTypeId);
        }
    }
}
