using AutoMapper;
using Library.Application.DTO_s.User;
using Library.Application.Repositories;
using Library.Application.User.Queries;
using Library.Domain.Common.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.User.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUsersHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userRepository.GetAll(cancellationToken);
                return _mapper.Map<List<UserDto>>(users);
            }
            catch (Exception ex)
            {
                throw new NotFoundException("Пользователи не найдены!", ex);
            }

        }
    }
}
