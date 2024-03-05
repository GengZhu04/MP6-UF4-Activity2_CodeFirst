using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP6_UF4_Activity2_CodeFirst.Model
{
    [Table("Customers")]
    public class Customers
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int CustomerNumber { get; set; }

        [StringLength(50)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string ContactLastName { get; set; }

        [StringLength(50)]
        public string ContactFirstName { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string AddressLine1 { get; set; }

        [StringLength(50)]
        public string AddressLine2 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(15)]
        public string? PostalCode { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [Column(TypeName = "int(11)")]
        public int? SalesRepEmployeeNumber { get; set; }
        public Employees? Employee { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? CreditLimit { get; set; }

        public ICollection<Payments> Payments { get; set; }

        public ICollection<Orders> Orders { get; set; }

        public ICollection<SpecialPriceList> SpecialPricesList { get; set; }
    }
}
