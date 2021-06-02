CREATE TABLE [dbo].[Ucesniks_Sudija] (
    [BrojUtakmica] INT    NOT NULL,
    [Tip]          INT    NOT NULL,
    [JMBG]         BIGINT NOT NULL,
    CONSTRAINT [PK_Ucesniks_Sudija] PRIMARY KEY CLUSTERED ([JMBG] ASC),
    CONSTRAINT [FK_Sudija_inherits_Ucesnik] FOREIGN KEY ([JMBG]) REFERENCES [dbo].[Ucesniks] ([JMBG]) ON DELETE CASCADE
);

