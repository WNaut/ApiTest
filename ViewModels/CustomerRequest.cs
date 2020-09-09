using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BHDTest.ViewModels
{
    public class CustomerRequest
    {
        [Required]
        [MaxLength(14, ErrorMessage = "The field {0} must have more than 14 digits")]
        public string DocumentNumber { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public decimal CreditLimit { get; set; }
    }
}
