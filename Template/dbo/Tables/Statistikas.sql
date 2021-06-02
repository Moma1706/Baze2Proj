CREATE TABLE [dbo].[Statistikas] (
    [IdStatistike] INT            IDENTITY (1, 1) NOT NULL,
    [Golovi]       NVARCHAR (MAX) NOT NULL,
    [Kartoni]      NVARCHAR (MAX) NOT NULL,
    [Asistencije]  NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Statistikas] PRIMARY KEY CLUSTERED ([IdStatistike] ASC)
);

