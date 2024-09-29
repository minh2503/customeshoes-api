﻿using App.Entity.DTO;
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

		#region App
		public DbSet<App_UserDetailDTO> App_UserDetails { get; set; }
		public DbSet<App_BrandDTO> App_Brands { get; set; }
		public DbSet<App_ShoesDTO> App_Shoes { get; set; }
		public DbSet<App_ShoesImagesDTO> App_ShoesImages { get; set; }
		public DbSet<App_OrderDTO> App_Orders { get; set; }
		public DbSet<App_OrderItemsDTO> App_OrderItems { get; set; }
		#endregion


		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<App_OrderItemsDTO>(x =>
			{
				x.ToTable("App_OrderItems");
				x.HasKey(x => x.Id);
			});

			modelBuilder.Entity<App_OrderDTO>(x =>
			{
				x.ToTable("App_Order");
				x.HasKey(x => x.Id);
			});

			modelBuilder.Entity<App_ShoesImagesDTO>(x =>
			{
				x.ToTable("App_ShoesImages");
				x.HasKey(x => x.Id);
			});

			modelBuilder.Entity<App_ShoesDTO>(x =>
            {
                x.ToTable("App_Shoes");
                x.HasKey(x => x.Id);
            });

            modelBuilder.Entity<App_BrandDTO>(x =>
            {
                x.ToTable("App_Brand");
                x.HasKey("Id");
            });
            modelBuilder.Entity<App_UserDetailDTO>(b =>
            {
                b.ToTable("App_UserDetails");
                b.HasKey(x => x.Id);
            });
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

