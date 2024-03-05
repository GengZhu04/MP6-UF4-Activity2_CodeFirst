using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP6_UF4_Activity2_CodeFirst.Model
{
    [Table("Products")]
    public class Products
    {
        [Key]
        [StringLength(15)]
        public string ProductCode { get; set; }

        [Required]
        [StringLength(70)]
        public string ProductName { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string ProductLineId { get; set; }
        public ProductLines ProductLine { get; set; }

        [StringLength(10)]
        public string ProductScale { get; set; }


        [StringLength(50)]
        public string ProductVendor { get; set; }

        [Column(TypeName = "TEXT")]
        public string ProductDescription { get; set; }


        public short QuantityInStock { get; set; }

        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal BuyPrice { get; set; }

        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal MSRP { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }

        public ICollection<SpecialPriceList> SpecialPricesList { get; set; }
    }
}
