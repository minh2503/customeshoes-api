CREATE TABLE [dbo].[Images] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [FileName]        NVARCHAR (MAX)   NOT NULL,
    [FileDescription] NVARCHAR (MAX)   NULL,
    [FileExtention]   NVARCHAR (MAX)   NOT NULL,
    [FileSizeInBytes] NVARCHAR (MAX)   NULL,
    [FilePath]        NVARCHAR (MAX)   NOT NULL,
    CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED ([Id] ASC)
);

