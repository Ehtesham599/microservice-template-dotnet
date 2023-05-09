using Domain.Common;
using Domain.Entities;
using MediatR;

namespace AppCore.Application.User.Queries.Get
{
    public record GetRequest() : IRequest<EntityResponseModel>
    {

    }
}
