
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/23/2022 12:09:26
-- Generated from EDMX file: C:\Users\user\Desktop\курсовая\ПОследняя курсовая\WpfApp6\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DBDBDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserPhoto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PhotoSet] DROP CONSTRAINT [FK_UserPhoto];
GO
IF OBJECT_ID(N'[dbo].[FK_PhotoAuthorOfPhoto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AuthorOfPhotoSet] DROP CONSTRAINT [FK_PhotoAuthorOfPhoto];
GO
IF OBJECT_ID(N'[dbo].[FK_PhotoPlaceOfPhoto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlaceOfPhotoSet] DROP CONSTRAINT [FK_PhotoPlaceOfPhoto];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[PhotoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhotoSet];
GO
IF OBJECT_ID(N'[dbo].[AuthorOfPhotoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AuthorOfPhotoSet];
GO
IF OBJECT_ID(N'[dbo].[PlaceOfPhotoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlaceOfPhotoSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Role] nvarchar(max)  NOT NULL,
    [Storage] int  NOT NULL,
    [NumberOfPhotos] int  NOT NULL,
    [MaxStorage] int  NOT NULL
);
GO

-- Creating table 'PhotoSet'
CREATE TABLE [dbo].[PhotoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Resolution] nvarchar(max)  NOT NULL,
    [Size] int  NOT NULL,
    [Format] nvarchar(max)  NOT NULL,
    [PhotoName] nvarchar(max)  NOT NULL,
    [Time] nvarchar(max)  NOT NULL,
    [PhotoString] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'AuthorOfPhotoSet'
CREATE TABLE [dbo].[AuthorOfPhotoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [Street] nvarchar(max)  NOT NULL,
    [House] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Photo_Id] int  NOT NULL
);
GO

-- Creating table 'PlaceOfPhotoSet'
CREATE TABLE [dbo].[PlaceOfPhotoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Landscape] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Photo_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PhotoSet'
ALTER TABLE [dbo].[PhotoSet]
ADD CONSTRAINT [PK_PhotoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AuthorOfPhotoSet'
ALTER TABLE [dbo].[AuthorOfPhotoSet]
ADD CONSTRAINT [PK_AuthorOfPhotoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlaceOfPhotoSet'
ALTER TABLE [dbo].[PlaceOfPhotoSet]
ADD CONSTRAINT [PK_PlaceOfPhotoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'PhotoSet'
ALTER TABLE [dbo].[PhotoSet]
ADD CONSTRAINT [FK_UserPhoto]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserPhoto'
CREATE INDEX [IX_FK_UserPhoto]
ON [dbo].[PhotoSet]
    ([UserId]);
GO

-- Creating foreign key on [Photo_Id] in table 'AuthorOfPhotoSet'
ALTER TABLE [dbo].[AuthorOfPhotoSet]
ADD CONSTRAINT [FK_PhotoAuthorOfPhoto]
    FOREIGN KEY ([Photo_Id])
    REFERENCES [dbo].[PhotoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhotoAuthorOfPhoto'
CREATE INDEX [IX_FK_PhotoAuthorOfPhoto]
ON [dbo].[AuthorOfPhotoSet]
    ([Photo_Id]);
GO

-- Creating foreign key on [Photo_Id] in table 'PlaceOfPhotoSet'
ALTER TABLE [dbo].[PlaceOfPhotoSet]
ADD CONSTRAINT [FK_PhotoPlaceOfPhoto]
    FOREIGN KEY ([Photo_Id])
    REFERENCES [dbo].[PhotoSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhotoPlaceOfPhoto'
CREATE INDEX [IX_FK_PhotoPlaceOfPhoto]
ON [dbo].[PlaceOfPhotoSet]
    ([Photo_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------