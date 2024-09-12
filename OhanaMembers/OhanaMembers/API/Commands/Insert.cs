using OhanaMembers.DB;
using OhanaMembers.DB.Models;

namespace OhanaMembers.API.Commands
{
    public class Insert
    {
        public class Parameters
        {
            public required string Name { get; set; }
            public required int Age { get; set; }
            public string Gender { get; set; } = "Enby";
        }

        public async Task<Member> Run(Parameters par)
        {
            var member = new Member { Name = par.Name, Age = par.Age, Gender = par.Gender };
            var context = new MembersContext();

            context.Members.Add(member);
            await context.SaveChangesAsync();

            return member;
        }
    }
}
