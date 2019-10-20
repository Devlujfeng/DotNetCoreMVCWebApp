using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FirstApp.Core
{
    public class StudentsDS
    {
        [Required (ErrorMessage = "Student ID is required.")]
        [DataType(DataType.Text)]
        [Display(Name = "Student ID")]
        public int StudentID { get; set; }


        [Required(ErrorMessage = "Student name is required.")]
        [Display(Name = "Student name")]
        public string StudentName { get; set; }


        [Required(ErrorMessage = "Student Amount is required.")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

    }
}
