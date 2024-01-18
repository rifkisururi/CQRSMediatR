using CQRSMediatR.Context;
using CQRSMediatR.Notification;
using MediatR;

namespace CQRSMediatR.Handlers
{
    public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeProductData _productData;
        public CacheInvalidationHandler(FakeProductData productData) => _productData = productData;
        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _productData.EvenOccured(notification.Product, "cache invaldated");
            await Task.CompletedTask;
        }
    }
}
