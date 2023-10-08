using AutoMapper;
using Library.Application.Repositories;
using Library.Application.User.Queries;
using MediatR;

namespace Library.Application.User.QueryHandlers;

public class GetAllUsersHandler : IRequestHandler<GetAllUsers, Domain.Entities.User>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUsersHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }


    public async Task<Domain.Entities.User> Handle(GetAllUsers request, CancellationToken cancellationToken)
    {
        
        var user = await _userRepository.GetAll(cancellationToken);
        return _mapper.Map<Domain.Entities.User>(user);
    }
}