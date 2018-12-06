using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MobileShop.Models
{
    public class MyContext: DbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {
            
        }

        public DbSet<CardDetails> CardDetails { get; set; }

        public DbSet<Category> Categories {get; set;}

        //public DbSet<Customer_order> CustomerOrders {get; set;}

        public DbSet<Customers> Customers {get; set;}

        public DbSet<Feedback> Feedbacks {get; set;}

        //public DbSet<feedback_products> FeedbackProducts {get; set;}

        public DbSet<OrderDetails> OrderDetails {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>()
                .HasKey(od => new { od.PID, od.oID });
        }

        public DbSet<Orders> Orders {get; set;}

        public DbSet<Payment> Payments {get; set;}

        public DbSet<Products> Products {get; set;}

        public DbSet<Suppliers> Suppliers {get; set;}

    }
}
