using CqrsMediatrExample.Commands;
using CqrsMediatrExample.Data;
using CqrsMediatrExample.Handlers;
using CqrsMediatrExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CqrsMediatrExample.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator_;

        public ProductsController(IMediator mediator)
        {
            mediator_ = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await mediator_.Send(new GetProductsQuery());

            return Ok(products);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var product = await mediator_.Send(new GetProductByIdQuery { Id = id });

            if(product != null)
            {
                return Ok(product);
            }
            return NotFound(id);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            await mediator_.Send(new AddProductCommand { Product = product });
            return StatusCode(201);
        }

    }
}
