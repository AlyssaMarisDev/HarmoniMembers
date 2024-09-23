using OhanaMembers.DB.Models;
using OhanaMembers.DB;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace OhanaMembers.API.Commands.Members
{
    public class Update
    {
        public class Request: IRequest<Member>
        {
            public required int Id { get; set; }
            public required string Name { get; set; }
            public required int Age { get; set; }
            public string Gender { get; set; } = "Enby";
        }

        public class Handler(ILogger<Handler> logger, MembersContext context) : IRequestHandler<Request, Member>
        {
            private readonly ILogger<Handler> _logger = logger;
            private readonly MembersContext _context = context;

            public async Task<Member> Handle(Request request, CancellationToken cancellationToken)
            {
                var member = await _context.Members.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken: cancellationToken)
                    ?? throw new KeyNotFoundException();

                member.Name = request.Name;
                member.Age = request.Age;
                member.Gender = request.Gender;

                await _context.SaveChangesAsync(cancellationToken);

                return member;
            }
        }
    }
}
