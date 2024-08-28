using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkPractice.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Column("student_name",TypeName ="varchar(255)")]
        [Required]
        public string Name { get; set; }

        [Column("student_gender", TypeName = "varchar(20)")]
        [Required]
        public string Gender { get; set; }
        [Required]
        public int  Age { get; set; }
        [Required]
        public int Standard { get; set; }
    }
}
