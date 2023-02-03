USE [master]

IF db_id('FabricFinder') IS NULl
  CREATE DATABASE [FabricFinder]
GO

USE [FabricFinder]
GO


DROP TABLE IF EXISTS [PatternFabric];
DROP TABLE IF EXISTS [Fabric];
DROP TABLE IF EXISTS [FabricType];
DROP TABLE IF EXISTS [Pattern];
DROP TABLE IF EXISTS [UserProfile];
GO


CREATE TABLE [Fabric] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Color] nvarchar(255) NOT NULL,
  [Yardage] float,
  [ImageUrl] image,
  [UserId] int NOT NULL,
  [FabricTypeId] int NOT NULL
)
GO

CREATE TABLE [UserProfile] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [FirebaseUserId] nvarchar(255) UNIQUE,
  [Email] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Pattern] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Name] nvarchar(255) NOT NULL,
  [ImageUrl] image
)
GO

CREATE TABLE [PatternFabric] (
  [PatternId] int,
  [FabricId] int
)
GO

CREATE TABLE [FabricType] (
  [Id] int PRIMARY KEY IDENTITY(1, 1),
  [Yype] nvarchar(255) NOT NULL
)
GO

ALTER TABLE [Fabric] ADD FOREIGN KEY ([FabricTypeId]) REFERENCES [FabricType] ([Id])
GO

ALTER TABLE [PatternFabric] ADD FOREIGN KEY ([FabricId]) REFERENCES [Fabric] ([Id]) ON DELETE CASCADE
GO

ALTER TABLE [PatternFabric] ADD FOREIGN KEY ([PatternId]) REFERENCES [Pattern] ([id])
GO

ALTER TABLE [Fabric] ADD FOREIGN KEY ([UserId]) REFERENCES [UserProfile] ([Id])
GO