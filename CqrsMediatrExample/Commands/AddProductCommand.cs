using CqrsMediatrExample.Data;
using MediatR;

namespace CqrsMediatrExample.Commands
{
    public class AddProductCommand : IRequest
    {
        public Product Product { get; set; }
    }
}
