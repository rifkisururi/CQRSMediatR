using CQRSMediatR.Context;
using CQRSMediatR.Models.Entities;
using CQRSMediatR.Queries;
using MediatR;

namespace CQRSMediatR.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly FakeProductData _productData;

        //public GetProductsHandler(FakeProductData productData)
        //{
        //    _productData = productData;
        //}
        public GetProductsHandler(FakeProductData productData) => _productData = productData;
        //public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        //{
        //    return await _productData.GetAllProductsSimple();
        //}

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken) => 
            await _productData.GetAllProductsSimple();
    }
}
