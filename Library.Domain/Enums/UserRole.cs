
using System.Text.Json.Serialization;

namespace Library.Domain.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserRole
{
	Customer,
	Admin
}