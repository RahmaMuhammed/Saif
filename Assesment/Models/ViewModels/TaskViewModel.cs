using Assesment.Models.Entites;
using System.ComponentModel.DataAnnotations;

namespace Assesment.Models.ViewModels
{
    public class TaskViewModel
    {
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }

        public string Status { get; set; }

        public string Priority { get; set; }

        public DateTime DeadLine { get; set; }

        public int ProjectID { get; set; }

        public int TeamMemberID { get; set; }

        public IEnumerable<Project> projects { get; set; }

        public IEnumerable<TeamMember> teamMembers { get; set; }


    }
}
