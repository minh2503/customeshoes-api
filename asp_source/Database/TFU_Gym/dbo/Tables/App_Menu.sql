CREATE TABLE [dbo].[App_Menu] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NULL,
    [NavigateLink] NVARCHAR (50) NULL,
    [RoleId]       INT           NULL,
    CONSTRAINT [PK_App_Menu] PRIMARY KEY CLUSTERED ([Id] ASC)
);

