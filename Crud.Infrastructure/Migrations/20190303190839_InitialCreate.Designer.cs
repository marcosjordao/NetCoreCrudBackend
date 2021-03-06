﻿// <auto-generated />
using Crud.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Crud.Infrastructure.Migrations
{
    [DbContext(typeof(CrudContext))]
    [Migration("20190303190839_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Crud.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("Crud.Domain.Entities.Person", b =>
                {
                    b.OwnsOne("Crud.Domain.ValueObjects.EmailAddress", "Email", b1 =>
                        {
                            b1.Property<int>("PersonId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Address")
                                .HasColumnName("Email")
                                .HasMaxLength(60);

                            b1.HasKey("PersonId");

                            b1.ToTable("Person");

                            b1.HasOne("Crud.Domain.Entities.Person")
                                .WithOne("Email")
                                .HasForeignKey("Crud.Domain.ValueObjects.EmailAddress", "PersonId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
