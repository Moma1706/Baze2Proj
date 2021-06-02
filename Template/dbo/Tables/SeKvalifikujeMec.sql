CREATE TABLE [dbo].[SeKvalifikujeMec] (
    [SeKvalifikujes_TurnirIdTurnira] INT NOT NULL,
    [SeKvalifikujes_TimIdTima]       INT NOT NULL,
    [Mecs_IdMeca]                    INT NOT NULL,
    CONSTRAINT [PK_SeKvalifikujeMec] PRIMARY KEY CLUSTERED ([SeKvalifikujes_TurnirIdTurnira] ASC, [SeKvalifikujes_TimIdTima] ASC, [Mecs_IdMeca] ASC),
    CONSTRAINT [FK_SeKvalifikujeMec_Mec] FOREIGN KEY ([Mecs_IdMeca]) REFERENCES [dbo].[Mecs] ([IdMeca]),
    CONSTRAINT [FK_SeKvalifikujeMec_SeKvalifikuje] FOREIGN KEY ([SeKvalifikujes_TurnirIdTurnira], [SeKvalifikujes_TimIdTima]) REFERENCES [dbo].[SeKvalifikujes] ([TurnirIdTurnira], [TimIdTima])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_SeKvalifikujeMec_Mec]
    ON [dbo].[SeKvalifikujeMec]([Mecs_IdMeca] ASC);

