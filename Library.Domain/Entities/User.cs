using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Library.Domain.Common;
using Library.Domain.Enums;

namespace Library.Domain.Entities;

public class User : BaseEntity
{
    public Guid UserId { get; set; } = Guid.NewGuid();

    public string? UserName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
    

    public string? PasswordHash { get; set; }


    public string? Email { get; set; }


    public UserRole Role { get; set; }
}
