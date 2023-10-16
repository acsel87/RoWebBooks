using RWBooks.DataAccess.Entities;
using RWBooks.DataAccess.Repositories;
using RWBooks.Domain.Models;

namespace RWBooks.Service.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BookList> GetBookList()
        {
            var bookListItems = await _unitOfWork.Books.GetBookListItems();
            BookList bookList = new() { BookListItems = bookListItems };

            return bookList;
        }

        public async Task AddBookWithNewAuthorAsync(Book book, Author author)
        {
            book.Author = author;
            await _unitOfWork.Books.Add(book);
            await _unitOfWork.Commit();
        }
    }

}
