USE [master]
GO
/****** Object:  Database [TFU_GLocalShoes]    Script Date: 10/9/2024 4:48:33 PM ******/
CREATE DATABASE [TFU_GLocalShoes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TFU_GLocalShoes', FILENAME = N'Users/tamnguyen/Documents/SideProject/shoes-customize-shop.api/DBTracking/TFU_GLocalShoes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TFU_GLocalShoes_log', FILENAME = N'Users/tamnguyen/Documents/SideProject/shoes-customize-shop.api/DBTracking/TFU_GLocalShoes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [TFU_GLocalShoes] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TFU_GLocalShoes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TFU_GLocalShoes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET ARITHABORT OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TFU_GLocalShoes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TFU_GLocalShoes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TFU_GLocalShoes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TFU_GLocalShoes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TFU_GLocalShoes] SET  MULTI_USER 
GO
ALTER DATABASE [TFU_GLocalShoes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TFU_GLocalShoes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TFU_GLocalShoes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TFU_GLocalShoes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TFU_GLocalShoes] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TFU_GLocalShoes] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TFU_GLocalShoes] SET QUERY_STORE = ON
GO
ALTER DATABASE [TFU_GLocalShoes] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TFU_GLocalShoes]
GO
/****** Object:  Table [dbo].[App_Brand]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[App_Brand](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[Description] [nvarchar](max) NULL,
	[Thumbnail] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[IsActive] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[App_Order]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[App_Order](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[Status] [int] NULL,
	[Note] [nvarchar](50) NULL,
	[Amount] [float] NULL,
	[ShipAddress] [nvarchar](max) NULL,
	[ShipedDate] [datetime2](7) NULL,
	[DeliveredDate] [datetime2](7) NULL,
	[PaymentMethod] [int] NULL,
	[PaymentDate] [datetime2](7) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[OrderCode] [nvarchar](50) NULL,
	[ModifyDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[App_OrderItems]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[App_OrderItems](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ShoesId] [bigint] NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [float] NULL,
	[ShoesImageId] [bigint] NULL,
	[OrderId] [bigint] NULL,
	[Size] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[App_Shoes]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[App_Shoes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Description] [nvarchar](max) NULL,
	[Price] [float] NULL,
	[IsCustomizable] [bit] NULL,
	[CreatedDate] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](256) NULL,
	[ModifyDate] [datetime2](7) NULL,
	[BrandName] [nvarchar](255) NULL,
	[IsActive] [bit] NULL,
	[ModifyBy] [nvarchar](256) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[App_ShoesImages]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[App_ShoesImages](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ShoesId] [bigint] NULL,
	[Thumbnail] [nvarchar](256) NULL,
	[IsCustomize] [bit] NULL,
	[IsUserCustom] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[App_UserDetails]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[App_UserDetails](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DayOfBirth] [datetime2](7) NULL,
	[Gender] [bit] NULL,
	[Address] [nvarchar](255) NULL,
	[IsActive] [bit] NULL,
	[UserId] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SHIP_District]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SHIP_District](
	[Id] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[VNPOSTDistrictId] [int] NULL,
	[ProvinceId] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SHIP_Province]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SHIP_Province](
	[Id] [nvarchar](50) NULL,
	[Name] [nvarchar](100) NULL,
	[VNPOSTProvinceId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SHIP_Ward]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SHIP_Ward](
	[Id] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[VNPOSTWardId] [int] NULL,
	[DistrictId] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SYS_Actions]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_Actions](
	[IsDelete] [bit] NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ActionCode] [nvarchar](max) NULL,
 CONSTRAINT [PK_SYS_Actions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SYS_MappingMenuActions]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_MappingMenuActions](
	[MenuCode] [nvarchar](450) NOT NULL,
	[ActionCode] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_SYS_MappingMenuActions] PRIMARY KEY CLUSTERED 
(
	[MenuCode] ASC,
	[ActionCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_SYS_MappingMenuActions_ActionCode_MenuCode] UNIQUE NONCLUSTERED 
(
	[ActionCode] ASC,
	[MenuCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SYS_Menus]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SYS_Menus](
	[IsDelete] [bit] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ModifiedBy] [nvarchar](max) NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[FunctionCode] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Icon] [nvarchar](max) NULL,
	[NavigateLink] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[Index] [int] NULL,
	[Level] [int] NULL,
 CONSTRAINT [PK_SYS_Menus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TFU_RoleClaims]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TFU_RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_TFU_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TFU_RoleMenus]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TFU_RoleMenus](
	[RoleId] [bigint] NOT NULL,
	[MenuCode] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_TFU_RoleMenus_1] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[MenuCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TFU_Roles]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TFU_Roles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[IsAdmin] [bit] NOT NULL,
 CONSTRAINT [PK_TFU_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TFU_UserClaims]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TFU_UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_TFU_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TFU_UserLogins]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TFU_UserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [bigint] NOT NULL,
 CONSTRAINT [PK_TFU_UserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TFU_UserRoles]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TFU_UserRoles](
	[UserId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
 CONSTRAINT [PK_TFU_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TFU_Users]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TFU_Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Avatar] [nvarchar](500) NULL,
	[FacebookUserId] [nvarchar](50) NULL,
	[GoogleUserId] [nvarchar](50) NULL,
	[TiktokUserId] [nvarchar](50) NULL,
	[ZaloUserId] [nvarchar](50) NULL,
 CONSTRAINT [PK_TFU_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[utl_Error_Log]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[utl_Error_Log](
	[ErrorID] [int] IDENTITY(1,1) NOT NULL,
	[ErrorNum] [int] NULL,
	[ErrorMsg] [varchar](200) NULL,
	[ProcName] [varchar](50) NULL,
	[TableName] [varchar](50) NULL,
	[ActionType] [varchar](3) NULL,
	[SessionID] [bigint] NULL,
	[AddlInfo] [varchar](max) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedUserId] [bigint] NULL,
 CONSTRAINT [PK_utl_Error_Log] PRIMARY KEY CLUSTERED 
(
	[ErrorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[TFU_Roles] ADD  DEFAULT ((0)) FOR [IsAdmin]
GO
ALTER TABLE [dbo].[utl_Error_Log] ADD  CONSTRAINT [DF_utl_Error_Log_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[utl_Error_Log] ADD  CONSTRAINT [DF_utl_Error_Log_CreatedUserId]  DEFAULT ((-1)) FOR [CreatedUserId]
GO
ALTER TABLE [dbo].[TFU_RoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_TFU_RoleClaims_TFU_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[TFU_Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TFU_RoleClaims] CHECK CONSTRAINT [FK_TFU_RoleClaims_TFU_Roles_RoleId]
GO
ALTER TABLE [dbo].[TFU_UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_TFU_UserClaims_TFU_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[TFU_Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TFU_UserClaims] CHECK CONSTRAINT [FK_TFU_UserClaims_TFU_Users_UserId]
GO
ALTER TABLE [dbo].[TFU_UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_TFU_UserLogins_TFU_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[TFU_Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TFU_UserLogins] CHECK CONSTRAINT [FK_TFU_UserLogins_TFU_Users_UserId]
GO
ALTER TABLE [dbo].[TFU_UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_TFU_UserRoles_TFU_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[TFU_Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TFU_UserRoles] CHECK CONSTRAINT [FK_TFU_UserRoles_TFU_Roles_RoleId]
GO
ALTER TABLE [dbo].[TFU_UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_TFU_UserRoles_TFU_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[TFU_Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TFU_UserRoles] CHECK CONSTRAINT [FK_TFU_UserRoles_TFU_Users_UserId]
GO
/****** Object:  StoredProcedure [dbo].[SYS_Menu_Get_ByUserId]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ========================================================================
-- Author:						HungLee
-- Create date:					29/01/2021
-- Description:					Lấy danh sách menu có quyền truy cập của user
-- ========================================================================

CREATE PROCEDURE [dbo].[SYS_Menu_Get_ByUserId] @UserId BIGINT
AS BEGIN TRY
    CREATE TABLE #Temp (Id INT,
    FunctionCode VARCHAR(50),
    ParentId INT,
    Name NVARCHAR(200),
    NavigateLink VARCHAR(500),
    [Index] INT);
    INSERT INTO #Temp
    SELECT mnu.Id,
        mnu.FunctionCode,
        mnu.ParentId,
        mnu.Name,
        mnu.NavigateLink,
        mnu.[Index]
    FROM SYS_Menus mnu
    WHERE
        ISNULL(mnu.IsDelete, 0) = 0
        AND mnu.Level != 2
        AND EXISTS (SELECT rm.MenuCode
                    FROM
                        TFU_RoleMenus rm
                        JOIN TFU_UserRoles ur ON rm.RoleId = ur.RoleId
                    WHERE
                        ur.UserId = @UserId
                        AND mnu.FunctionCode = rm.MenuCode);

    ---Union 
    SELECT *
    FROM(SELECT temp.*
         FROM #Temp temp
         UNION ALL
         SELECT DISTINCT mnu.Id,
             mnu.FunctionCode,
             mnu.ParentId,
             mnu.Name,
             mnu.NavigateLink,
             mnu.[Index]
         FROM
             #Temp temp
             JOIN SYS_Menus mnu ON temp.ParentId = mnu.Id
         WHERE
             mnu.ParentId = 0
             AND mnu.IsDelete = 0) AS m
    ORDER BY m.ParentId,
        m.[Index];
    DROP TABLE #Temp;
END TRY
BEGIN CATCH
    DECLARE @ErrorNum INT,
        @ErrorMsg VARCHAR(200),
        @ErrorProc VARCHAR(50),
        @SessionID INT,
        @AddlInfo NVARCHAR(MAX);
    SET @ErrorNum = ERROR_NUMBER();
    SET @ErrorMsg = '[GetMenusByUser]: ' + ERROR_MESSAGE();
    SET @ErrorProc = ERROR_PROCEDURE();
    SET @AddlInfo = @UserId;
    EXEC utl_Insert_ErrorLog @ErrorNum,
        @ErrorMsg,
        @ErrorProc,
        'SYS_Menus, TFU_RoleMenus',
        'GET',
        @AddlInfo;
END CATCH;
GO
/****** Object:  StoredProcedure [dbo].[utl_Insert_ErrorLog]    Script Date: 10/9/2024 4:48:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[utl_Insert_ErrorLog]
    @ErrorCd INT,
    @ErrorMsg VARCHAR(200),
    @ProcName VARCHAR(50),
    @TableName VARCHAR(50),
    @ActionType VARCHAR(3),
    @AddlInfo VARCHAR(MAX)
AS
INSERT INTO utl_Error_Log (ErrorNum, ErrorMsg, ProcName, TableName, ActionType, AddlInfo, CreatedDate)
SELECT ErrorNum = @ErrorCd,
       ErrorMsg = @ErrorMsg,
       ProcName = @ProcName,
       TableName = @TableName,
       ActionType = @ActionType,
       AddlInfo = @AddlInfo,
       CreatedDate = GETDATE();
GO
USE [master]
GO
ALTER DATABASE [TFU_GLocalShoes] SET  READ_WRITE 
GO
