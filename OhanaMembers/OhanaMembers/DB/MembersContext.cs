using Microsoft.EntityFrameworkCore;
using OhanaMembers.DB.Models;

namespace OhanaMembers.DB
{
    public class MembersContext : DbContext
    {
        static readonly string connectionString = "Server=localhost; User ID=root; Password=development; Database=OhanaMembers";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Member> Members { get; set; }
    }
}
