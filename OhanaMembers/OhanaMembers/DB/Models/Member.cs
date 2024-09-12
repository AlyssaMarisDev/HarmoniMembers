namespace OhanaMembers.DB.Models
{
    public class Member
    {
        public Member(string name, int age, string gender = "Enby")
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
