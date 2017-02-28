using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SignalRWebApp.Models
{
    public class VCBargContext : DbContext
    {
        const String DefaultConnectionName = "VanChuyenBargConnection";

        #region "ctor"

        public VCBargContext() : this(DefaultConnectionName)
        {
        }

        public VCBargContext(String sqlConnectionName) : base(String.Format("Name={0}", sqlConnectionName))
        {
        }

        #endregion

        #region Collections Definitions

        public DbSet<KhachHang> KhachHangs { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhachHang>()
                        .ToTable("KhachHang", "dbo")
                        .HasKey(t => t.id);
        }
    }
}