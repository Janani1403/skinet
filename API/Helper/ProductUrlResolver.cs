using API.Dto;
using AutoMapper;
using Core.Entities;

namespace API.Helper
{
    public class ProductUrlResolver : IValueResolver<Product, ProductResponse, string>
    {
        IConfiguration _configuration;
        public ProductUrlResolver(IConfiguration configuration) {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductResponse destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl)) {
                return _configuration["ApiUrl"] + source.PictureUrl;
            }
            return "";
        }
    }
}
