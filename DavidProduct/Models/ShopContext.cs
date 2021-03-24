using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DavidProduct.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
         new Category { CategoryID = 1, Name = "Chocolates" },
         new Category { CategoryID = 2, Name = "Fruit Candy" },
         new Category { CategoryID = 3, Name = "Gummy Candy" },
         new Category { CategoryID = 4, Name = "Halloween Candy" },
         new Category { CategoryID = 5, Name = "Hard Candy" }
         );

            modelBuilder.Entity<Product>().HasData(
              new Product
              {
                  ProductID = 1,
                  CategoryID = 1,
                  Code = "Chocolate_Assorted",
                  Name = "Assorted Chocolate",
                  Price = (decimal)4.99
              },
              new Product
              {
                  ProductID = 2,
                  CategoryID = 1,
                  Code = "Chocolate_Mixed",
                  Name = "Chocolate Mixed Candy",
                  Price = (decimal)5.99
              },
              new Product
              {
                  ProductID = 3,
                  CategoryID = 1,
                  Code = "Chocolate_MMS",
                  Name = "M&M",
                  Price = (decimal)3.75
              },
              new Product
              {
                  ProductID = 4,
                  CategoryID = 2,
                  Code = "Fruit_Chewy",
                  Name = "Chewy Fruit Candy",
                  Price = (decimal)6.90
              },
              new Product
              {
                  ProductID = 5,
                  CategoryID = 2,
                  Code = "Fruit_Pops",
                  Name = "Fruit Lolli Pops",
                  Price = (decimal)2.90
              },
              new Product
              {
                  ProductID = 6,
                  CategoryID = 2,
                  Code = "Fruit_Sour",
                  Name = "Sour Fruit Candy",
                  Price = (decimal)4.95
              },
              new Product
              {
                  ProductID = 7,
                  CategoryID = 3,
                  Code = "Gummy_Import",
                  Name = "Imported Gummy Candy",
                  Price = (decimal)11.90
              },
              new Product
              {
                  ProductID = 8,
                  CategoryID = 3,
                  Code = "Gummy_Sour",
                  Name = "Gummy Sour Candy",
                  Price = (decimal)1.90
              },
              new Product
              {
                  ProductID = 9,
                  CategoryID = 3,
                  Code = "Gummy_Traditional",
                  Name = "Traditional Gummy Candy",
                  Price = (decimal)2.90
              },
              new Product
              {
                  ProductID = 10,
                  CategoryID = 4,
                  Code = "Halloween_Assorted",
                  Name = "Assorted Halloween Candy",
                  Price = (decimal)3.50
              },
              new Product
              {
                  ProductID = 11,
                  CategoryID = 4,
                  Code = "Halloween_Orange",
                  Name = "Halloween Orange Cones",
                  Price = (decimal)4.33
              },
              new Product
              {
                  ProductID = 12,
                  CategoryID = 4,
                  Code = "Halloween_Red",
                  Name = "Halloween Red Cones",
                  Price = (decimal)3.98
              },
              new Product
              {
                  ProductID = 13,
                  CategoryID = 5,
                  Code = "Hard_Fruit",
                  Name = "Hard Fruit Candy",
                  Price = (decimal)9.90
              },
              new Product
              {
                  ProductID = 14,
                  CategoryID = 5,
                  Code = "Hard_Assorted",
                  Name = "Hard Assorted Candy",
                  Price = (decimal)8.97
              },
              new Product
              {
                  ProductID = 15,
                  CategoryID = 5,
                  Code = "Hard_Sour",
                  Name = "Sour Hard Candy",
                  Price = (decimal)5.55
              });
        }

    }
}
