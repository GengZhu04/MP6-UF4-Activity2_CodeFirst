using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP6_UF4_Activity2_CodeFirst.Model
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        [Column(TypeName = "INT(11)")]
        public int OrderNumber { get; set; }

        public DateTime OrderData { get; set; }

        public DateTime RequiredDate { get; set; }

        public DateTime ShippedDate { get; set; }

        [StringLength(15)]
        public string Status { get; set; }

        public string Comments { get; set; }


        [Column(TypeName = "INT(11)")]
        public int CustomerNumberId { get; set; }
        public Customers Customer { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
