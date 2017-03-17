CREATE TABLE [dbo].[Jeux] (
    [Id]     INT            NOT NULL,
    [User]   INT            NOT NULL,
    [Niveau] INT            NOT NULL,
    [Cate]   NVARCHAR (MAX) NOT NULL,
    [Value]  INT            NOT NULL,
    CONSTRAINT [PK_dbo.Jeux] PRIMARY KEY CLUSTERED ([Id] ASC)
);