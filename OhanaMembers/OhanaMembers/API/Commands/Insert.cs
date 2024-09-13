using MediatR;
using OhanaMembers.DB;
using OhanaMembers.DB.Models;

namespace OhanaMembers.API.Commands
{
    public class Insert
    {
        public class Request: IRequest<Member>
        {
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
                var member = new Member { Name = request.Name, Age = request.Age, Gender = request.Gender };

                _context.Members.Add(member);
                await _context.SaveChangesAsync(cancellationToken);

                return member;
            }
        }
    }
}
