using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace ExtentionEFCoreSampleWithCodeFirst
{
    using ExtentionEFCoreSampleWithCodeFirst.Context;
    using ExtentionEFCoreSampleWithCodeFirst.Entities;
    class Program
    {
        static void Main(string[] args)
        {
            using (BookDbContext ctx = new BookDbContext())
            {
                
            }
        }
    }
}


namespace ExtentionEFCoreSampleWithCodeFirst.Entities
{
    public class Book
    {
        public int Id { get; set; }

        //[Required]
        public string Title { get; set; }

        //[MaxLength(50)]
        public string Description { get; set; }
        public string Price { get; set; }
    }
}

namespace ExtentionEFCoreSampleWithCodeFirst.Context
{
    using ExtentionEFCoreSampleWithCodeFirst.Entities;

    public class BookDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("BookDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<Book>()
                    .Property(s => s.Id)
                    .IsRequired();

            //Separate method calls
            
            modelBuilder.Entity<Book>().Property(s => s.Title).IsRequired();
            modelBuilder.Entity<Book>().Property(s => s.Description).HasMaxLength(50);
        }

        public DbSet<Book> Books { get; set; }
    }
}
