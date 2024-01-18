using CQRSMediatR.Commands;
using CQRSMediatR.Models.Entities;
using CQRSMediatR.Notification;
using CQRSMediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatR.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;
        public ProductsController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
            _publisher = publisher;
        }

        //public ProductsController(ISender sender) => _sender = sender;

        [HttpGet]
        public async Task<ActionResult> getProduct() {
            var product = await _sender.Send(new GetProductsQuery());
            return Ok(product);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _sender.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product) {
            var productToReturn = await _sender.Send(new AddProductCommand(product));
            await _publisher.Publish(new ProductAddedNotification(productToReturn));
            return CreatedAtRoute("GetProductById", new { id = product.Id }, productToReturn);
        }
    }
}
