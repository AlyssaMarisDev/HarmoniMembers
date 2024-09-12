using OhanaMembers.DB;
using OhanaMembers.DB.Models;

namespace OhanaMembers.API.Commands
{
    public class Insert
    {
        public class Command
        {
            public required string Name { get; set; }
            public required int Age { get; set; }
            public string Gender { get; set; } = "Enby";
        }

        public async Task<Member> Run(Command command)
        {
            var member = new Member { Name = command.Name, Age = command.Age, Gender = command.Gender };
            var context = new MembersContext();

            context.Members.Add(member);
            await context.SaveChangesAsync();

            return member;
        }
    }
}
