using System.ComponentModel.DataAnnotations;
using Library.Domain.Common;

namespace Library.Domain.Entities
{
	public class Genre : BaseEntity
	{
		public string? GenreName { get; set; }
	}
}