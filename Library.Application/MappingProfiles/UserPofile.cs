using AutoMapper;
using Library.Application.User.Commands;
using Library.Application.User.Queries;


namespace Library.Application.MappingProfiles;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<Domain.Entities.User, GetUserById>();
		CreateMap<Domain.Entities.User, GetAllUsers>();
		CreateMap<CreateUser, Domain.Entities.User>();
		CreateMap<Domain.Entities.User, UpdateUser>();
	}
}