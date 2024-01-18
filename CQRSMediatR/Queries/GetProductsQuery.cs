﻿using CQRSMediatR.Models.Entities;
using MediatR;

namespace CQRSMediatR.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
}
