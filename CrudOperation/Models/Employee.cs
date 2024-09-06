using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CrudOperation.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int ID { get; set; } 

        [Required(ErrorMessage ="Please Enter First Name")]
        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        [DisplayName("LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter your Age")]
        [DisplayName("Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        [DisplayName("Gender")]
        public string Gender{ get; set; }

        [Required(ErrorMessage = "Please Enter your Address")]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Your Phone Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
        ErrorMessage = "Entered phone format is not valid.")]
        [DisplayName("Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please Enter your Designation")]
        [DisplayName("Designation")]
        public string Designation { get; set; }


    }

}