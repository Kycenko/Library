using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Library.Application.DTO_s.User;
using Library.Application.Repositories;
using Library.Application.User.Commands;
using Library.Domain.Common.Exceptions;
using Library.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.User.Handlers;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<Domain.Entities.User> _validator;


    public UpdateUserHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork, IValidator<Domain.Entities.User> validator)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newUser = await _userRepository.GetById(request.UserId, cancellationToken) ?? throw new NotFoundException("Пользователь с таким Id не найден!");
            _mapper.Map(request.User, newUser);
            ValidationResult validationResult = await _validator.ValidateAsync(newUser, cancellationToken);
            if (!validationResult.IsValid) throw new ValidationException("Ошибка валидации!", validationResult.Errors);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.User.PasswordHash);
            newUser.PasswordHash = hashedPassword;
            _userRepository.Update(newUser);
            await _unitOfWork.Save(cancellationToken);
            return _mapper.Map<UserDto>(newUser);
        }
        catch (Exception ex)
        {

            throw new UpdateException("Ошибка при обновлении пользователя!", ex);
        }
    }
}