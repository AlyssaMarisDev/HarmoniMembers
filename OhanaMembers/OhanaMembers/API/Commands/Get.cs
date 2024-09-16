using MediatR;
using Microsoft.EntityFrameworkCore;
using OhanaMembers.DB;
using OhanaMembers.DB.Models;

namespace OhanaMembers.API.Commands
{
    public class Get
    {
        public class Request: IRequest<Member>
        {
            public int Id { get; set; }
        }

        public class Handler(ILogger<Handler> logger, MembersContext context) : IRequestHandler<Request, Member>
        {
            private readonly ILogger<Handler> _logger = logger;
            private readonly MembersContext _context = context;

            public async Task<Member> Handle(Request request, CancellationToken cancellationToken)
            {
                var member = await _context
                    .Members
                    .Where(s => s.Id == request.Id)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken)
                    ?? throw new KeyNotFoundException();

                return member;
            }
        }
    }
}
