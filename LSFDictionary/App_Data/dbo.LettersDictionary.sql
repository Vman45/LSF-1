CREATE TABLE [dbo].[LettersDictionary] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Key]      NVARCHAR (MAX) NOT NULL,
    [Value]    NVARCHAR (MAX) NOT NULL,
    [FontAwe] NVARCHAR(50) NOT NULL DEFAULT 'fa-users', 
    CONSTRAINT [PK_dbo.LettersDictionary] PRIMARY KEY CLUSTERED ([Id] ASC)
);

