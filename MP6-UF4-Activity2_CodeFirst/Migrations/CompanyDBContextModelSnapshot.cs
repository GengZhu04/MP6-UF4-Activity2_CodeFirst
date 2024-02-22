﻿// <auto-generated />
using System;
using MP6_UF4_Activity2_CodeFirst.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MP6_UF4_Activity2_CodeFirst.Migrations
{
    [DbContext(typeof(CompanyDBContext))]
    partial class CompanyDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MP6_UF4_Activity2_CodeFirst.Model.Customers", b =>
                {
                    b.Property<int>("CustomerNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("ContactFirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("ContactLastName")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<decimal>("CreditLimit")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<int>("SalesRepEmployeeNumber")
                        .HasColumnType("int(11)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("CustomerNumber");

                    b.HasIndex("SalesRepEmployeeNumber");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MP6_UF4_Activity2_CodeFirst.Model.Employees", b =>
                {
                    b.Property<int>("EmployeeNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("OfficeCode")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<int>("ReportsTo")
                        .HasColumnType("int(11)");

                    b.HasKey("EmployeeNumber");

                    b.HasIndex("OfficeCode");

                    b.HasIndex("ReportsTo");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MP6_UF4_Activity2_CodeFirst.Model.Offices", b =>
                {
                    b.Property<string>("OfficeCode")
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Territory")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.HasKey("OfficeCode");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("MP6_UF4_Activity2_CodeFirst.Model.OrderDetails", b =>
                {
                    b.Property<string>("ProductCode")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<int>("OrderNumber")
                        .HasColumnType("INT(11)");

                    b.Property<short>("OrderLineNumber")
                        .HasColumnType("smallint");

                    b.Property<decimal>("PriceEach")
                        .HasColumnType("DECIMAL(10,2)");

                    b.Property<int>("QuantityOrdered")
                        .HasColumnType("INT(11)");

                    b.HasKey("ProductCode", "OrderNumber");

                    b.HasIndex("OrderNumber");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("MP6_UF4_Activity2_CodeFirst.Model.Orders", b =>
                {
                    b.Property<int>("OrderNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT(11)");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("CustomerNumberId")
                        .HasColumnType("INT(11)");

                    b.Property<DateTime>("OrderData")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("RequiredDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ShippedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.HasKey("OrderNumber");

                    b.HasIndex("CustomerNumberId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MP6_UF4_Activity2_CodeFirst.Model.Payments", b =>
                {
                    b.Property<int>("CustomerNumber")
                        .HasColumnType("int(11)");

                    b.Property<string>("CheckNumber")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("date");

                    b.HasKey("CustomerNumber", "CheckNumber");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("MP6_UF4_Activity2_CodeFirst.Model.ProductLines", b =>
                {
                    b.Property<string>("ProductLine")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("HtmlDescription")
                        .IsRequired()
                        .HasColumnType("MEDIUMTEXT");

                    b.Property<byte[]>("Imatge")
                        .IsRequired()
                        .HasColumnType("MEDIUMBLOB");

                    b.Property<string>("TextDescription")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasMaxLength(4000);

                    b.HasKey("ProductLine");

                    b.ToTable("ProductLines");
                });

            modelBuilder.Entity("MP6_UF4_Activity2_CodeFirst.Model.Products", b =>
                {
                    b.Property<string>("ProductCode")
                        .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
                        .HasMaxLength(15);

                    b.Property<decimal>("BuyPrice")
                        .HasColumnType("DECIMAL(10,2)");

                    b.Property<decimal>("MSRP")
                        .HasColumnType("DECIMAL(10,2)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductLines")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("varchar(70) CHARACTER SET utf8mb4")
                        .HasMaxLength(70);

                    b.Property<string>("ProductScale")
                        .IsRequired()
                        .HasColumnType("varchar(10) CHARACTER SET utf8mb4")
                        .HasMaxLength(10);

                    b.Property<string>("ProductVendor")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<short>("QuantityInStock")
                        .HasColumnType("smallint");

                    b.HasKey("ProductCode");

                    b.HasIndex("ProductLines");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MP6_UF4_Activity2_CodeFirst.Model.Customers", b =>
                {
                    b.HasOne("MP6_UF4_Activity2_CodeFirst.Model.Employees", "Employee")
                        .WithMany("Customers")
                        .HasForeignKey("SalesRepEmployeeNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MP6_UF4_Activity2_CodeFirst.Model.Employees", b =>
                {
                    b.HasOne("MP6_UF4_Activity2_CodeFirst.Model.Offices", "Office")
                        .WithMany("Employees")
                        .HasForeignKey("OfficeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MP6_UF4_Activity2_CodeFirst.Model.Employees", "EmployeesToReport")
                        .WithMany()
                        .HasForeignKey("ReportsTo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MP6_UF4_Activity2_CodeFirst.Model.OrderDetails", b =>
                {
                    b.HasOne("MP6_UF4_Activity2_CodeFirst.Model.Orders", "Orders")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MP6_UF4_Activity2_CodeFirst.Model.Products", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MP6_UF4_Activity2_CodeFirst.Model.Orders", b =>
                {
                    b.HasOne("MP6_UF4_Activity2_CodeFirst.Model.Customers", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerNumberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MP6_UF4_Activity2_CodeFirst.Model.Payments", b =>
                {
                    b.HasOne("MP6_UF4_Activity2_CodeFirst.Model.Customers", "Customer")
                        .WithMany("Payments")
                        .HasForeignKey("CustomerNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MP6_UF4_Activity2_CodeFirst.Model.Products", b =>
                {
                    b.HasOne("MP6_UF4_Activity2_CodeFirst.Model.ProductLines", "ProductLine")
                        .WithMany()
                        .HasForeignKey("ProductLines");
                });
#pragma warning restore 612, 618
        }
    }
}