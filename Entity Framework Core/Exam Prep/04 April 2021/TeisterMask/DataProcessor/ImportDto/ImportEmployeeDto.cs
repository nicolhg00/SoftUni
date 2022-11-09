using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TeisterMask.Common;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDto
    {
        [Required]
        [MinLength(GlobalConstants.EMPLOYEE_MIN_USERNAME)]
        [MaxLength(GlobalConstants.EMPLOYEE_USERNAME)]
        [RegularExpression(GlobalConstants.EMPLOYEE_USERNAME_REGEX)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.EMPLOYEE_PHONE_REGEX)]
        public string Phone { get; set; }
        public int[] Tasks { get; set; }
    }
}
