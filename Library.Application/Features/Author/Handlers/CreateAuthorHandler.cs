using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Library.Application.Common.Exceptions;
using Library.Application.DTO_s.Author;
using Library.Application.Features.Author.Commands;
using Library.Application.Repositories;
using Library.Application.Repositories.Base;
using MediatR;

namespace Library.Application.Features.Author.Handlers;

public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, AuthorDto>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<Domain.Entities.Author> _validator;
    public CreateAuthorHandler(IAuthorRepository authorRepository, IMapper mapper, IUnitOfWork unitOfWork, IValidator<Domain.Entities.Author> validator)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _validator = validator;
        _authorRepository = authorRepository;
    }
    public async Task<AuthorDto> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var authorEntity = _mapper.Map<Domain.Entities.Author>(request.Author);
            ValidationResult validationResult = await _validator.ValidateAsync(authorEntity, cancellationToken);
            if (!validationResult.IsValid) throw new ValidationException("Ошибка валидации!", validationResult.Errors);
            await _authorRepository.Create(authorEntity);
            await _unitOfWork.Save(cancellationToken);
            return _mapper.Map<AuthorDto>(authorEntity);
        }
        catch (Exception ex)
        {
            throw new CreationException("Ошибка при создании автора!", ex);
        }
    }
}