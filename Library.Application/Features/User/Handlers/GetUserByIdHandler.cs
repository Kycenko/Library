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
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetById(request.UserId, cancellationToken);
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {
                throw new NotFoundException("Пользователь с таким Id не найден!", ex);
             
            }
          
        }
    }
}
