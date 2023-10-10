using Library.Application.Repositories;
using Library.Application.User.Commands;
using Library.Domain.Common.Exceptions;
using MediatR;

namespace Library.Application.User.Handlers;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Guid>
{
	private readonly IUserRepository _userRepository;

	private readonly IUnitOfWork _unitOfWork;

	public DeleteUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
	{
		_userRepository = userRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Guid> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
	{
		var user = await _userRepository.GetById(request.UserId, cancellationToken);
		if (user == null) throw new NotFoundException("Пользователь не найден!");
		_userRepository.Delete(user);
		await _unitOfWork.Save(cancellationToken);
		return user.Id;
	}
}