CREATE TABLE [dbo].[Albums]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[IdArtist] UNIQUEIDENTIFIER NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
	[ReleaseDate] DATE NOT NULL,
	[CreatedDate] DATE NOT NULL,
	[LastModifiedDate] DATE NULL,
)