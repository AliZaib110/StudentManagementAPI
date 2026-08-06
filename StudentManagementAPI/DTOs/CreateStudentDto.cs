using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.DTOs
{
    public class CreateStudentDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Range(1, 100)]
        public int Age { get; set; }

        [Required]
        public string Course { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Address { get; set; } = string.Empty;


    }
}
