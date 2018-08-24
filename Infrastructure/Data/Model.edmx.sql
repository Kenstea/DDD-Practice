
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/22/2018 22:34:35
-- Generated from EDMX file: C:\Users\nctha\Source\Repos\SIMS Phase II\Gnnovation.SIMS\Infrastructure\Data\SimsModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Sims];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_Contacts_dbo_Enterprises_EnterpriseID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contacts] DROP CONSTRAINT [FK_dbo_Contacts_dbo_Enterprises_EnterpriseID];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_Servers_dbo_Enterprises_EnterpriseID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Servers] DROP CONSTRAINT [FK_dbo_Servers_dbo_Enterprises_EnterpriseID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Contacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contacts];
GO
IF OBJECT_ID(N'[dbo].[Enterprises]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Enterprises];
GO
IF OBJECT_ID(N'[dbo].[Servers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Servers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Contacts'
CREATE TABLE [dbo].[Contacts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EnterpriseId] int  NOT NULL,
    [FirstName] nvarchar(100)  NOT NULL,
    [MiddleName] nvarchar(max)  NULL,
    [LastName] nvarchar(100)  NOT NULL,
    [Email] nvarchar(100)  NOT NULL,
    [Phone] nvarchar(max)  NULL,
    [CreatedAt] datetime  NOT NULL,
    [ModifiedAt] datetime  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [ModifiedBy] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Enterprises'
CREATE TABLE [dbo].[Enterprises] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShortName] nvarchar(255)  NOT NULL,
    [FullName] nvarchar(255)  NOT NULL,
    [Address] nvarchar(300)  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [ModifiedAt] datetime  NOT NULL,
    [CreatedBy] nvarchar(max)  NULL,
    [ModifiedBy] nvarchar(max)  NULL
);
GO

-- Creating table 'Servers'
CREATE TABLE [dbo].[Servers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(255)  NOT NULL,
    [Description] nvarchar(255)  NULL,
    [StatusId] int  NOT NULL,
    [EnterpriseId] int  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [ModifiedAt] datetime  NOT NULL,
    [CreatedBy] nvarchar(max)  NULL,
    [ModifiedBy] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [PK_Contacts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Enterprises'
ALTER TABLE [dbo].[Enterprises]
ADD CONSTRAINT [PK_Enterprises]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Servers'
ALTER TABLE [dbo].[Servers]
ADD CONSTRAINT [PK_Servers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EnterpriseId] in table 'Contacts'
ALTER TABLE [dbo].[Contacts]
ADD CONSTRAINT [FK_dbo_Contacts_dbo_Enterprises_EnterpriseID]
    FOREIGN KEY ([EnterpriseId])
    REFERENCES [dbo].[Enterprises]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Contacts_dbo_Enterprises_EnterpriseID'
CREATE INDEX [IX_FK_dbo_Contacts_dbo_Enterprises_EnterpriseID]
ON [dbo].[Contacts]
    ([EnterpriseId]);
GO

-- Creating foreign key on [EnterpriseId] in table 'Servers'
ALTER TABLE [dbo].[Servers]
ADD CONSTRAINT [FK_dbo_Servers_dbo_Enterprises_EnterpriseID]
    FOREIGN KEY ([EnterpriseId])
    REFERENCES [dbo].[Enterprises]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_Servers_dbo_Enterprises_EnterpriseID'
CREATE INDEX [IX_FK_dbo_Servers_dbo_Enterprises_EnterpriseID]
ON [dbo].[Servers]
    ([EnterpriseId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------