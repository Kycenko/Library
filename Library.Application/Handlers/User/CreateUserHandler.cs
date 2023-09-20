using AutoMapper;
using Library.Application.Queries.User;
using Library.Application.Repositories;
using MediatR;

namespace Library.Application.Handlers.User;

public sealed class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;

	public CreateUserHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_userRepository = userRepository;
		_mapper = mapper;
	}

	public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
	{
		var user = _mapper.Map<Domain.Entities.User>(request);
		string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);
		user.PasswordHash = hashedPassword;
		_userRepository.Create(user);

		await _unitOfWork.Save(cancellationToken);

		return _mapper.Map<CreateUserResponse>(user);
	}
}