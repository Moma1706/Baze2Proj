CREATE TABLE [dbo].[Tims] (
    [IdTima]         INT            IDENTITY (1, 1) NOT NULL,
    [BrojTitula]     NVARCHAR (MAX) NOT NULL,
    [Tip]            INT            NOT NULL,
    [DatumOsnivanja] DATETIME       NOT NULL,
    CONSTRAINT [PK_Tims] PRIMARY KEY CLUSTERED ([IdTima] ASC)
);

