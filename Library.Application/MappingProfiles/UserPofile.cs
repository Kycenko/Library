using AutoMapper;
using Library.Application.DTO_s.User;
using Library.Domain.Entities;

namespace Library.Application.MappingProfiles;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<Domain.Entities.User, UserDto>();
		CreateMap<CreateUserDto, Domain.Entities.User>();
		CreateMap<UpdateUserDto, Domain.Entities.User>();
		CreateMap<Domain.Entities.User, UpdateUserDto>();
	}
}