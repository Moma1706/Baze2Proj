CREATE TABLE [dbo].[Ucesniks] (
    [JMBG]          BIGINT         NOT NULL,
    [DatumRodjenja] DATETIME       NOT NULL,
    [Ime]           NVARCHAR (MAX) NOT NULL,
    [Prezime]       NVARCHAR (MAX) NOT NULL,
    [Drzava]        NVARCHAR (MAX) NOT NULL,
    [Zarada]        INT            NULL,
    CONSTRAINT [PK_Ucesniks] PRIMARY KEY CLUSTERED ([JMBG] ASC)
);

