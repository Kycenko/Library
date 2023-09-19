using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Infrastructure.Context;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Library.Persistance.Test
{
    public class UserRepositoryTests : IDisposable
    {
        private readonly DbContextOptions<LibraryDbContext> _options;
        private readonly UnitOfWork _unitOfWork;

        public UserRepositoryTests()
        {
             
            _options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryLibraryDatabase")
                .Options;
        }

        public void Dispose()
        {
            using var context = new LibraryDbContext(_options);
            context.Database.EnsureDeleted();
        }

        [Fact]
        public void CreateUserAsync_ShouldAddUserToDatabase()
        {
            // Arrange
            using var context = new LibraryDbContext(_options);
            var repository = new UserRepository(context, cancellationToken);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Login = "testuser",
                FirstName = "John",
                LastName = "Doe",
                Role = UserRole.ADMIN
            };

            // Act
            repository.CreateUserAsync(user).Wait();

            // Assert
            using var assertContext = new LibraryDbContext(_options);
            var savedUser = assertContext.Users.FirstOrDefault(u => u.Id == user.Id);
            Assert.NotNull(savedUser);
            Assert.Equal(user.Login, savedUser.Login);
            Assert.Equal(user.FirstName, savedUser.FirstName);
            Assert.Equal(user.LastName, savedUser.LastName);
            Assert.Equal(user.Role, savedUser.Role);
        }
    }
}
