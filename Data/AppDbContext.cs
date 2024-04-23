using Microsoft.EntityFrameworkCore;
using SUT23_TeknikButikModels;
using System.Reflection.Metadata.Ecma335;

namespace SUT23_TeknikButik.Data
{
    public class AppDbContext : DbContext 
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 



        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //TestData / SEED data
            modelBuilder.Entity<Product>().HasData(new Product
            {   
                ProductId = 1,
                ProductName = "Iphone 13",
                Price = 8500.00m,
                Category = Category.Phone

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                ProductName = "Samsung 14",
                Price = 10000.00m,
                Category = Category.Phone

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                ProductName = "Asus Rog",
                Price = 20000.00m,
                Category = Category.Computer

            });

            //TestData Customer
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 1,
                FirstName = "Ermin",
                LastName = "Husic",
                Email = "Ermin.husic@hotmail.com",
                Adress = "Horseshoeroad 2",
                Phone = "07777777777"

            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 2,
                FirstName = "Oskar",
                LastName = "Johansson",
                Email = "oskar.johansson@hotmail.com",
                Adress = "Blacksheeproad 44",
                Phone = "077333333"

            });

            //testdata order
            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 1,
                CustomerId = 1,
                OrderPlaced = new DateTime(2021,06,22)

            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 2,
                CustomerId = 2,
                OrderPlaced = new DateTime(2023, 05, 23)

            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderId = 3,
                CustomerId = 2,
                OrderPlaced = new DateTime(2020, 01, 2)

            });
        }

    }
}
