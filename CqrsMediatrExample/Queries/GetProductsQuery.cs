using CqrsMediatrExample.Data;
using MediatR;
using System.Collections.Generic;

namespace CqrsMediatrExample.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
