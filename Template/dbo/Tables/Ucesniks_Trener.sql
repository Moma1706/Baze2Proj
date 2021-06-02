CREATE TABLE [dbo].[Ucesniks_Trener] (
    [Tip]                 INT    NOT NULL,
    [BrojOsvojenihTitula] INT    NOT NULL,
    [TimIdTima]           INT    NULL,
    [JMBG]                BIGINT NOT NULL,
    CONSTRAINT [PK_Ucesniks_Trener] PRIMARY KEY CLUSTERED ([JMBG] ASC),
    CONSTRAINT [FK_Trener_inherits_Ucesnik] FOREIGN KEY ([JMBG]) REFERENCES [dbo].[Ucesniks] ([JMBG]) ON DELETE CASCADE,
    CONSTRAINT [FK_TrenerTim] FOREIGN KEY ([TimIdTima]) REFERENCES [dbo].[Tims] ([IdTima])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_TrenerTim]
    ON [dbo].[Ucesniks_Trener]([TimIdTima] ASC);

