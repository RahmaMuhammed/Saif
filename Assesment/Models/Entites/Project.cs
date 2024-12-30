using System.ComponentModel.DataAnnotations;

namespace Assesment.Models.Entites
{
    public class Project
    {

        public int ProjectID { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<Tasks> Tasks { get; set; }


    }
}
