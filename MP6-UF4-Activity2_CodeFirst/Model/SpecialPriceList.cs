using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP6_UF4_Activity2_CodeFirst.Model
{
    public class SpecialPriceList
    {
        [Column(TypeName = "int(11)")]
        public int CustomerNumber { get; set; }
        public Customers Customer { get; set; }

        [StringLength(15)]
        public string ProductCode { get; set; }
        public Products Product { get; set; }

        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal SpecialPrice { get; set; }
    }
}
