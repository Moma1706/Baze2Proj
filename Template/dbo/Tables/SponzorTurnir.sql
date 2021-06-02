CREATE TABLE [dbo].[SponzorTurnir] (
    [Sponzors_IdSponzora] INT NOT NULL,
    [Turnirs_IdTurnira]   INT NOT NULL,
    CONSTRAINT [PK_SponzorTurnir] PRIMARY KEY CLUSTERED ([Sponzors_IdSponzora] ASC, [Turnirs_IdTurnira] ASC),
    CONSTRAINT [FK_SponzorTurnir_Sponzor] FOREIGN KEY ([Sponzors_IdSponzora]) REFERENCES [dbo].[Sponzors] ([IdSponzora]),
    CONSTRAINT [FK_SponzorTurnir_Turnir] FOREIGN KEY ([Turnirs_IdTurnira]) REFERENCES [dbo].[Turnirs] ([IdTurnira])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_SponzorTurnir_Turnir]
    ON [dbo].[SponzorTurnir]([Turnirs_IdTurnira] ASC);

