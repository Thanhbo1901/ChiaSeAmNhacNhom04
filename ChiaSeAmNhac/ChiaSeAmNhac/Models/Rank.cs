using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChiaSeDuLich.Models
{
    [Table("Rank")]
    public class Rank
    {
        [Key]
        public int RankId { get; set; }
        public int InforShareId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Value { get; set; }
    }
}