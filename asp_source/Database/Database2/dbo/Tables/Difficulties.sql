CREATE TABLE [dbo].[Difficulties] (
    [Id]   UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Difficulties] PRIMARY KEY CLUSTERED ([Id] ASC)
);

