
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/20/2016 02:20:59
-- Generated from EDMX file: G:\AgendamentoMonitoria\App_Code\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MonitoriaHorario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HorarioSet] DROP CONSTRAINT [FK_MonitoriaHorario];
GO
IF OBJECT_ID(N'[dbo].[FK_MonitorMonitoria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioSet_Monitor] DROP CONSTRAINT [FK_MonitorMonitoria];
GO
IF OBJECT_ID(N'[dbo].[FK_Monitor_inherits_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioSet_Monitor] DROP CONSTRAINT [FK_Monitor_inherits_Usuario];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UsuarioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioSet];
GO
IF OBJECT_ID(N'[dbo].[HorarioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HorarioSet];
GO
IF OBJECT_ID(N'[dbo].[MonitoriaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MonitoriaSet];
GO
IF OBJECT_ID(N'[dbo].[UsuarioSet_Monitor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioSet_Monitor];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UsuarioSet'
CREATE TABLE [dbo].[UsuarioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [Senha] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Curso] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'HorarioSet'
CREATE TABLE [dbo].[HorarioSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Inicio] time  NOT NULL,
    [Fim] time  NOT NULL,
    [Dia] nvarchar(max)  NOT NULL,
    [Monitoria_Id] int  NOT NULL
);
GO

-- Creating table 'MonitoriaSet'
CREATE TABLE [dbo].[MonitoriaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UsuarioSet_Monitor'
CREATE TABLE [dbo].[UsuarioSet_Monitor] (
    [Id] int  NOT NULL,
    [Monitoria_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UsuarioSet'
ALTER TABLE [dbo].[UsuarioSet]
ADD CONSTRAINT [PK_UsuarioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'HorarioSet'
ALTER TABLE [dbo].[HorarioSet]
ADD CONSTRAINT [PK_HorarioSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MonitoriaSet'
ALTER TABLE [dbo].[MonitoriaSet]
ADD CONSTRAINT [PK_MonitoriaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsuarioSet_Monitor'
ALTER TABLE [dbo].[UsuarioSet_Monitor]
ADD CONSTRAINT [PK_UsuarioSet_Monitor]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Monitoria_Id] in table 'HorarioSet'
ALTER TABLE [dbo].[HorarioSet]
ADD CONSTRAINT [FK_MonitoriaHorario]
    FOREIGN KEY ([Monitoria_Id])
    REFERENCES [dbo].[MonitoriaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MonitoriaHorario'
CREATE INDEX [IX_FK_MonitoriaHorario]
ON [dbo].[HorarioSet]
    ([Monitoria_Id]);
GO

-- Creating foreign key on [Monitoria_Id] in table 'UsuarioSet_Monitor'
ALTER TABLE [dbo].[UsuarioSet_Monitor]
ADD CONSTRAINT [FK_MonitorMonitoria]
    FOREIGN KEY ([Monitoria_Id])
    REFERENCES [dbo].[MonitoriaSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MonitorMonitoria'
CREATE INDEX [IX_FK_MonitorMonitoria]
ON [dbo].[UsuarioSet_Monitor]
    ([Monitoria_Id]);
GO

-- Creating foreign key on [Id] in table 'UsuarioSet_Monitor'
ALTER TABLE [dbo].[UsuarioSet_Monitor]
ADD CONSTRAINT [FK_Monitor_inherits_Usuario]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[UsuarioSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------