using AutoMapper;
using Library.Application.Queries.User;
using Library.Application.Repositories;
using MediatR;

namespace Library.Application.Handlers.User;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<GetUserResponse>>
{
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;

	public GetAllUsersHandler(IUserRepository userRepository, IMapper mapper)
	{
		_userRepository = userRepository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<GetUserResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
	{
		var user = await _userRepository.GetAll(cancellationToken);
		return _mapper.Map<IEnumerable<GetUserResponse>>(user);
	}
}