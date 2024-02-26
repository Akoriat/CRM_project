using System.ComponentModel.DataAnnotations;
using System.IO;

namespace CRM_project.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set;}
        public string StudentSurname { get; set;}
        public string StudentPatronymic { get; set;}
        public string RecordBook { get; set;}

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
