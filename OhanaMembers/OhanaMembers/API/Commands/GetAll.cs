using Microsoft.EntityFrameworkCore;
using OhanaMembers.API.Tools;
using OhanaMembers.DB;
using OhanaMembers.DB.Models;

namespace OhanaMembers.API.Commands
{
    public class GetAll
    {
        public class Handler : IRequestHandler<List<Member>>
        {
            public async Task<List<Member>> Run()
            {
                var context = new MembersContext();
                var members = await context.Members.ToListAsync();

                return members;
            }
        }
    }
}
