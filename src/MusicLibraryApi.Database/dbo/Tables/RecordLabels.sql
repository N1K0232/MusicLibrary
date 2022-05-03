CREATE TABLE [dbo].[RecordLabels] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [Name]             NVARCHAR (50)    NOT NULL,
    [FoundationDate]   DATE             NOT NULL,
    [City]             NVARCHAR (50)    NOT NULL,
    [Country]          NVARCHAR (50)    NOT NULL,
    [CreatedDate]      DATETIME         NOT NULL,
    [LastModifiedDate] DATETIME         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

