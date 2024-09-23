using MediatR;
using Microsoft.EntityFrameworkCore;
using OhanaMembers.DB;
using OhanaMembers.DB.Models;

namespace OhanaMembers.API.Commands.Members
{
    public class GetAll
    {
        public class Request: IRequest<List<Member>> {}
        public class Handler(ILogger<Handler> logger, MembersContext context) : IRequestHandler<Request, List<Member>>
        {
            private readonly ILogger<Handler> _logger = logger;
            private readonly MembersContext _context = context;

            public async Task<List<Member>> Handle(Request request, CancellationToken cancellationToken)
            {
                var members = await _context.Members.ToListAsync(cancellationToken: cancellationToken);

                return members;
            }
        }
    }
}
