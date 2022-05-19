using Domain.Db;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Context
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        private static bool _Created = false;
        public DataContext()
        {
            if (!_Created)
            {
                _Created = true;
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;DataBase=DigiKalaDBNewer;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TblBoon>().HasKey(a => new { a.ID, a.OrderID });

            modelBuilder.Entity<TblMessages>()
                .HasOne(a => a.TblUserAdmin)
                .WithMany(b => b.TblMessagesAdmin)
                .HasForeignKey(a => a.AdminID);

            modelBuilder.Entity<TblMessages>()
                .HasOne(a => a.TblUserClaint)
                .WithMany(b => b.TblMessagesClaint)
                .HasForeignKey(a => a.UserID);


            modelBuilder.Entity<TblAsks>().HasIndex(a => a.AskID)
                .HasName("IX_AskID");

            modelBuilder.Entity<TblBoon>().HasIndex(a => a.BoonGroupID)
                .HasName("IX_BoonGroupID");

            modelBuilder.Entity<TblCategory>().HasIndex(a => a.ParrentID)
                .HasName("IX_ParrentID");

            modelBuilder.Entity<TblCategory>().HasIndex(a => a.Title)
                .HasName("IX_Title");

            modelBuilder.Entity<TblComments>().HasIndex(a => a.Confirm)
                .HasName("IX_Confirm");

            modelBuilder.Entity<TblComments>().HasIndex(a => a.Read)
               .HasName("IX_Read");

            modelBuilder.Entity<TblLoginHistory>().HasIndex(a => a.CookieID)
               .HasName("IX_CookieID");

            modelBuilder.Entity<TblMessages>().HasIndex(a => a.Read)
               .HasName("IX_Read");

            modelBuilder.Entity<TblNoti>().HasIndex(a => a.Date)
               .HasName("IX_Date");

            modelBuilder.Entity<TblNoti>().HasIndex(a => a.Status)
               .HasName("IX_Status");

            modelBuilder.Entity<TblOrders>().HasIndex(a => a.BoonGroupID)
               .HasName("IX_BoonGroupID");

            modelBuilder.Entity<TblOrders>().HasIndex(a => a.ShopingCartGroupID)
               .HasName("IX_ShopingCartGroupID");

            modelBuilder.Entity<TblOrders>().HasIndex(a => a.Status)
               .HasName("IX_Status");

            modelBuilder.Entity<TblOrders>().HasIndex(a => a.BankGetNumber)
              .HasName("IX_BankGetNumber");

            modelBuilder.Entity<TblOrders>().HasIndex(a => a.BankTransNumber)
              .HasName("IX_BankTransNumber");

            modelBuilder.Entity<TblOrders>().HasIndex(a => a.PostBarCode)
              .HasName("IX_PostBarCode");

            modelBuilder.Entity<TblPrices>().HasIndex(a => a.Date)
             .HasName("IX_Date");

            modelBuilder.Entity<TblProducts>().HasIndex(a => a.TitleFa)
             .HasName("IX_TitleFa");

            modelBuilder.Entity<TblProducts>().HasIndex(a => a.TitleEn)
             .HasName("IX_TitleEn");

            modelBuilder.Entity<TblProducts>().HasIndex(a => a.Date)
            .HasName("IX_Date");

            modelBuilder.Entity<TblProducts>().HasIndex(a => a.Status)
            .HasName("IX_Status");

            modelBuilder.Entity<TblShopingCart>().HasIndex(a => a.ShopingCartGroupID)
            .HasName("IX_ShopingCartGroupID");

            modelBuilder.Entity<TblShopingCart>().HasIndex(a => a.CookieID)
            .HasName("IX_CookieID");

            modelBuilder.Entity<TblShopingCart>().HasIndex(a => a.Date)
                .HasName("IX_Date");

            modelBuilder.Entity<TblSlider>().HasIndex(a => a.Sort)
                .HasName("IX_Sort");

            modelBuilder.Entity<TblTopic>().HasIndex(a => a.ParrentID)
               .HasName("IX_ParrentID");

            modelBuilder.Entity<TblTopic>().HasIndex(a => a.Title)
               .HasName("IX_Title");
            modelBuilder.Entity<TblMenus>().HasIndex(a => a.Title)
               .HasName("IX_Title");

        }
        public DbSet<TblCategory> TblCategory { get; set; }
        public DbSet<TblServers> TblServers { get; set; }
        public DbSet<TblImage> TblImage { get; set; }
        public DbSet<TblGurunty> TblGurunty { get; set; }
        public DbSet<TblPrices> TblPrices { get; set; }
        public DbSet<TblProducts> TblProducts { get; set; }
        public DbSet<TblTopic> TblTopic { get; set; }
        public DbSet<TblPropertis> TblPropertis { get; set; }
        public DbSet<TblPropertis_Product> TblPropertis_Product { get; set; }
        public DbSet<TblTechnicalProp> TblTechnicalProp { get; set; }
        public DbSet<TblTechnicalProp_Products> TblTechnicalProp_Products { get; set; }
        public DbSet<TblBrands> TblBrands { get; set; }
        public DbSet<TblNewsLetter> TblNewsLetter { get; set; }
        public DbSet<TblSlider> TblSlider { get; set; }
        public DbSet<TblSettings> TblSettings { get; set; }
        public DbSet<TblShopingCart> TblShopingCart { get; set; }
        public DbSet<TblOrders> TblOrders { get; set; }
        public DbSet<TblTypePost> TblTypePost { get; set; }
        public DbSet<TblBoon> TblBoon { get; set; }
        public DbSet<TblMessages> TblMessages { get; set; }
        public DbSet<TblMenus> TblMenus { get; set; }
        public DbSet<TblException> TblExceptions { get; set; }
        public DbSet<TblFavo>  TblFavos { get; set; }
        public DbSet<TblPropertiseTitle> TblPropertiseTitle { get; set; }
        public DbSet<TblComments> TblComments { get; set; }
        public DbSet<TblAsks> TblAsks { get; set; }
        public DbSet<TblAccess> TblAccess { get; set; }
        public DbSet<TblUserAccess> TblUserAccess { get; set; }
    
    }

}
