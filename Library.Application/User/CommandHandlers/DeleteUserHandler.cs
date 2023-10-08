using AutoMapper;
using Library.Application.Repositories;
using Library.Application.User.Commands;
using MediatR;

namespace Library.Application.User.CommandHandlers;

public class DeleteUserHandler : IRequestHandler<DeleteUser, bool>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<bool> Handle(DeleteUser request, CancellationToken cancellationToken)
    {
        _userRepository.Delete(request.UserId);
        await _unitOfWork.Save(cancellationToken);

      return true; 
    }
}