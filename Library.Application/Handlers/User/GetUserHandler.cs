using AutoMapper;
using Library.Application.Queries.User;
using Library.Application.Repositories;
using MediatR;

namespace Library.Application.Handlers.User;

public class GetUserHandler : IRequestHandler<GetUserQuery, GetUserResponse>
{
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;

	public GetUserHandler(IUserRepository userRepository, IMapper mapper)
	{
		_userRepository = userRepository;
		_mapper = mapper;
	}

	public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
	{
		var user = await _userRepository.GetById(request.UserId, cancellationToken);
		return user == null ? null : _mapper.Map<GetUserResponse>(user);
	}
}