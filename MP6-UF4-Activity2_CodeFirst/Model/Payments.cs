using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP6_UF4_Activity2_CodeFirst.Model
{
    [Table("Payments")]
    public class Payments
    {
        [Column(TypeName = "int(11)")]
        public int CustomerNumber { get; set; }
        public Customers Customer { get; set; }

        [StringLength(50)]
        public string CheckNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime PaymentDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }
    }
}
