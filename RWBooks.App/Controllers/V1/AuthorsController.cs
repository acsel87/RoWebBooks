using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RWBooks.App.Extensions;
using RWBooks.App.Models;
using RWBooks.DataAccess.Entities;
using RWBooks.DataAccess.Repositories;
using RWBooks.Domain.Models;
using RWBooks.Service.Services;

namespace RWBooks.App.Controllers.V1
{
    [ApiController]    
    [ApiVersion("1.0", Deprecated = true)]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly ILogger<AuthorsController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorService _authorService;

        public AuthorsController(ILogger<AuthorsController> logger, IUnitOfWork unitOfWork, IAuthorService authorService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _authorService = authorService;
        }

        [HttpGet]        
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AuthorListItem>))]
        public async Task<IActionResult> Get()
        {
            var authorList = await _authorService.GetAuthorList();
            return new ApiResponse<AuthorList>(authorList);
        }        

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Author))]
        public async Task<IActionResult> Create(AuthorCreateViewModel authorCreateViewModel)
        {
            var author = authorCreateViewModel.ToAuthor();

            await _unitOfWork.Authors.Add(author);
            var result = await _unitOfWork.Commit();

            if (result < 1)
            {
                return new ApiError(message: "Failed to create the author.");
            }

            author = await _unitOfWork.Authors.GetById(author.Id);
            if (author is null)
            {
                return new ApiError(message: "Failed to retrieve the inserted author.");
            }

            return CreatedAtAction(nameof(Create), new { id = author.Id }, author);
        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var author = await _unitOfWork.Authors.GetById(id);
            if (author == null)
            {                
                return new ApiError(StatusCodes.Status404NotFound);
            }
            
            await _unitOfWork.Authors.SoftDelete(author);
            var result = await _unitOfWork.Commit();
            if (result < 1)
            {
                return new ApiError(message: "Failed to delete the author.");
            }

            return NoContent();
        }
    }
}