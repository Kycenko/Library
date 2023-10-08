using Library.Domain.Entities;
using AutoMapper;
using Library.Application.Repositories;
using Library.Application.User.Commands;
using MediatR;


namespace Library.Application.User.CommandHandlers;

public class CreateUserHandler : IRequestHandler<CreateUser, Domain.Entities.User>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Domain.Entities.User> Handle(CreateUser request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<Domain.Entities.User>(request);
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);
        user.PasswordHash = hashedPassword;
        _userRepository.Create(user);
        await _unitOfWork.Save(cancellationToken);
        return _mapper.Map<Domain.Entities.User>(user);
    }
}