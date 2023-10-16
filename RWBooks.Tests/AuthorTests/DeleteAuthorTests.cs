using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RWBooks.DataAccess.Context;
using RWBooks.DataAccess.Entities;
using RWBooks.Tests.Utils;
using System.Net;

namespace RWBooks.Tests.AuthorTests
{
    public class DeleteAuthorTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public DeleteAuthorTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }        

        [Fact]
        public async Task Delete_WithValidAuthorId_SoftDeletesAuthorAndReturnsNoContent()
        {
            // Arrange            
            var author = new Author
            {
                Id = Guid.NewGuid(),
                Name = "John Doe"
            };

            using var scope = _factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            dbContext.Authors.Add(author);
            await dbContext.SaveChangesAsync();

            var client = _factory.CreateClient();

            // Act
            var response = await client.DeleteAsync($"authors/delete/{author.Id}");

            // Assert
            response.EnsureSuccessStatusCode();
            dbContext.Entry(author).State = EntityState.Detached;
            var softDeletedAuthor = await dbContext.Authors.FindAsync(author.Id);

            Assert.NotNull(softDeletedAuthor);
            Assert.True(softDeletedAuthor.IsDeleted);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task Delete_WithNonExistentAuthorId_ReturnsNotFound()
        {
            // Arrange
            var nonExistentAuthorId = Guid.NewGuid();

            var client = _factory.CreateClient();

            // Act
            var response = await client.DeleteAsync($"authors/delete/{nonExistentAuthorId}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
