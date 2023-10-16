using RWBooks.DataAccess.Repositories;
using RWBooks.Domain.Models;

namespace RWBooks.Service.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthorList> GetAuthorList()
        {
            var authorListItems = await _unitOfWork.Authors.GetAuthorListItems();
            AuthorList authorList = new() { AuthorListItems = authorListItems };

            return authorList;
        }
    }
}
