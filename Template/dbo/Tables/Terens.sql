CREATE TABLE [dbo].[Terens] (
    [IdTerena]       INT            IDENTITY (1, 1) NOT NULL,
    [DatumOsnivanja] DATETIME       NOT NULL,
    [Mesto]          NVARCHAR (MAX) NOT NULL,
    [BrojGledalaca]  INT            NOT NULL,
    [Naziv]          NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Terens] PRIMARY KEY CLUSTERED ([IdTerena] ASC)
);

