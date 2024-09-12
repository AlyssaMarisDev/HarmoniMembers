namespace OhanaMembers.API.Commands
{
    public class Get
    {
        public class Command
        {
            public int Id { get; set; }
        }

        public class Member 
        {
            public Member(int id, string name, int age, string gender)
            {
                Id = id;
                Name = name;
                Age = age;
                Gender = gender;
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Gender { get; set; }
        }

        public async Task<Member> Run(Command command)
        {
            return new Member(command.Id, "Brandon", 37, "Male");
        }
    }
}
