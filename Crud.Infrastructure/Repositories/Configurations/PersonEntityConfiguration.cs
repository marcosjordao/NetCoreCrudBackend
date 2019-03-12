using Crud.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Infrastructure.Repositories.Configurations
{
    public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            // Table
            builder.ToTable("Person");

            // Id
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id)
                         .UseSqlServerIdentityColumn();
            
            // Name
            builder.Property(f => f.Name).HasMaxLength(70)
                                               .IsRequired();

            // Email
            builder.OwnsOne(f => f.Email)
                         .Property(f => f.Address)
                         .HasMaxLength(60)
                         .HasColumnName("Email");

            // Telefone
            builder.Property(f => f.Phone).HasMaxLength(20);

        }
    }
}
