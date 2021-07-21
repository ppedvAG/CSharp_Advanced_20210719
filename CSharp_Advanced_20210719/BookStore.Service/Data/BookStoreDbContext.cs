using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Shared.Entities;

namespace BookStore.Service.Data
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext (DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<BookStore.Shared.Entities.Book> Book { get; set; }
    }
}
