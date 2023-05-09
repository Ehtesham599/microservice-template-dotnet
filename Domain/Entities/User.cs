using Domain.Seed;

namespace Domain.Entities
{
    public class User : AuditEntity<uint>
    {
        public User()
        {
        }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}