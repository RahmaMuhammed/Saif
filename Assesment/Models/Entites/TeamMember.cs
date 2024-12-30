using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Assesment.Models.Entites
{
    public class TeamMember
    {

        public int TeamMemberID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Role { get; set; }

        public IEnumerable<Tasks> Tasks { get; set; }

    }
}
