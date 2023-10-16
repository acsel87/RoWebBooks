using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using RWBooks.App.Models;
using RWBooks.DataAccess.Context;
using RWBooks.DataAccess.Entities;
using RWBooks.Domain.Models;
using RWBooks.Service.Services;
using RWBooks.Tests.Utils;
using System.Net.Http.Json;

namespace RWBooks.Tests.AuthorTests
{
    public class ListAllAuthorsTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public ListAllAuthorsTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetV21_ValidRequest_ReturnsOkResultWithAuthorList()
        {
            // Arrange
            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Add("version", "2.1");

            using var scope = _factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Authors.Add(new Author { Id = Guid.NewGuid(), Name = "Author 1" });
            dbContext.Authors.Add(new Author { Id = Guid.NewGuid(), Name = "Author 2" });
            await dbContext.SaveChangesAsync();

            // Act
            var response = await client.GetAsync("authors?api-version=2.1");

            // Assert
            response.EnsureSuccessStatusCode();

            var authorList = await response.Content.ReadFromJsonAsync<ApiResponse<AuthorList>>();
            Assert.NotNull(authorList?.Data);
            Assert.NotEmpty(authorList.Data.AuthorListItems);
            Assert.Equal(StatusCodes.Status200OK, (int)response.StatusCode);
        }
    }
}
