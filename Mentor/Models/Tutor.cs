using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tutor_Finder.Models
{
    public partial class Tutor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //MODEL VALIDATIONS
        [Required(ErrorMessage = "Enter FirstName:")]
        [StringLength(50)]
        public string ?FirstName { get; set; }
        [Required(ErrorMessage = "Enter LastName:")]
        [StringLength(50)]
        public string ?LastName { get; set; }
        [Required(ErrorMessage = "Enter Password:")]
        [StringLength(30)]
        public string ?Password { get; set; }
        [Required(ErrorMessage = "Enter gender:")]
        [StringLength(6)]
        public string ?Gender { get; set; }
        [Required(ErrorMessage = "Enter Qualification:")]
        [StringLength(30)]
        public string ?Qualification { get; set; }
        [Required(ErrorMessage = "Enter Qualification Specification:")]
        [StringLength(50)]
        public string ?QualificationSpec { get; set; }
        [Required(ErrorMessage = "Enter Experience:")]
        [StringLength(20)]
        public string ?Experience { get; set; }
        [Required(ErrorMessage = "Enter Street Address:")]
        [StringLength(100)]
        public string ?Address { get; set; }
        [Required(ErrorMessage = "Enter City:")]
        [StringLength(20)]
        public string ?City { get; set; }
        [Required(ErrorMessage = "Enter Country:")]
        [StringLength(20)]
        public string ?Country { get; set; }
        [Required(ErrorMessage = "Enter Phone code:")]
        [StringLength(10)]
        public string ?PhoneCode { get; set; }
        [Required(ErrorMessage = "Enter Phone Number:")]
        [StringLength(20)]
        public string ?PhoneNumber { get; set; }
        [Required(ErrorMessage = "Enter Email:")]
        [StringLength(50)]
        public string ?Email { get; set; }
        [Required(ErrorMessage = "Enter mode of teaching:")]
        [StringLength(10)]
        public string ?Mode { get; set; }
        public bool? Availability { get; set; }
        public bool? Status { get; set; } = false;
        [Required(ErrorMessage = "Enter Subject#1 name:")]
        [StringLength(30)]
        public string ?Subject1 { get; set; }
        public string ?Subject2 { get; set; }
        [Required(ErrorMessage = "Enter Subject#1 Fee:")]
        [StringLength(10)]
        public double? Fee1 { get; set; }
        public double? Fee2 { get; set; }
        public string ?ImagePath { get; set; }
    }
}