CREATE TABLE [dbo].[Walks] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Name]         NVARCHAR (MAX)   NOT NULL,
    [Description]  NVARCHAR (MAX)   NOT NULL,
    [LengthInKm]   FLOAT (53)       NOT NULL,
    [DifficultyId] UNIQUEIDENTIFIER NOT NULL,
    [RegionId]     UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Walks] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Walks_Difficulties_DifficultyId] FOREIGN KEY ([DifficultyId]) REFERENCES [dbo].[Difficulties] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Walks_Regions_RegionId] FOREIGN KEY ([RegionId]) REFERENCES [dbo].[Regions] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Walks_RegionId]
    ON [dbo].[Walks]([RegionId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Walks_DifficultyId]
    ON [dbo].[Walks]([DifficultyId] ASC);

