using Library.Application.Features.User;
using Library.Domain.Common.Interfaces.Services;
using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.WebApi.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _service;

		public UserController(IUserService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<User>?>> GetUsers(CancellationToken cancellationToken)
		{
			var users = await _service.GetAllUsersAsync(cancellationToken);
			if (users == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(users);
			}
		}

		[HttpGet("{userId}")]
		public async Task<ActionResult<User>?> GetUserAsync(Guid userId, CancellationToken cancellationToken)
		{
			var user = await _service.GetUserAsync(userId, cancellationToken);
			if (user == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(user);
			}
		}


		[HttpPost]
		public async Task<ActionResult<User>> CreateUserAsync(User newUser, CancellationToken cancellationToken)
		{
			if (newUser == null)
			{
				return BadRequest();
			}
			
			var newU = new User
			{
				Login = newUser.Login,
				FirstName = newUser.FirstName,
				LastName = newUser.LastName,
				PasswordHash = newUser.PasswordHash,
				Role = newUser.Role = UserRole.ADMIN,
			};
			var validator = new UserValidator();
			var validationResult = await validator.ValidateAsync(newUser);

			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors);
			}

			string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newUser.PasswordHash);
			newUser.PasswordHash = hashedPassword;
			await _service.CreateUserAsync(newUser, cancellationToken);
			return CreatedAtAction("GetUsers", new { id = newUser.Id }, newUser);
		}

		[HttpPut("{userId}")]
		public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] User updatedUser,
			CancellationToken cancellationToken)
		{
			try
			{
				var existingUser = await _service.GetUserAsync(userId, cancellationToken);

				if (existingUser == null)
				{
					return NotFound();
				}


				existingUser.Login = updatedUser.Login;
				existingUser.FirstName = updatedUser.FirstName;
				existingUser.LastName = updatedUser.LastName;

				await _service.UpdateUserAsync(userId, existingUser, cancellationToken);

				return Ok(existingUser);
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Internal Server Error");
			}
		}

		[HttpDelete("{userId}")]
		public async Task<IActionResult> DeleteUser(Guid userId, CancellationToken cancellationToken)
		{
			try
			{
				var existingUser = await _service.GetUserAsync(userId, cancellationToken);

				if (existingUser == null)
				{
					return NotFound();
				}

				await _service.DeleteUserAsync(userId, cancellationToken);

				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Internal Server Error");
			}
		}
	}
}