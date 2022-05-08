using AutoMapper;
using GlobCartOrderService.Domain.Interfaces;
using GlobCartOrderService.Domain.Models;
using GlobCartOrderService.Services.API.Models;
using GlobCartOrderService.Services.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GlobCartOrderService.Services.API.Controllers.V1
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public readonly IMapper _mapper;
        public readonly ILogger<ProductController> _logger;

        public ProductController(IProductRepository productRepository, IMapper mapper, ILogger<ProductController> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;

        }

        [AllowAnonymous]
        [HttpGet]
        public ICollection<ProductViewModel> Get()
        {
            _logger.LogInformation("Retornando lista de produtos completa");
            var products = _productRepository.GetProducts();
            if (products.Count > 10)
            {
                _logger.LogWarning("Possível problema de performance. Quantidade grande de produtos!");
            }
            return _mapper.Map<ICollection<ProductViewModel>>(products);
        }

        [AllowAnonymous]
        [HttpGet("{productName}")]
        [Produces(typeof(ProductViewModel))]
        public IActionResult Get([FromRoute] string productName)
        {
            var product = _productRepository.GetProductByName(productName);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpPost]
        [ProducesResponseType(typeof(ProductViewModel), 201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        [SwaggerOperation("Enpoint responsible for creating a new product", "This endpoint is responsible for receving and saving the product data in the database.")]
        [SwaggerResponse(201, "Product sucessfully created", typeof(Product), "application/json")]
        public IActionResult Create([FromBody] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productResult = _productRepository.CreateProduct(_mapper.Map<Product>(product));
                return Created($"api/products/{productResult.Model.productId}", _mapper.Map<ProductViewModel>(productResult.Model));
            }

            return BadRequest(ModelState);
        }

        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateProductViewModel), 200)]
        public IActionResult Update([FromRoute]string id, UpdateProductViewModel product)
        {
            if (id == null)
            {
                return NotFound();
            }

            product.UpdatedAt = DateTime.Now;

            var productUpdated = _productRepository.UpdateProduct(id, _mapper.Map<Product>(product));

            return Ok(productUpdated);
        }

        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok("Produto " + id + " deletado");
        }
    }
}
