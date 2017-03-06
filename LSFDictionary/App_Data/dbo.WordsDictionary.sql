CREATE TABLE [dbo].[WordsDictionary] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Key]      NVARCHAR (MAX) NOT NULL,
    [Value]    NVARCHAR (MAX) NOT NULL,
    [Cate]	   NVARCHAR (MAX) NOT NULL DEFAULT 'All',
    [Niveau]   INT            NOT NULL,
    [FontAwe] NVARCHAR(50) NOT NULL DEFAULT 'fa-users', 
    CONSTRAINT [PK_dbo.WordsDictionary] PRIMARY KEY CLUSTERED ([Id] ASC)
);

