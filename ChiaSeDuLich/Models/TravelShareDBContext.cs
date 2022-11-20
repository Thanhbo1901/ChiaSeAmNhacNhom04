using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChiaSeDuLich.Models
{
    public class TravelShareDBContext : DbContext
    {
        public TravelShareDBContext() : base("name=chuoiKN") { }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<InforShare> InforShares { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rank> Ranks { get; set; }
    }
}