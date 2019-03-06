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
        public void Configure(EntityTypeBuilder<Person> configuration)
        {
            // Table
            configuration.ToTable("Person");

            // Id
            configuration.HasKey(f => f.Id);
            configuration.Property(f => f.Id)
                         .UseSqlServerIdentityColumn();
            
            // Name
            configuration.Property(f => f.Name).HasMaxLength(70)
                                               .IsRequired();

            // Email
            configuration.OwnsOne(f => f.Email)
                         .Property(f => f.Address)
                         .HasMaxLength(60)
                         .HasColumnName("Email");

            // Telefone
            configuration.Property(f => f.Phone).HasMaxLength(20);

        }
    }
}
