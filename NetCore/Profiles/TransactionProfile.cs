using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace NetCore.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Entities.IncomeTransaction, Models.TransactionDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => $"{src.Category.Name}"));
            CreateMap<Entities.OutcomeTransaction, Models.TransactionDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => $"{src.Category.Name}"));

            CreateMap<Models.TransactionForCreationDto, Entities.IncomeTransaction>();
            CreateMap<Models.TransactionForCreationDto, Entities.OutcomeTransaction>();
            CreateMap<Models.TransactionForUpdateDto, Entities.TransactionBase>();
        }
    }
}
