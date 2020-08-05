using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Product_Quadra.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="กุณากรอกชื่อสินค้า!")]
        [MaxLength(100)]
        [Display(Name ="ชื่อสินค้า :")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name ="รูปสินค้า :")]
        public string Imag { get; set; }

        [Required(ErrorMessage ="กรุณากรอกรายละเอียด")]
        [MaxLength(100)]
        [Display(Name ="รายละเอียดสินค้า :")]
        public string Title { get; set; }

        [Required]
        [MaxLength]
        [Display(Name ="อัพเดทล่าสุด :")]
        public string DateTimeNow { get; set; }
    }
}
