using AutoMapper;
using Library.Application.DTO_s.Publisher;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.MappingProfiles
{
    public class PublisherProfile : Profile
    {
        public PublisherProfile()
        {
            CreateMap<Publisher, PublisherDto>();
            CreateMap<Publisher, UpdatePublisherDto>();
            CreateMap<CreatePublisherDto, PublisherDto>();
            CreateMap<UpdatePublisherDto, PublisherDto>();
        }
    }
}
