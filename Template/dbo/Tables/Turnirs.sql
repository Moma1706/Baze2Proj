CREATE TABLE [dbo].[Turnirs] (
    [IdTurnira]       INT            IDENTITY (1, 1) NOT NULL,
    [Tip]             INT            NOT NULL,
    [TrenutniSampion] NVARCHAR (MAX) NOT NULL,
    [Naziv]           NVARCHAR (MAX) NOT NULL,
    [DatumOsnivanja]  DATETIME       NOT NULL,
    CONSTRAINT [PK_Turnirs] PRIMARY KEY CLUSTERED ([IdTurnira] ASC)
);

