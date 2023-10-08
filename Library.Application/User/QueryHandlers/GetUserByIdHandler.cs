using AutoMapper;
using Library.Application.Repositories;
using Library.Application.User.Queries;
using MediatR;

namespace Library.Application.User.QueryHandlers;

public class GetUserByIdHandler : IRequestHandler<GetUserById, Domain.Entities.User>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }


    public async Task<Domain.Entities.User> Handle(GetUserById request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.UserId, cancellationToken);
        return _mapper.Map<Domain.Entities.User>(user);
    }
}