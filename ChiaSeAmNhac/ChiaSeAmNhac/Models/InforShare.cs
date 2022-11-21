using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChiaSeDuLich.Models
{
    [Table("InforShare")]
    public class InforShare
    {
        [Key]
        public int InforShareId { get; set; }
        [DisplayName("Tiêu đề chia sẻ")]
        public string InforShareTitle { get; set; }
        [DisplayName("Nội dung chia sẻ")]
        public string InforShareContent { get; set; }
        [DisplayName("Nguồn chia sẻ")]
        public string InforShareSource { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<Comment> OwnComments { get; set; }
        [NotMapped]
        public decimal RankAve { get; set; } = 0;
    }
}