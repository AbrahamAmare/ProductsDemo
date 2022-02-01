using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Data.DTO.Products;
using ProductAPI.Data.Models;

namespace ProductAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        // TODO : use a Filter or An extexsion method remove repeated code

        // TODO: Automapper

        public ProductsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("get-products")]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            var productsView=  _mapper.Map<IEnumerable<ProductResponse>>(products);
            return Ok(productsView);
        }

        [HttpGet("get-product/{id}")]
        public async Task<ActionResult<ProductResponse>> GetProduct(Guid id)
        {

            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound("product with the id name is not found");
            }

            var productView = _mapper.Map<ProductResponse>(product);
            return Ok(productView);
        }


        [HttpGet("get-total-count-of-products")]
        public async Task<IActionResult> GetTotalCount()
        {
            var productsCount = await _context.Products.CountAsync();
            return Ok(productsCount);
        }

        [HttpPost("create-product")]
        public async Task<ActionResult<Product>> CreateProduct(ProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            /*var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CreateAt = DateTime.Now.Date,
            };*/


            // Using Automapper

            var product = _mapper.Map<Product>(request);
            product.CreateAt = DateTime.UtcNow.Date;

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            var productView = _mapper.Map<ProductResponse>(product);
            return CreatedAtAction("GetProduct", new { id = product.Id }, productView);
        }


        [HttpPut("edit-product/{id}")]
        public async Task<IActionResult> EditProduct(Guid id, ProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == id);

            if (product is null)
            {
                return BadRequest("product with the given id is not found");
            }

            /*product.Name = request.Name;
            product.Description = request.Description;
            product.Price = request.Price;
            product.UpdateAt = DateTime.Now.Date;*/

            // Using Automapper

            _mapper.Map(request, product);
            product.UpdateAt = DateTime.UtcNow.Date;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound("product with the given id is not found");
            }

            // Todo: Use soft delete to archive 

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
