use PetsDb;

CREATE TABLE [Owners] (
  [Id] nvarchar(255) PRIMARY KEY,
  [FirstName] nvarchar(255) NOT NULL,
  [LastName] nvarchar(255) NOT NULL,
  [Email] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [OwnerPet] (
  [OwnerId] nvarchar(255),
  [PetId] nvarchar(255),
  [PetType] nvarchar(255) NOT NULL
)
GO

CREATE TABLE [Pet] (
  [Id] nvarchar(255) PRIMARY KEY,
  [Name] nvarchar(255),
  [Breed] nvarchar(255),
  [Birth] datetime NOT NULL,
  [FeededNo] int DEFAULT 0,
  [TrainingDegree] int DEFAULT 1,
  [AdultHeight] int NOT NULL,
  [AdultLength] int,
  [CatchesMice] bit DEFAULT 0
)
GO

ALTER TABLE [OwnerPet] ADD FOREIGN KEY ([OwnerId]) REFERENCES [Owners] ([Id])
GO

ALTER TABLE [OwnerPet] ADD FOREIGN KEY ([PetId]) REFERENCES [Pet] ([Id])
GO
