using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Library.Application.DTO_s.User;
using Library.Application.Repositories;
using Library.Application.User.Commands;
using Library.Domain.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.User.Handlers;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserDto>
{
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
  

    public UpdateUserHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
	{
		_userRepository = userRepository;
		_mapper = mapper;
		_unitOfWork = unitOfWork;
        
	}

    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
       
        var user = await _userRepository.GetById(request.UserId, cancellationToken);
        if (user == null) throw new NotFoundException("Пользователь не найден!");

        _mapper.Map(request.User, user);
       
   
        try
        {
            await _unitOfWork.Save(cancellationToken);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            var updatedUser = await _userRepository.GetById(request.UserId, cancellationToken);

            if (updatedUser == null) throw new NotFoundException("Пользователь не найден!");

            _mapper.Map(request.User, updatedUser);

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.User.PasswordHash);

            updatedUser.PasswordHash = hashedPassword;

            await _unitOfWork.Save(cancellationToken);
        }

        return _mapper.Map<UserDto>(user);
    }
}