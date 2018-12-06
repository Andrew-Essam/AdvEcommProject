﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MobileShop.Models;

namespace MobileShop.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20181206160918_First Migration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MobileShop.Models.CardDetails", b =>
                {
                    b.Property<int>("cardNo")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Exp_date");

                    b.Property<int>("cvv");

                    b.HasKey("cardNo");

                    b.ToTable("CardDetails");
                });

            modelBuilder.Entity("MobileShop.Models.Category", b =>
                {
                    b.Property<int>("CatID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CatName");

                    b.HasKey("CatID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MobileShop.Models.Customers", b =>
                {
                    b.Property<int>("CID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CAge");

                    b.Property<string>("CEmail");

                    b.Property<string>("CName");

                    b.Property<string>("CPassword");

                    b.Property<string>("CPhone");

                    b.HasKey("CID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MobileShop.Models.Feedback", b =>
                {
                    b.Property<int>("fID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CID");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Message");

                    b.Property<int>("PID");

                    b.Property<int>("oID");

                    b.HasKey("fID");

                    b.HasIndex("CID");

                    b.HasIndex("PID");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("MobileShop.Models.OrderDetails", b =>
                {
                    b.Property<int>("PID");

                    b.Property<int>("oID");

                    b.Property<int>("Quantity");

                    b.HasKey("PID", "oID");

                    b.HasAlternateKey("oID", "PID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("MobileShop.Models.Orders", b =>
                {
                    b.Property<int>("oID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CID");

                    b.Property<DateTime>("Date");

                    b.Property<string>("DeliveryStatus");

                    b.Property<int?>("feedbackfID");

                    b.HasKey("oID");

                    b.HasIndex("CID");

                    b.HasIndex("feedbackfID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MobileShop.Models.Payment", b =>
                {
                    b.Property<int>("paymentSerial")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cardNo");

                    b.Property<int>("oID");

                    b.HasKey("paymentSerial");

                    b.HasIndex("cardNo");

                    b.HasIndex("oID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("MobileShop.Models.Products", b =>
                {
                    b.Property<int>("PID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CatID");

                    b.Property<string>("PName");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Stock");

                    b.Property<int?>("_suppliersSID");

                    b.Property<int>("oID");

                    b.HasKey("PID");

                    b.HasIndex("CatID");

                    b.HasIndex("_suppliersSID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MobileShop.Models.Suppliers", b =>
                {
                    b.Property<int>("SID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PID");

                    b.Property<string>("SAddress");

                    b.Property<string>("SName");

                    b.Property<string>("SPhone");

                    b.HasKey("SID");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("MobileShop.Models.Feedback", b =>
                {
                    b.HasOne("MobileShop.Models.Customers", "_customers")
                        .WithMany("flist")
                        .HasForeignKey("CID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MobileShop.Models.Products", "product")
                        .WithMany("flist")
                        .HasForeignKey("PID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MobileShop.Models.OrderDetails", b =>
                {
                    b.HasOne("MobileShop.Models.Products", "_products")
                        .WithMany("odlist")
                        .HasForeignKey("PID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MobileShop.Models.Orders", "_orders")
                        .WithMany("odlist")
                        .HasForeignKey("oID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MobileShop.Models.Orders", b =>
                {
                    b.HasOne("MobileShop.Models.Customers", "clist")
                        .WithMany("OrdersList")
                        .HasForeignKey("CID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MobileShop.Models.Feedback", "feedback")
                        .WithMany("olist")
                        .HasForeignKey("feedbackfID");
                });

            modelBuilder.Entity("MobileShop.Models.Payment", b =>
                {
                    b.HasOne("MobileShop.Models.CardDetails", "CardDetails")
                        .WithMany("Payment")
                        .HasForeignKey("cardNo")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MobileShop.Models.Orders", "Order")
                        .WithMany()
                        .HasForeignKey("oID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MobileShop.Models.Products", b =>
                {
                    b.HasOne("MobileShop.Models.Category", "_category")
                        .WithMany("plist")
                        .HasForeignKey("CatID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MobileShop.Models.Suppliers", "_suppliers")
                        .WithMany("plist")
                        .HasForeignKey("_suppliersSID");
                });
#pragma warning restore 612, 618
        }
    }
}
