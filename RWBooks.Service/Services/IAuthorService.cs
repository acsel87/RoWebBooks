using RWBooks.Domain.Models;

namespace RWBooks.Service.Services
{
    public interface IAuthorService
    {
        Task<AuthorList> GetAuthorList();
    }
}