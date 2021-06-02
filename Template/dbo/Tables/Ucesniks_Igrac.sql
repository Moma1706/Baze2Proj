CREATE TABLE [dbo].[Ucesniks_Igrac] (
    [Pozicija]   NVARCHAR (MAX) NOT NULL,
    [BrojGolova] INT            NOT NULL,
    [Visina]     INT            NOT NULL,
    [JMBG]       BIGINT         NOT NULL,
    CONSTRAINT [PK_Ucesniks_Igrac] PRIMARY KEY CLUSTERED ([JMBG] ASC),
    CONSTRAINT [FK_Igrac_inherits_Ucesnik] FOREIGN KEY ([JMBG]) REFERENCES [dbo].[Ucesniks] ([JMBG]) ON DELETE CASCADE
);

