using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lorence_Project.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int OrderID { get; set; }
        [MaxLength(128)]
        [Required]
        [Display(Name = "Sit number or description")]

        public string Sit { get; set; }
        [Required]
        [ForeignKey("Users")]
        public int UserID { get; set; }
        //[Column(TypeName = "datetime2")]
        //[Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date), Display(Name = "Date Created")]
        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }
        //[Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime? Date { get; set; }
        public bool? Arrived { get; set; }
        public bool? Approved { get; set; }

        //Navigation propeties
        public virtual User Users { get; set; }

    }
}