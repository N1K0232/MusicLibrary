CREATE TABLE [dbo].[RecordLabels] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [Name]             NVARCHAR (50)    NOT NULL,
    [FoundationDate]   DATE             NOT NULL,
    [CreationDate]     DATETIME         NOT NULL,
    [LastModifiedDate] DATETIME         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

