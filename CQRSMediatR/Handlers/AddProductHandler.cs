using CQRSMediatR.Commands;
using CQRSMediatR.Context;
using CQRSMediatR.Models.Entities;
using MediatR;

namespace CQRSMediatR.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly FakeProductData _productData;
        public AddProductHandler(FakeProductData productData) => _productData = productData;
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken) {
            await _productData.AddProduct(request.product);
            return request.product;
        }
    }
}
