using API.Dto;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        readonly IGenericRepository<Product> _productRepository;
        readonly IGenericRepository<ProductBrand> _brandRepository;
        readonly IGenericRepository<ProductType> _typeRepository;
        readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> productRepository,
            IGenericRepository<ProductBrand> productBrand,
            IGenericRepository<ProductType> productType,
            IMapper mapper
            )
        {
            _productRepository = productRepository;
            _brandRepository = productBrand;
            _typeRepository = productType;
            _mapper = mapper;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductResponse>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            var products = await _productRepository.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductResponse>>(products));
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetProducts(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productRepository.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductResponse>(product); 
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetBrands()
        {
            var products = await _brandRepository.ListAllAsync();
            return Ok(products);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetTypes()
        {
            var products = await _typeRepository.ListAllAsync();
            return Ok(products);
        }
    }
}
