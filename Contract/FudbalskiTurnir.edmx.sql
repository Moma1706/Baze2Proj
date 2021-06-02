
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/01/2021 22:03:43
-- Generated from EDMX file: C:\Users\Milan\source\repos\Baze2Proj\Contract\FudbalskiTurnir.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Baze2];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_StatistikaMec]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mecs] DROP CONSTRAINT [FK_StatistikaMec];
GO
IF OBJECT_ID(N'[dbo].[FK_TrenerTim]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ucesniks_Trener] DROP CONSTRAINT [FK_TrenerTim];
GO
IF OBJECT_ID(N'[dbo].[FK_MecTeren]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mecs] DROP CONSTRAINT [FK_MecTeren];
GO
IF OBJECT_ID(N'[dbo].[FK_SePrijavljujeTurnir]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SePrijavljujes] DROP CONSTRAINT [FK_SePrijavljujeTurnir];
GO
IF OBJECT_ID(N'[dbo].[FK_TurnirSeKvalifikuje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SeKvalifikujes] DROP CONSTRAINT [FK_TurnirSeKvalifikuje];
GO
IF OBJECT_ID(N'[dbo].[FK_TimSeKvalifikuje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SeKvalifikujes] DROP CONSTRAINT [FK_TimSeKvalifikuje];
GO
IF OBJECT_ID(N'[dbo].[FK_SudijaSePrijavljuje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SePrijavljujes] DROP CONSTRAINT [FK_SudijaSePrijavljuje];
GO
IF OBJECT_ID(N'[dbo].[FK_SePrijavljujeMec]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mecs] DROP CONSTRAINT [FK_SePrijavljujeMec];
GO
IF OBJECT_ID(N'[dbo].[FK_SponzorTurnir_Sponzor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SponzorTurnir] DROP CONSTRAINT [FK_SponzorTurnir_Sponzor];
GO
IF OBJECT_ID(N'[dbo].[FK_SponzorTurnir_Turnir]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SponzorTurnir] DROP CONSTRAINT [FK_SponzorTurnir_Turnir];
GO
IF OBJECT_ID(N'[dbo].[FK_Trener_inherits_Ucesnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ucesniks_Trener] DROP CONSTRAINT [FK_Trener_inherits_Ucesnik];
GO
IF OBJECT_ID(N'[dbo].[FK_Sudija_inherits_Ucesnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ucesniks_Sudija] DROP CONSTRAINT [FK_Sudija_inherits_Ucesnik];
GO
IF OBJECT_ID(N'[dbo].[FK_Igrac_inherits_Ucesnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ucesniks_Igrac] DROP CONSTRAINT [FK_Igrac_inherits_Ucesnik];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Ucesniks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ucesniks];
GO
IF OBJECT_ID(N'[dbo].[Tims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tims];
GO
IF OBJECT_ID(N'[dbo].[Sponzors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sponzors];
GO
IF OBJECT_ID(N'[dbo].[Turnirs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Turnirs];
GO
IF OBJECT_ID(N'[dbo].[Mecs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mecs];
GO
IF OBJECT_ID(N'[dbo].[Terens]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Terens];
GO
IF OBJECT_ID(N'[dbo].[Statistikas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Statistikas];
GO
IF OBJECT_ID(N'[dbo].[SePrijavljujes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SePrijavljujes];
GO
IF OBJECT_ID(N'[dbo].[SeKvalifikujes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SeKvalifikujes];
GO
IF OBJECT_ID(N'[dbo].[Ucesniks_Trener]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ucesniks_Trener];
GO
IF OBJECT_ID(N'[dbo].[Ucesniks_Sudija]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ucesniks_Sudija];
GO
IF OBJECT_ID(N'[dbo].[Ucesniks_Igrac]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ucesniks_Igrac];
GO
IF OBJECT_ID(N'[dbo].[SponzorTurnir]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SponzorTurnir];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Ucesniks'
CREATE TABLE [dbo].[Ucesniks] (
    [JMBG] bigint  NOT NULL,
    [DatumRodjenja] datetime  NOT NULL,
    [Ime] nvarchar(max)  NOT NULL,
    [Prezime] nvarchar(max)  NOT NULL,
    [Drzava] nvarchar(max)  NOT NULL,
    [Zarada] int  NULL
);
GO

-- Creating table 'Tims'
CREATE TABLE [dbo].[Tims] (
    [IdTima] int IDENTITY(1,1) NOT NULL,
    [BrojTitula] nvarchar(max)  NOT NULL,
    [Tip] int  NOT NULL,
    [DatumOsnivanja] datetime  NOT NULL
);
GO

-- Creating table 'Sponzors'
CREATE TABLE [dbo].[Sponzors] (
    [IdSponzora] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [Ulaganje] int  NOT NULL,
    [Sediste] nvarchar(max)  NOT NULL,
    [CEO] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Turnirs'
CREATE TABLE [dbo].[Turnirs] (
    [IdTurnira] int IDENTITY(1,1) NOT NULL,
    [Tip] int  NOT NULL,
    [TrenutniSampion] nvarchar(max)  NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL,
    [DatumOsnivanja] datetime  NOT NULL
);
GO

-- Creating table 'Mecs'
CREATE TABLE [dbo].[Mecs] (
    [IdMeca] int IDENTITY(1,1) NOT NULL,
    [DatumOdrzavanja] datetime  NOT NULL,
    [Kolo] nvarchar(max)  NOT NULL,
    [Rezultat] nvarchar(max)  NOT NULL,
    [StatistikaIdStatistike] int  NOT NULL,
    [TerenIdTerena] int  NULL,
    [SePrijavljujeTurnirIdTurnira] int  NOT NULL,
    [SePrijavljujeSudijaJMBG] bigint  NOT NULL
);
GO

-- Creating table 'Terens'
CREATE TABLE [dbo].[Terens] (
    [IdTerena] int IDENTITY(1,1) NOT NULL,
    [DatumOsnivanja] datetime  NOT NULL,
    [Mesto] nvarchar(max)  NOT NULL,
    [BrojGledalaca] int  NOT NULL,
    [Naziv] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Statistikas'
CREATE TABLE [dbo].[Statistikas] (
    [IdStatistike] int IDENTITY(1,1) NOT NULL,
    [Golovi] nvarchar(max)  NOT NULL,
    [Kartoni] nvarchar(max)  NOT NULL,
    [Asistencije] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SePrijavljujes'
CREATE TABLE [dbo].[SePrijavljujes] (
    [TurnirIdTurnira] int  NOT NULL,
    [SudijaJMBG] bigint  NOT NULL,
    [Turnir_IdTurnira] int  NOT NULL
);
GO

-- Creating table 'SeKvalifikujes'
CREATE TABLE [dbo].[SeKvalifikujes] (
    [TurnirIdTurnira] int  NOT NULL,
    [TimIdTima] int  NOT NULL
);
GO

-- Creating table 'Ucesniks_Trener'
CREATE TABLE [dbo].[Ucesniks_Trener] (
    [Tip] int  NOT NULL,
    [BrojOsvojenihTitula] int  NOT NULL,
    [TimIdTima] int  NULL,
    [JMBG] bigint  NOT NULL
);
GO

-- Creating table 'Ucesniks_Sudija'
CREATE TABLE [dbo].[Ucesniks_Sudija] (
    [BrojUtakmica] int  NOT NULL,
    [Tip] int  NOT NULL,
    [JMBG] bigint  NOT NULL
);
GO

-- Creating table 'Ucesniks_Igrac'
CREATE TABLE [dbo].[Ucesniks_Igrac] (
    [Pozicija] nvarchar(max)  NOT NULL,
    [BrojGolova] int  NOT NULL,
    [Visina] int  NOT NULL,
    [JMBG] bigint  NOT NULL
);
GO

-- Creating table 'SponzorTurnir'
CREATE TABLE [dbo].[SponzorTurnir] (
    [Sponzors_IdSponzora] int  NOT NULL,
    [Turnirs_IdTurnira] int  NOT NULL
);
GO

-- Creating table 'SeKvalifikujeMec'
CREATE TABLE [dbo].[SeKvalifikujeMec] (
    [SeKvalifikujes_TurnirIdTurnira] int  NOT NULL,
    [SeKvalifikujes_TimIdTima] int  NOT NULL,
    [Mecs_IdMeca] int  NOT NULL
);
GO

-- Creating table 'IgracTim'
CREATE TABLE [dbo].[IgracTim] (
    [Igracs_JMBG] bigint  NOT NULL,
    [Tims_IdTima] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [JMBG] in table 'Ucesniks'
ALTER TABLE [dbo].[Ucesniks]
ADD CONSTRAINT [PK_Ucesniks]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [IdTima] in table 'Tims'
ALTER TABLE [dbo].[Tims]
ADD CONSTRAINT [PK_Tims]
    PRIMARY KEY CLUSTERED ([IdTima] ASC);
GO

-- Creating primary key on [IdSponzora] in table 'Sponzors'
ALTER TABLE [dbo].[Sponzors]
ADD CONSTRAINT [PK_Sponzors]
    PRIMARY KEY CLUSTERED ([IdSponzora] ASC);
GO

-- Creating primary key on [IdTurnira] in table 'Turnirs'
ALTER TABLE [dbo].[Turnirs]
ADD CONSTRAINT [PK_Turnirs]
    PRIMARY KEY CLUSTERED ([IdTurnira] ASC);
GO

-- Creating primary key on [IdMeca] in table 'Mecs'
ALTER TABLE [dbo].[Mecs]
ADD CONSTRAINT [PK_Mecs]
    PRIMARY KEY CLUSTERED ([IdMeca] ASC);
GO

-- Creating primary key on [IdTerena] in table 'Terens'
ALTER TABLE [dbo].[Terens]
ADD CONSTRAINT [PK_Terens]
    PRIMARY KEY CLUSTERED ([IdTerena] ASC);
GO

-- Creating primary key on [IdStatistike] in table 'Statistikas'
ALTER TABLE [dbo].[Statistikas]
ADD CONSTRAINT [PK_Statistikas]
    PRIMARY KEY CLUSTERED ([IdStatistike] ASC);
GO

-- Creating primary key on [TurnirIdTurnira], [SudijaJMBG] in table 'SePrijavljujes'
ALTER TABLE [dbo].[SePrijavljujes]
ADD CONSTRAINT [PK_SePrijavljujes]
    PRIMARY KEY CLUSTERED ([TurnirIdTurnira], [SudijaJMBG] ASC);
GO

-- Creating primary key on [TurnirIdTurnira], [TimIdTima] in table 'SeKvalifikujes'
ALTER TABLE [dbo].[SeKvalifikujes]
ADD CONSTRAINT [PK_SeKvalifikujes]
    PRIMARY KEY CLUSTERED ([TurnirIdTurnira], [TimIdTima] ASC);
GO

-- Creating primary key on [JMBG] in table 'Ucesniks_Trener'
ALTER TABLE [dbo].[Ucesniks_Trener]
ADD CONSTRAINT [PK_Ucesniks_Trener]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Ucesniks_Sudija'
ALTER TABLE [dbo].[Ucesniks_Sudija]
ADD CONSTRAINT [PK_Ucesniks_Sudija]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [JMBG] in table 'Ucesniks_Igrac'
ALTER TABLE [dbo].[Ucesniks_Igrac]
ADD CONSTRAINT [PK_Ucesniks_Igrac]
    PRIMARY KEY CLUSTERED ([JMBG] ASC);
GO

-- Creating primary key on [Sponzors_IdSponzora], [Turnirs_IdTurnira] in table 'SponzorTurnir'
ALTER TABLE [dbo].[SponzorTurnir]
ADD CONSTRAINT [PK_SponzorTurnir]
    PRIMARY KEY CLUSTERED ([Sponzors_IdSponzora], [Turnirs_IdTurnira] ASC);
GO

-- Creating primary key on [SeKvalifikujes_TurnirIdTurnira], [SeKvalifikujes_TimIdTima], [Mecs_IdMeca] in table 'SeKvalifikujeMec'
ALTER TABLE [dbo].[SeKvalifikujeMec]
ADD CONSTRAINT [PK_SeKvalifikujeMec]
    PRIMARY KEY CLUSTERED ([SeKvalifikujes_TurnirIdTurnira], [SeKvalifikujes_TimIdTima], [Mecs_IdMeca] ASC);
GO

-- Creating primary key on [Igracs_JMBG], [Tims_IdTima] in table 'IgracTim'
ALTER TABLE [dbo].[IgracTim]
ADD CONSTRAINT [PK_IgracTim]
    PRIMARY KEY CLUSTERED ([Igracs_JMBG], [Tims_IdTima] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [StatistikaIdStatistike] in table 'Mecs'
ALTER TABLE [dbo].[Mecs]
ADD CONSTRAINT [FK_StatistikaMec]
    FOREIGN KEY ([StatistikaIdStatistike])
    REFERENCES [dbo].[Statistikas]
        ([IdStatistike])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StatistikaMec'
CREATE INDEX [IX_FK_StatistikaMec]
ON [dbo].[Mecs]
    ([StatistikaIdStatistike]);
GO

-- Creating foreign key on [TimIdTima] in table 'Ucesniks_Trener'
ALTER TABLE [dbo].[Ucesniks_Trener]
ADD CONSTRAINT [FK_TrenerTim]
    FOREIGN KEY ([TimIdTima])
    REFERENCES [dbo].[Tims]
        ([IdTima])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TrenerTim'
CREATE INDEX [IX_FK_TrenerTim]
ON [dbo].[Ucesniks_Trener]
    ([TimIdTima]);
GO

-- Creating foreign key on [TerenIdTerena] in table 'Mecs'
ALTER TABLE [dbo].[Mecs]
ADD CONSTRAINT [FK_MecTeren]
    FOREIGN KEY ([TerenIdTerena])
    REFERENCES [dbo].[Terens]
        ([IdTerena])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MecTeren'
CREATE INDEX [IX_FK_MecTeren]
ON [dbo].[Mecs]
    ([TerenIdTerena]);
GO

-- Creating foreign key on [Turnir_IdTurnira] in table 'SePrijavljujes'
ALTER TABLE [dbo].[SePrijavljujes]
ADD CONSTRAINT [FK_SePrijavljujeTurnir]
    FOREIGN KEY ([Turnir_IdTurnira])
    REFERENCES [dbo].[Turnirs]
        ([IdTurnira])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SePrijavljujeTurnir'
CREATE INDEX [IX_FK_SePrijavljujeTurnir]
ON [dbo].[SePrijavljujes]
    ([Turnir_IdTurnira]);
GO

-- Creating foreign key on [TurnirIdTurnira] in table 'SeKvalifikujes'
ALTER TABLE [dbo].[SeKvalifikujes]
ADD CONSTRAINT [FK_TurnirSeKvalifikuje]
    FOREIGN KEY ([TurnirIdTurnira])
    REFERENCES [dbo].[Turnirs]
        ([IdTurnira])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TimIdTima] in table 'SeKvalifikujes'
ALTER TABLE [dbo].[SeKvalifikujes]
ADD CONSTRAINT [FK_TimSeKvalifikuje]
    FOREIGN KEY ([TimIdTima])
    REFERENCES [dbo].[Tims]
        ([IdTima])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TimSeKvalifikuje'
CREATE INDEX [IX_FK_TimSeKvalifikuje]
ON [dbo].[SeKvalifikujes]
    ([TimIdTima]);
GO

-- Creating foreign key on [SudijaJMBG] in table 'SePrijavljujes'
ALTER TABLE [dbo].[SePrijavljujes]
ADD CONSTRAINT [FK_SudijaSePrijavljuje]
    FOREIGN KEY ([SudijaJMBG])
    REFERENCES [dbo].[Ucesniks_Sudija]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SudijaSePrijavljuje'
CREATE INDEX [IX_FK_SudijaSePrijavljuje]
ON [dbo].[SePrijavljujes]
    ([SudijaJMBG]);
GO

-- Creating foreign key on [SePrijavljujeTurnirIdTurnira], [SePrijavljujeSudijaJMBG] in table 'Mecs'
ALTER TABLE [dbo].[Mecs]
ADD CONSTRAINT [FK_SePrijavljujeMec]
    FOREIGN KEY ([SePrijavljujeTurnirIdTurnira], [SePrijavljujeSudijaJMBG])
    REFERENCES [dbo].[SePrijavljujes]
        ([TurnirIdTurnira], [SudijaJMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SePrijavljujeMec'
CREATE INDEX [IX_FK_SePrijavljujeMec]
ON [dbo].[Mecs]
    ([SePrijavljujeTurnirIdTurnira], [SePrijavljujeSudijaJMBG]);
GO

-- Creating foreign key on [Sponzors_IdSponzora] in table 'SponzorTurnir'
ALTER TABLE [dbo].[SponzorTurnir]
ADD CONSTRAINT [FK_SponzorTurnir_Sponzor]
    FOREIGN KEY ([Sponzors_IdSponzora])
    REFERENCES [dbo].[Sponzors]
        ([IdSponzora])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Turnirs_IdTurnira] in table 'SponzorTurnir'
ALTER TABLE [dbo].[SponzorTurnir]
ADD CONSTRAINT [FK_SponzorTurnir_Turnir]
    FOREIGN KEY ([Turnirs_IdTurnira])
    REFERENCES [dbo].[Turnirs]
        ([IdTurnira])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SponzorTurnir_Turnir'
CREATE INDEX [IX_FK_SponzorTurnir_Turnir]
ON [dbo].[SponzorTurnir]
    ([Turnirs_IdTurnira]);
GO

-- Creating foreign key on [SeKvalifikujes_TurnirIdTurnira], [SeKvalifikujes_TimIdTima] in table 'SeKvalifikujeMec'
ALTER TABLE [dbo].[SeKvalifikujeMec]
ADD CONSTRAINT [FK_SeKvalifikujeMec_SeKvalifikuje]
    FOREIGN KEY ([SeKvalifikujes_TurnirIdTurnira], [SeKvalifikujes_TimIdTima])
    REFERENCES [dbo].[SeKvalifikujes]
        ([TurnirIdTurnira], [TimIdTima])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Mecs_IdMeca] in table 'SeKvalifikujeMec'
ALTER TABLE [dbo].[SeKvalifikujeMec]
ADD CONSTRAINT [FK_SeKvalifikujeMec_Mec]
    FOREIGN KEY ([Mecs_IdMeca])
    REFERENCES [dbo].[Mecs]
        ([IdMeca])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SeKvalifikujeMec_Mec'
CREATE INDEX [IX_FK_SeKvalifikujeMec_Mec]
ON [dbo].[SeKvalifikujeMec]
    ([Mecs_IdMeca]);
GO

-- Creating foreign key on [Igracs_JMBG] in table 'IgracTim'
ALTER TABLE [dbo].[IgracTim]
ADD CONSTRAINT [FK_IgracTim_Igrac]
    FOREIGN KEY ([Igracs_JMBG])
    REFERENCES [dbo].[Ucesniks_Igrac]
        ([JMBG])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tims_IdTima] in table 'IgracTim'
ALTER TABLE [dbo].[IgracTim]
ADD CONSTRAINT [FK_IgracTim_Tim]
    FOREIGN KEY ([Tims_IdTima])
    REFERENCES [dbo].[Tims]
        ([IdTima])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IgracTim_Tim'
CREATE INDEX [IX_FK_IgracTim_Tim]
ON [dbo].[IgracTim]
    ([Tims_IdTima]);
GO

-- Creating foreign key on [JMBG] in table 'Ucesniks_Trener'
ALTER TABLE [dbo].[Ucesniks_Trener]
ADD CONSTRAINT [FK_Trener_inherits_Ucesnik]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Ucesniks]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Ucesniks_Sudija'
ALTER TABLE [dbo].[Ucesniks_Sudija]
ADD CONSTRAINT [FK_Sudija_inherits_Ucesnik]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Ucesniks]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [JMBG] in table 'Ucesniks_Igrac'
ALTER TABLE [dbo].[Ucesniks_Igrac]
ADD CONSTRAINT [FK_Igrac_inherits_Ucesnik]
    FOREIGN KEY ([JMBG])
    REFERENCES [dbo].[Ucesniks]
        ([JMBG])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------