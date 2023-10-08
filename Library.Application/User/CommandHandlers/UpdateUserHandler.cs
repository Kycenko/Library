using AutoMapper;
using Library.Application.Repositories;
using Library.Application.User.Commands;
using MediatR;

namespace Library.Application.User.CommandHandlers;

public class UpdateUserHandler : IRequestHandler<UpdateUser, bool>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<bool> Handle(UpdateUser request, CancellationToken cancellationToken)
    {
        var newUser = _mapper.Map<Domain.Entities.User>(request.NewUser);
         _userRepository.Update(newUser);
        await _unitOfWork.Save(cancellationToken);
        return true;
    }
}