namespace OhanaMembers.API.Commands
{
    public class Get
    {
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

        public async Task<Member> Run(int id)
        {
            return new Member(id, "Brandon", 37, "Male");
        }
    }
}
