using Library.Domain.Common.Interfaces.Services;
using Library.Domain.Entities;
using Library.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _service;

		public UserController(IUserService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<User>?>> GetUsers()
		{
			var users = await _service.GetAllUsersAsync();
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
		public async Task<ActionResult<User>?> GetUserAsync(Guid userId)
		{
			var user = await _service.GetUserAsync(userId);
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
		public async Task<ActionResult<User>> CreateUserAsync(User newUser)
		{
			if (newUser == null)
			{
				return BadRequest();
			}

			await _service.CreateUserAsync(newUser);
			return CreatedAtAction("GetUsers", new { id = newUser.UserId }, newUser);
		}

		[HttpPut("{userId}")]
		public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] User updatedUser)
		{
			try
			{
				var existingUser = await _service.GetUserAsync(userId);

				if (existingUser == null)
				{
					return NotFound();
				}


				existingUser.UserName = updatedUser.UserName;
				existingUser.FirstName = updatedUser.FirstName;
				existingUser.LastName = updatedUser.LastName;

				await _service.UpdateUserAsync(userId, existingUser);

				return Ok(existingUser);
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Internal Server Error");
			}
		}

		[HttpDelete("{userId}")]
		public async Task<IActionResult> DeleteUser(Guid userId)
		{
			try
			{
				var existingUser = await _service.GetUserAsync(userId);

				if (existingUser == null)
				{
					return NotFound();
				}

				await _service.DeleteUserAsync(userId);

				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Internal Server Error");
			}
		}
	}
}