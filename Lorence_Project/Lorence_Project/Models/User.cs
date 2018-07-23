﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

public enum UserKind { Administrator = 1, Employee = 2, Client = 3}

namespace Lorence_Project.Models
{
    [Table("Users")]
    public class User
    {
        //User ID for the Users Table
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int UserID { get; set; }
        [Required]
        [Display(Name = "UserName")]
        [MaxLength(20)]
        [MinLength(3)]
        public string UserName { get; set; }
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        public UserKind userKind { get; set; }


        //Navigation Property
        public virtual ICollection<Order> Orders { get; set; }
    }
}