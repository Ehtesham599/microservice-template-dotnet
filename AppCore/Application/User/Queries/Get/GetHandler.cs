using AutoMapper;
using Domain.Common;
using Domain.Exceptions;
using Infrastructure.Configuration;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AppCore.Application.User.Queries.Get
{
    public class GetHandler : IRequestHandler<GetRequest, EntityResponseModel>
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public GetHandler(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _httpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
        }

        public async Task<EntityResponseModel> Handle(GetRequest request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.ToListAsync(cancellationToken: cancellationToken);

            return new EntityResponseModel()
            {
                Data = users
            };
        }
            
    }

}
