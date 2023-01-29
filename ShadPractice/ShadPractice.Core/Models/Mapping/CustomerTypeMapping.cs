using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ShadPractice.Core.Models.Mapping
{
    public class CustomerTypeMapping : IEntityTypeConfiguration<CustomerTypes>
    {
        public void Configure(EntityTypeBuilder<CustomerTypes> builder)
        {
            builder.ToTable("CustomerTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasColumnName("Description");
        }
    }
}
