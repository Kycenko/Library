using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Library.Domain.Enums;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserRole
{
	[Display(Name = "ADMIN")]
	ADMIN,
	[Display(Name = "USER")]
	USER,
	[Display(Name = "GUEST")]
	GUEST
}