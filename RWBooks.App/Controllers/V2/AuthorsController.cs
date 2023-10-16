using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RWBooks.App.Models;
using RWBooks.Domain.Models;
using RWBooks.Service.Services;

namespace RWBooks.App.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
    [ApiVersion("2.1")]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(ILogger<AuthorsController> logger)
        {
            _logger = logger;       
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AuthorListItem>))]
        public Task<IActionResult> GetV20()
        {
            return Task.FromResult<IActionResult>(Ok("vs 2.0 - for demo purpose"));
        }

        [HttpGet]
        [MapToApiVersion("2.1")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AuthorListItem>))]
        public Task<IActionResult> Get()
        {
            _logger.LogWarning("testing structured logging");
            return Task.FromResult<IActionResult>(Ok("v2.1 - for demo purpose"));
        }
    }
}