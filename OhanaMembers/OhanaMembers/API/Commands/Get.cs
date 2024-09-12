using Microsoft.EntityFrameworkCore;
using OhanaMembers.API.Tools;
using OhanaMembers.DB;
using OhanaMembers.DB.Models;

namespace OhanaMembers.API.Commands
{
    public class Get
    {
        public class Parameters
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Member, Parameters>
        {
            public async Task<Member> Run(Parameters parameters)
            {
                var context = new MembersContext();
                var member = await context
                    .Members
                    .Where(s => s.Id == parameters.Id)
                    .Select(s => new Member
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Age = s.Age,
                        Gender = s.Gender,
                    })
                    .FirstOrDefaultAsync()
                    ?? throw new KeyNotFoundException();

                return member;
            }
        }
    }
}
