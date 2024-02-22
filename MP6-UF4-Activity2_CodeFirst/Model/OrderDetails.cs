using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP6_UF4_Activity2_CodeFirst.Model
{
    [Table("OrderDetails")]
    public class OrderDetails
    {

        [Column(TypeName = "INT(11)")]
        public int OrderNumber { get; set; }
        public Orders Orders { get; set; }

        [StringLength(15)]
        public string ProductCode { get; set; }
        public Products Product { get; set; }

        [Column(TypeName = "INT(11)")]
        public int QuantityOrdered { get; set; }

        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal PriceEach { get; set; }
        public short OrderLineNumber { get; set; }
    }
}
