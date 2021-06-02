CREATE TABLE [dbo].[IgracTim] (
    [Igracs_JMBG] BIGINT NOT NULL,
    [Tims_IdTima] INT    NOT NULL,
    CONSTRAINT [PK_IgracTim] PRIMARY KEY CLUSTERED ([Igracs_JMBG] ASC, [Tims_IdTima] ASC),
    CONSTRAINT [FK_IgracTim_Igrac] FOREIGN KEY ([Igracs_JMBG]) REFERENCES [dbo].[Ucesniks_Igrac] ([JMBG]),
    CONSTRAINT [FK_IgracTim_Tim] FOREIGN KEY ([Tims_IdTima]) REFERENCES [dbo].[Tims] ([IdTima])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_IgracTim_Tim]
    ON [dbo].[IgracTim]([Tims_IdTima] ASC);

