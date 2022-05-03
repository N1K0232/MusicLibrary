CREATE TABLE [dbo].[Songs] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [IdArtist]         UNIQUEIDENTIFIER NOT NULL,
    [IdLabel]          UNIQUEIDENTIFIER NOT NULL,
    [Title]            NVARCHAR (200)   NOT NULL,
    [ReleaseDate]      DATE             NOT NULL,
    [SongType]         NVARCHAR (10)    NOT NULL,
    [CreationDate]     DATETIME         NOT NULL,
    [LastModifiedDate] DATETIME         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdArtist]) REFERENCES [dbo].[Artists] ([Id]),
    FOREIGN KEY ([IdLabel]) REFERENCES [dbo].[RecordLabels] ([Id])
);

