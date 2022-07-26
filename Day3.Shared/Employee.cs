using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3.Shared
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3, ErrorMessage = "Name must be greater than 3 char")]
        public string Name { get; set; }

        [Required]
        [Range(2000, 7000)]
        public int Salary { get; set; }

        [Required]
        [RegularExpression(@"^\w+\.(png|jpg)$")]
        public string Image { get; set; }

        [ForeignKey("Department")]
        public int Dept_Id { get; set; }

        public virtual Department Department { get; set; }

        public override string ToString()
        {
            return $"Name:{Name} - Salary : {Salary}";
        }
    }
}
