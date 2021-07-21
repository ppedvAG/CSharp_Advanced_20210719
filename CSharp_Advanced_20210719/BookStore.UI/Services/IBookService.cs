using BookStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.UI.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAll();

        Task<Book> GetById(int id);

        Task InsertBook(Book book);

        Task UpdateBook(Book book);

        Task DeleteBook(int id);

    }
}
