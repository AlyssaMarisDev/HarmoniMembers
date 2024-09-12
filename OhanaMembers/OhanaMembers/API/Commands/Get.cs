using Microsoft.EntityFrameworkCore;
using OhanaMembers.DB;
using OhanaMembers.DB.Models;

namespace OhanaMembers.API.Commands
{
    public class Get
    {
        public class Command
        {
            public int Id { get; set; }
        }

        public async Task<Member> Run(Command command)
        {
            var context = new MembersContext();
            var member = await context.Members.Where(s => s.Id == command.Id).FirstOrDefaultAsync();

            if (member == null)
            {
                throw new KeyNotFoundException();
            }

            return member;
        }
    }
}
