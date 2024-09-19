using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.ModelConfig
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id); // Primary Key
            builder.Property(e => e.FName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(150);
            builder.Property(e => e.Phone).IsRequired().HasMaxLength(50);
            builder .Property(e => e.City).HasDefaultValue("New York");
            builder.Property(e => e.JoinedAt).HasDefaultValueSql("GETDATE()");

            // Foreign Key relationship with Department
            builder.HasOne(e => e.Department)
                  .WithMany(d => d.Employees)
                  .HasForeignKey(e => e.DepartmentId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
