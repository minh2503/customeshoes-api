CREATE TABLE [dbo].[Regions] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [Name]           NVARCHAR (MAX)   NOT NULL,
    [Code]           NVARCHAR (MAX)   NOT NULL,
    [RegionImageUrl] NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED ([Id] ASC)
);

