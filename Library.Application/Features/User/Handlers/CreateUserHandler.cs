﻿using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Library.Application.Common.Exceptions;
using Library.Application.DTO_s.User;
using Library.Application.Features.User.Commands;
using Library.Application.Repositories;
using Library.Application.Repositories.Base;
using MediatR;

namespace Library.Application.User.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<Domain.Entities.User> _validator;

        public CreateUserHandler(IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork,
            IValidator<Domain.Entities.User> validator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userEntity = _mapper.Map<Domain.Entities.User>(request.User);
                ValidationResult validationResult = await _validator.ValidateAsync(userEntity, cancellationToken);
                if (!validationResult.IsValid) throw new ValidationException("Ошибка валидации!", validationResult.Errors);
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.User.PasswordHash);
                userEntity.PasswordHash = hashedPassword;
                await _userRepository.Create(userEntity);
                await _unitOfWork.Save(cancellationToken);
                return _mapper.Map<UserDto>(userEntity);
            }
            catch (Exception ex)
            {
                throw new CreationException("Ошибка при создании пользователя!", ex);
            }
        }
    }
}