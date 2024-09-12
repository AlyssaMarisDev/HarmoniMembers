using Microsoft.EntityFrameworkCore;
using OhanaMembers.DB;
using OhanaMembers.DB.Models;

namespace OhanaMembers.API.Commands
{
    public class GetAll
    {
        public async Task<List<Member>> Run()
        {
            var context = new MembersContext();
            var members = await context.Members.ToListAsync();

            return members;
        }
    }
}
