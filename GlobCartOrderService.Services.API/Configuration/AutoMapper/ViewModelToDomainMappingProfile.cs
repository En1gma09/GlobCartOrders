using AutoMapper;
using GlobCartOrderService.Domain.Models;
using GlobCartOrderService.Services.API.Models;

namespace GlobCartOrderService.Services.API.Configuration.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CreateUserViewModel, User>();
            CreateMap<ProductViewModel, Product>();
        }
    }
}
