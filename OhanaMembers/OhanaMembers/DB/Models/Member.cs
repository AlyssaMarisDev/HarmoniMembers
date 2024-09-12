namespace OhanaMembers.DB.Models
{
    public class Member
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required string Gender { get; set; }
    }
}
