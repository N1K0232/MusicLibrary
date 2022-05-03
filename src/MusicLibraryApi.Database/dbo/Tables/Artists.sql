CREATE TABLE [dbo].[Artists] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [IdLabel]          UNIQUEIDENTIFIER NOT NULL,
    [FirstName]        NVARCHAR (100)   NOT NULL,
    [LastName]         NVARCHAR (100)   NOT NULL,
    [BirthDate]        DATE             NOT NULL,
    [ArtName]          NVARCHAR (100)   NOT NULL,
    [CreatedDate]      DATETIME         NOT NULL,
    [LastModifiedDate] DATETIME         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdLabel]) REFERENCES [dbo].[RecordLabels] ([Id])
);

