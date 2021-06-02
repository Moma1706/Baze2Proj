CREATE TABLE [dbo].[SeKvalifikujes] (
    [TurnirIdTurnira] INT NOT NULL,
    [TimIdTima]       INT NOT NULL,
    CONSTRAINT [PK_SeKvalifikujes] PRIMARY KEY CLUSTERED ([TurnirIdTurnira] ASC, [TimIdTima] ASC),
    CONSTRAINT [FK_TimSeKvalifikuje] FOREIGN KEY ([TimIdTima]) REFERENCES [dbo].[Tims] ([IdTima]),
    CONSTRAINT [FK_TurnirSeKvalifikuje] FOREIGN KEY ([TurnirIdTurnira]) REFERENCES [dbo].[Turnirs] ([IdTurnira])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_TimSeKvalifikuje]
    ON [dbo].[SeKvalifikujes]([TimIdTima] ASC);

