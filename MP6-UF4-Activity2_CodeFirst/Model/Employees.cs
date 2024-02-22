using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP6_UF4_Activity2_CodeFirst.Model
{
    [Table("Employees")]
    public class Employees
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int EmployeeNumber { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(10)]
        public string Extension { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(10)]
        public string OfficeCode { get; set; }
        public Offices Office { get; set; }

        [ForeignKey("EmployeesToReport")]
        [Column(TypeName = "int(11)")]
        public int ReportsTo { get; set; }
        public Employees EmployeesToReport { get; set; }

        [StringLength(50)]
        public string JobTitle { get; set; }

        public ICollection<Customers> Customers { get; set; }
    }
}
