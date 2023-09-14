using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Common;

namespace Library.Domain.Entities
{
	public class Author : BaseEntity
	{
		[Key] public Guid AuthorId { get; set; } = Guid.NewGuid();

		[Required(ErrorMessage = "AuthorName is required")]
		public string? AuthorName { get; set; }
	}
}