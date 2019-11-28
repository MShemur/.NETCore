using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace NetCore.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Entities.IncomeCategory, Models.CategoryDto>();
            CreateMap<Entities.OutcomeCategory, Models.CategoryDto>();

            CreateMap<Models.CategoryForCreationDto, Entities.IncomeCategory>();
            CreateMap<Models.CategoryForCreationDto, Entities.OutcomeCategory>();
            CreateMap<Models.CategoryForUpdateDto, Entities.CategoryBase>();
        }

    }
}
