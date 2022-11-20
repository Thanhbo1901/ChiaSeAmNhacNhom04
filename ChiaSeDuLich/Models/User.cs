using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChiaSeDuLich.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName{ get; set; }
        public string UserPass { get; set; }
        public int UserRole { get; set; }
        public string UserPhone { get; set; }
    }
}