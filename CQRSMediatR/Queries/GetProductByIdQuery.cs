using CQRSMediatR.Models.Entities;
using MediatR;

namespace CQRSMediatR.Queries
{
    public record GetProductByIdQuery(int id) : IRequest<Product>;
}
