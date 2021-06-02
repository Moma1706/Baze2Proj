CREATE TABLE [dbo].[Mecs] (
    [IdMeca]                       INT            IDENTITY (1, 1) NOT NULL,
    [DatumOdrzavanja]              DATETIME       NOT NULL,
    [Kolo]                         NVARCHAR (MAX) NOT NULL,
    [Rezultat]                     NVARCHAR (MAX) NOT NULL,
    [StatistikaIdStatistike]       INT            NOT NULL,
    [TerenIdTerena]                INT            NULL,
    [SePrijavljujeTurnirIdTurnira] INT            NOT NULL,
    [SePrijavljujeSudijaJMBG]      BIGINT         NOT NULL,
    CONSTRAINT [PK_Mecs] PRIMARY KEY CLUSTERED ([IdMeca] ASC),
    CONSTRAINT [FK_MecTeren] FOREIGN KEY ([TerenIdTerena]) REFERENCES [dbo].[Terens] ([IdTerena]),
    CONSTRAINT [FK_SePrijavljujeMec] FOREIGN KEY ([SePrijavljujeTurnirIdTurnira], [SePrijavljujeSudijaJMBG]) REFERENCES [dbo].[SePrijavljujes] ([TurnirIdTurnira], [SudijaJMBG]),
    CONSTRAINT [FK_StatistikaMec] FOREIGN KEY ([StatistikaIdStatistike]) REFERENCES [dbo].[Statistikas] ([IdStatistike])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_StatistikaMec]
    ON [dbo].[Mecs]([StatistikaIdStatistike] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FK_MecTeren]
    ON [dbo].[Mecs]([TerenIdTerena] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FK_SePrijavljujeMec]
    ON [dbo].[Mecs]([SePrijavljujeTurnirIdTurnira] ASC, [SePrijavljujeSudijaJMBG] ASC);

