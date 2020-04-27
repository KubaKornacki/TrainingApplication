using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App_v2.Models
{
    public class Dict
    {

        [Key]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Pole wymagane")]
        public string DictName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string textValue { get; set; }

        [Column(TypeName = "int")]
        public int intValue { get; set; }

        [Column(TypeName = "decimal")]
        public decimal decimalValue { get; set; }

        [Column(TypeName = "Datetime")]
        public DateTime DateTimeValue { get; set; }

    }
}
