using System.ComponentModel.DataAnnotations;

namespace Assesment.Models.Entites
{
    public class Tasks
    {

        public int TasksID { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        
        public string Status { get; set; }

        public string Priority { get; set; }

        public DateTime DeadLine { get; set; }

        public int ProjectID { get; set; }

        public int TeamMemberID { get; set; }

        public Project Project { get; set; }

        public TeamMember TeamMember { get; set; }
    }
}
