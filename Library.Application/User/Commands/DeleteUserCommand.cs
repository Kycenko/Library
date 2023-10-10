using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library.Application.User.Commands
{
	public class DeleteUserCommand : IRequest<Guid>
	{
		public Guid UserId { get; }

		public DeleteUserCommand(Guid userId)
		{
			UserId = userId;
		}
	}
}