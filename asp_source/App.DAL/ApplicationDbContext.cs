using App.Entity.DTO;
using App.Entity.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Authentication.ExtendedProtection;
using TFU.Models.IdentityModels;

namespace App.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public void CreateSchema(ModelBuilder builder)
        {
            OnModelCreating(builder);
        }

        #region Menu
        public DbSet<SYS_MenuDTO> SYS_Menus { get; set; }
        public DbSet<SYS_MappingMenuActionDTO> SYS_MappingMenuActions { get; set; }
        public DbSet<RoleMenuDTO> RoleMenus { get; set; }
        public DbSet<SYS_ActionDTO> SYS_Actions { get; set; }
        #endregion

        #region Location
        public DbSet<SHIPDistrictDTO> ShipDistrict { get; set; }
        public DbSet<SHIPProvinceDTO> ShipProvince { get; set; }
        public DbSet<SHIPWardDTO> ShipWard { get; set; }
        #endregion

        public DbSet<App_MuscleDTO> App_Muscles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<SHIPDistrictDTO>(b =>
            {
                b.ToTable("SHIP_District");
                b.HasKey(x => x.Id);
            });

            modelBuilder.Entity<SHIPProvinceDTO>(b =>
            {
                b.ToTable("SHIP_Province");
                b.HasKey(x => x.Id);
            });

            modelBuilder.Entity<SHIPWardDTO>(b =>
            {
                b.ToTable("SHIP_Ward");
                b.HasKey(x => x.Id);
            });

            modelBuilder.Entity<App_MuscleDTO>(b =>
            {
                b.ToTable("App_Muscle");
                b.HasKey(x => x.Id);
            });

            modelBuilder.Entity<SYS_MappingMenuActionDTO>(b =>
            {
                b.ToTable("SYS_MappingMenuActions");
                b.HasKey(m => new { m.MenuCode, m.ActionCode });
            });
            modelBuilder.Entity<SYS_MenuDTO>(b =>
            {
                b.ToTable("SYS_Menus");
                b.HasKey(m => m.Id);
            });
            modelBuilder.Entity<SYS_ActionDTO>(b =>
            {
                b.ToTable("SYS_Actions");
                b.HasKey(m => m.Id);
            });
            modelBuilder.Entity<RoleMenuDTO>(b =>
            {
                b.ToTable("TFU_RoleMenus");
                b.HasKey(m => new { m.RoleId, m.MenuCode });
            });
        }
    }
}

