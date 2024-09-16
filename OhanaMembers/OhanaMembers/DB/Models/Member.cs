using System.ComponentModel.DataAnnotations;

namespace OhanaMembers.DB.Models
{
    public class Member
    {
        public int Id { get; set; }

        [StringLength(50)]
        public required string Name { get; set; }

        public required int Age { get; set; }

        [StringLength(20)]
        public required string Gender { get; set; }

        // Login
        [StringLength(50)]
        public required string Email { get; set; }

        [StringLength(50)]
        public required string Password { get; set; }
    }
}
