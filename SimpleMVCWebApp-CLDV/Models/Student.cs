using System.ComponentModel.DataAnnotations;

namespace SimpleMVCWebApp_CLDV.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Grade is required")]
        public string Grade { get; set; }
    }
}
