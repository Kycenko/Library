using AutoMapper;
using Library.Application.Queries.User;
using Library.Domain.Entities;

namespace Library.Application.MappingProfiles;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<CreateUserRequest, User>();
		CreateMap<User, CreateUserResponse>();
		CreateMap<User, GetUserResponse>();
	}
}