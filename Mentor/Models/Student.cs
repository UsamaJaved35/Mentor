using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mentor.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SId { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Length should not exceed 20 characters")]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Length should not exceed 20 characters")]
        public string ?LastName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(15,ErrorMessage = "PasswordRequiresNonAlphanumeric; PasswordRequiresLower;PasswordRequiresUpper")]
        public string ?Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password must match with confirmation password")]
        public string ?ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Enter Gender:")]
        [StringLength(10)]
        public string ?Gender { get; set; }
        [Required(ErrorMessage = "Enter Eduction:")]
        [StringLength(50)]
        public string ?Education { get; set; }
        [Required(ErrorMessage = "Enter Address:")]
        [StringLength(100)]
        public string ?Address { get; set; }
        [Required(ErrorMessage = "Enter Country:")]
        [StringLength(15)]
        public string ?Country { get; set; }
        [Required(ErrorMessage = "Enter City:")]
        [StringLength(20)]
        public string ?City { get; set; }
        [Required(ErrorMessage = "Enter Valid Phone Code:")]
        [StringLength(10)]
        public string ?PhoneCode { get; set; }
        [Required(ErrorMessage = "Enter  Valid Phone Number:")]
        [StringLength(20)]
        public string ?PhoneNumber { get; set; }
        [Required(ErrorMessage = "Enter valid Email:")]
        [EmailAddress]
        public string ?Email { get; set; }
        public string? ImagePath { get; set; }
        public virtual ICollection<Student_Tutor> StudentTutors { get; set; }
    }
}