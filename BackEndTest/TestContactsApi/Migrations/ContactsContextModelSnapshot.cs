﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestContactsApi.Data;

namespace TestContactsApi.Migrations
{
    [DbContext(typeof(ContactsContext))]
    partial class ContactsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TestContactsApi.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AddressName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressName = "Santa Fe 1",
                            ContactId = 1
                        },
                        new
                        {
                            Id = 2,
                            AddressName = "Santa Fe 2",
                            ContactId = 1
                        },
                        new
                        {
                            Id = 3,
                            AddressName = "Santa Fe 3",
                            ContactId = 2
                        },
                        new
                        {
                            Id = 4,
                            AddressName = "Santa Fe 4",
                            ContactId = 3
                        },
                        new
                        {
                            Id = 5,
                            AddressName = "Santa Fe 5",
                            ContactId = 4
                        },
                        new
                        {
                            Id = 6,
                            AddressName = "Santa Fe 6",
                            ContactId = 1
                        },
                        new
                        {
                            Id = 7,
                            AddressName = "Santa Fe 7",
                            ContactId = 2
                        });
                });

            modelBuilder.Entity("TestContactsApi.Models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            ContactId = 1,
                            Name = "Karina",
                            Phone = "5579032321"
                        },
                        new
                        {
                            ContactId = 2,
                            Name = "Antonio",
                            Phone = "7123129809"
                        },
                        new
                        {
                            ContactId = 3,
                            Name = "Maria",
                            Phone = "987654322"
                        },
                        new
                        {
                            ContactId = 4,
                            Name = "Felipe",
                            Phone = "987654323"
                        });
                });

            modelBuilder.Entity("TestContactsApi.Models.Address", b =>
                {
                    b.HasOne("TestContactsApi.Models.Contact", "Contact")
                        .WithMany("Addresses")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("TestContactsApi.Models.Contact", b =>
                {
                    b.Navigation("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
