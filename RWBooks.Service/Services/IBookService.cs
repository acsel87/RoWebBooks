using RWBooks.DataAccess.Entities;
using RWBooks.Domain.Models;

namespace RWBooks.Service.Services
{
    public interface IBookService
    {
        Task AddBookWithNewAuthorAsync(Book book, Author author);
        Task<BookList> GetBookList();
    }
}