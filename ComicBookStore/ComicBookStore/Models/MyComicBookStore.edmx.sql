
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/04/2024 12:59:35
-- Generated from EDMX file: C:\.NET Assingment\Assignment-5\ComicBookStore\ComicBookStore\Models\MyComicBookStore.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyComicBookStore];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Writers'
CREATE TABLE [dbo].[Writers] (
    [WriterId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Age] int  NOT NULL
);
GO

-- Creating table 'ComicBooks'
CREATE TABLE [dbo].[ComicBooks] (
    [ComicBookId] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Published] datetime  NOT NULL,
    [PublisherPublisherId] int  NOT NULL
);
GO

-- Creating table 'Publishers'
CREATE TABLE [dbo].[Publishers] (
    [PublisherId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Authoreds'
CREATE TABLE [dbo].[Authoreds] (
    [AuthoredId] int IDENTITY(1,1) NOT NULL,
    [WriterId] int  NOT NULL,
    [ComicBookId] int  NOT NULL,
    [WriterWriterId] int  NOT NULL,
    [ComicBookComicBookId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [WriterId] in table 'Writers'
ALTER TABLE [dbo].[Writers]
ADD CONSTRAINT [PK_Writers]
    PRIMARY KEY CLUSTERED ([WriterId] ASC);
GO

-- Creating primary key on [ComicBookId] in table 'ComicBooks'
ALTER TABLE [dbo].[ComicBooks]
ADD CONSTRAINT [PK_ComicBooks]
    PRIMARY KEY CLUSTERED ([ComicBookId] ASC);
GO

-- Creating primary key on [PublisherId] in table 'Publishers'
ALTER TABLE [dbo].[Publishers]
ADD CONSTRAINT [PK_Publishers]
    PRIMARY KEY CLUSTERED ([PublisherId] ASC);
GO

-- Creating primary key on [AuthoredId] in table 'Authoreds'
ALTER TABLE [dbo].[Authoreds]
ADD CONSTRAINT [PK_Authoreds]
    PRIMARY KEY CLUSTERED ([AuthoredId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [WriterWriterId] in table 'Authoreds'
ALTER TABLE [dbo].[Authoreds]
ADD CONSTRAINT [FK_WriterAuthored]
    FOREIGN KEY ([WriterWriterId])
    REFERENCES [dbo].[Writers]
        ([WriterId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_WriterAuthored'
CREATE INDEX [IX_FK_WriterAuthored]
ON [dbo].[Authoreds]
    ([WriterWriterId]);
GO

-- Creating foreign key on [ComicBookComicBookId] in table 'Authoreds'
ALTER TABLE [dbo].[Authoreds]
ADD CONSTRAINT [FK_ComicBookAuthored]
    FOREIGN KEY ([ComicBookComicBookId])
    REFERENCES [dbo].[ComicBooks]
        ([ComicBookId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComicBookAuthored'
CREATE INDEX [IX_FK_ComicBookAuthored]
ON [dbo].[Authoreds]
    ([ComicBookComicBookId]);
GO

-- Creating foreign key on [PublisherPublisherId] in table 'ComicBooks'
ALTER TABLE [dbo].[ComicBooks]
ADD CONSTRAINT [FK_PublisherComicBook]
    FOREIGN KEY ([PublisherPublisherId])
    REFERENCES [dbo].[Publishers]
        ([PublisherId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PublisherComicBook'
CREATE INDEX [IX_FK_PublisherComicBook]
ON [dbo].[ComicBooks]
    ([PublisherPublisherId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------