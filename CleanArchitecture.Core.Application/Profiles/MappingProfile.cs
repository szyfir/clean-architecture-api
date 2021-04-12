using AutoMapper;
using CleanArchitecture.Core.Application.Features.Orders.Queries.GetAllSalesOrder;
using CleanArchitecture.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SalesOrder, SalesOrderDto>();
        }
    }
}
