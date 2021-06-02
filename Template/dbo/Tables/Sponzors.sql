CREATE TABLE [dbo].[Sponzors] (
    [IdSponzora] INT            IDENTITY (1, 1) NOT NULL,
    [Naziv]      NVARCHAR (MAX) NOT NULL,
    [Ulaganje]   INT            NOT NULL,
    [Sediste]    NVARCHAR (MAX) NOT NULL,
    [CEO]        NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Sponzors] PRIMARY KEY CLUSTERED ([IdSponzora] ASC)
);

