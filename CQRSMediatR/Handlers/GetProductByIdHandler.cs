using CQRSMediatR.Context;
using CQRSMediatR.Models.Entities;
using CQRSMediatR.Queries;
using MediatR;

namespace CQRSMediatR.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly FakeProductData _productData;
        public GetProductByIdHandler(FakeProductData productData) => _productData = productData;

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) => await _productData.GetProductById(request.id);
    }
}
