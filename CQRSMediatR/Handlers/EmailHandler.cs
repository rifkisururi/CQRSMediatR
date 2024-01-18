using CQRSMediatR.Context;
using CQRSMediatR.Notification;
using MediatR;

namespace CQRSMediatR.Handlers
{
    public class EmailHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeProductData _productData;
        public EmailHandler(FakeProductData productData) => _productData = productData;
        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _productData.EvenOccured(notification.Product, "Email sent");
            await Task.CompletedTask;
        }
    }
}
