using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.ModelConfig
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id); // Primary Key
            builder.Property(d => d.Name).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Description).HasMaxLength(500).IsRequired(false);
            builder.Property(d => d.Location).HasDefaultValue("New York");
            builder.Property(d => d.Phone).IsRequired().HasMaxLength(50);
            builder.Property(d => d.CreatedAt).HasDefaultValueSql("GETDATE()");

            // One-to-One relationship with Manager (Employee) Optional
            builder
                .HasOne(d=> d.Manager)
                .WithMany()
                .HasForeignKey(d => d.ManagerId)
                .IsRequired(false);
        }
    }
}
