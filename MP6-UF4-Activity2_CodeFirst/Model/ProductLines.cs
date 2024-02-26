using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP6_UF4_Activity2_CodeFirst.Model
{
    [Table("ProductLines")]
    public class ProductLines
    {
        [Key]
        [StringLength(50)]
        public string ProductLine { get; set; }

        [StringLength(4000)]
        public string TextDescription { get; set; }

        [Column(TypeName = "MEDIUMTEXT")]
        public string HtmlDescription { get; set; }

        [Column(TypeName = "MEDIUMBLOB")]
        public byte[]? Imatge { get; set; }
    }
}
