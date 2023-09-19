using AutoMapper;
using Library.Application.Features.User;

namespace Library.Application.Features.CreateUser;

public class CreateUserMapper : Profile
{
	public CreateUserMapper()
	{
		CreateMap<CreateUserRequest, Domain.Entities.User>();
		CreateMap<Domain.Entities.User, CreateUserResponse>();
	}
}