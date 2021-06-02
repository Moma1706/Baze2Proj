CREATE TABLE [dbo].[SePrijavljujes] (
    [TurnirIdTurnira]  INT    NOT NULL,
    [SudijaJMBG]       BIGINT NOT NULL,
    [Turnir_IdTurnira] INT    NOT NULL,
    CONSTRAINT [PK_SePrijavljujes] PRIMARY KEY CLUSTERED ([TurnirIdTurnira] ASC, [SudijaJMBG] ASC),
    CONSTRAINT [FK_SePrijavljujeTurnir] FOREIGN KEY ([Turnir_IdTurnira]) REFERENCES [dbo].[Turnirs] ([IdTurnira]),
    CONSTRAINT [FK_SudijaSePrijavljuje] FOREIGN KEY ([SudijaJMBG]) REFERENCES [dbo].[Ucesniks_Sudija] ([JMBG])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_SePrijavljujeTurnir]
    ON [dbo].[SePrijavljujes]([Turnir_IdTurnira] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FK_SudijaSePrijavljuje]
    ON [dbo].[SePrijavljujes]([SudijaJMBG] ASC);

