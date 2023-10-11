using Library.Domain.Entities;
using Library.Domain.Enums;
using NUnit.Framework;

namespace Library.Domain.Tests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void User_SetProperties_GetPropertiesReturnSameValues()
        {
            // Arrange

            var user = new User();
            var userId = Guid.NewGuid();
            var login = "testuser";
            var firstName = "John";
            var lastName = "Doe";
            var email = "test@example.com";
            var passwordHash = "hashedpassword";
            var role = UserRole.Admin;
            var createdDate = DateTime.Now;
            var updatedDate = DateTime.Now;

            // Act
            user.Id = userId;
            user.Login = login;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            user.PasswordHash = passwordHash;
            user.Role = role;
            user.CreatedDate = createdDate;
            user.UpdatedDate = updatedDate;

            // Assert
            Assert.That(user.Id, Is.EqualTo(userId));
            Assert.That(user.Login, Is.EqualTo(login));
            Assert.That(user.FirstName, Is.EqualTo(firstName));
            Assert.That(user.LastName, Is.EqualTo(lastName));
            Assert.That(user.Email, Is.EqualTo(email));
            Assert.That(user.PasswordHash, Is.EqualTo(passwordHash));
            Assert.That(user.Role, Is.EqualTo(role));
            Assert.That(user.CreatedDate, Is.EqualTo(createdDate));
            Assert.That(user.UpdatedDate, Is.EqualTo(updatedDate));
        }
    }
}