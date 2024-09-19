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
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .UseIdentityColumn(1, 1);

            builder.HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.FName)
                .HasColumnName("First_Name")
                .HasColumnType("NVARCHAR(20");

            builder.Property(e => e.LName)
                .HasColumnName("Last_Name")
                .HasColumnType("NVARCHAR(20)");

            builder.Property(e => e.Title)
                .HasColumnType("VarChar(50)");
            builder.Property(e => e.JoinedAt)
                .HasColumnType("DateTime");
        }
    }
}
