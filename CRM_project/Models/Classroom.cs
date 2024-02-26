using System.ComponentModel.DataAnnotations;

namespace CRM_project.Models
{
    public class Classroom
    {
        [Key]
        public int CalssroomId { get; set; }
        public string ClassroomName { get; set; }

        public virtual IEnumerable<Exercise> Exercises { get; set; }
    }
}
