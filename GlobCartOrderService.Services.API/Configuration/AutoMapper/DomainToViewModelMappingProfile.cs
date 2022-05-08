using AutoMapper;
using GlobCartOrderService.Domain.Models;
using GlobCartOrderService.Services.API.Models;

namespace GlobCartOrderService.Services.API.Configuration.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ICollection<Product>, ProductViewModel>();
            CreateMap<Product, CreateProductViewModel>();
            CreateMap<Product, UpdateProductViewModel>();
            CreateMap<Product, DeleteProductViewModel>();
        }
    }
}
