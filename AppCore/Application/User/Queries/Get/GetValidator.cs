using FluentValidation;
using Infrastructure.Configuration;
using Microsoft.Extensions.Logging;

namespace AppCore.Application.User.Queries.Get
{
    public class GetValidator : AbstractValidator<GetRequest>
    {
        private readonly DatabaseContext _context;

        public GetValidator(ILogger<GetRequest> logger, DatabaseContext context)
        {
            _context = context;
        }
    }
}
