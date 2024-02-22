using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP6_UF4_Activity2_CodeFirst.Model
{
    [Table("Offices")]
    public class Offices
    {
        [Key]
        [StringLength(10)]
        public string OfficeCode { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string AddressLine1 { get; set; }

        [StringLength(50)]
        public string AddressLine2 { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(15)]
        public string PostalCode { get; set; }

        [StringLength(10)]
        public string Territory { get; set; }

        public ICollection<Employees> Employees { get; set; }
    }
}
