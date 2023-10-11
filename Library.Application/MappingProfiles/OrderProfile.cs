using AutoMapper;
using Library.Application.DTO_s.Order;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<Order, UpdateOrderDto>();
            CreateMap<UpdateOrderDto, Order>();
            CreateMap<CreateOrderDto, Order>();
        }
    }
}
