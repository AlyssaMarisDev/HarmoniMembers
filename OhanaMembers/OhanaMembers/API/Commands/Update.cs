using OhanaMembers.DB.Models;
using OhanaMembers.DB;
using Microsoft.EntityFrameworkCore;
using OhanaMembers.API.Tools;

namespace OhanaMembers.API.Commands
{
    public class Update
    {
        public class Parameters
        {
            public required int Id { get; set; }
            public required string Name { get; set; }
            public required int Age { get; set; }
            public string Gender { get; set; } = "Enby";
        }


        public class Handler : IRequestHandler<Member, Parameters>
        {
            public async Task<Member> Run(Parameters par)
            {
                var context = new MembersContext();
                var member = await context.Members.FirstOrDefaultAsync(s => s.Id == par.Id) ?? throw new KeyNotFoundException();

                member.Name = par.Name;
                member.Age = par.Age;
                member.Gender = par.Gender;

                await context.SaveChangesAsync();

                return member;
            }
        }
    }
}
