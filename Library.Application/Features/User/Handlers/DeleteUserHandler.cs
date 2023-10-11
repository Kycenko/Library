
using Library.Application.Repositories;
using Library.Application.User.Commands;
using Library.Domain.Common.Exceptions;
using MediatR;

namespace Library.Application.CQRS.User.Handlers;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userRepository.GetById(request.UserId, cancellationToken) ?? throw new NotFoundException("Пользователь не найден!");
            _userRepository.Delete(user);
            await _unitOfWork.Save(cancellationToken);

        }
        catch (Exception ex)
        {
            throw new DeleteException("Ошибка при удалении пользователя!", ex);
        }

    }
}