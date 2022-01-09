using API.Dto;
using AutoMapper;
using Core.Entities;

namespace API.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Product, ProductResponse>()
                .ForMember(d => d.Brand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.Type, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
