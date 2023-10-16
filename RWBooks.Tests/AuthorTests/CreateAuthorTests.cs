using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RWBooks.DataAccess.Context;
using RWBooks.DataAccess.Entities;
using RWBooks.Domain.Models;
using RWBooks.Tests.Utils;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace RWBooks.Tests.AuthorTests
{
    public class CreateAuthorTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public CreateAuthorTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Create_WithValidAuthorInfo_ReturnsOkResultAndAddsAuthorToDatabase()
        {
            // Arrange
            var authorInfo = new AuthorInfo
            {
                Id = Guid.NewGuid(),
                Name = "John Doe"
            };

            using var scope = _factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("authors/create", authorInfo);

            // Assert
            response.EnsureSuccessStatusCode();
                      
            var addedAuthor = await dbContext.Authors.FindAsync(authorInfo.Id);

            Assert.NotNull(addedAuthor);

            var apiResponse = await response.Content.ReadFromJsonAsync<Author>();
            Assert.NotNull(apiResponse);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Create_WithInvalidAuthorInfo_ReturnsBadRequest()
        {
            // Arrange
            var invalidAuthorInfo = new
            {
                // Missing the "Name" property which is required
            };

            var client = _factory.CreateClient();

            var content = new StringContent(
                 JsonConvert.SerializeObject(invalidAuthorInfo),
                 Encoding.UTF8,
                 "application/json");

            // Act
            var response = await client.PostAsync("authors/create", content);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
