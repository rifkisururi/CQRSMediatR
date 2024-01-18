using CQRSMediatR.Models.Entities;
using MediatR;

namespace CQRSMediatR.Notification
{
    public record ProductAddedNotification(Product Product):INotification;
}
