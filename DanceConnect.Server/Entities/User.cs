using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanceConnect.Server.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FullName { get; set; } = string.Empty;

        [ForeignKey(nameof(AppUser))]
        public int Id { get; set; }
        public ApplicationUser? AppUser { get; set; }
    }
}
