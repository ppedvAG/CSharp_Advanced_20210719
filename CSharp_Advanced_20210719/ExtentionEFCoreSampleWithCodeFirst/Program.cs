using Microsoft.EntityFrameworkCore;
using System;

namespace ExtentionEFCoreSampleWithCodeFirst
{
    using ExtentionEFCoreSampleWithCodeFirst.Context;
    using ExtentionEFCoreSampleWithCodeFirst.Entities;
    class Program
    {
        static void Main(string[] args)
        {
            using ()
        }
    }
}


namespace ExtentionEFCoreSampleWithCodeFirst.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
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

        public DbSet<Book> Books { get; set; }
    }
}
