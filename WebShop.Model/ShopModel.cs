namespace WebShop.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopModel : DbContext
    {
        public ShopModel()
            : base("name=ShopModel")
        {
        }

        public virtual DbSet<SysCompany> Companies { get; set; }
        public virtual DbSet<SysUser> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysCompany>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);
        }
    }
}
