use PetsDb;

CREATE TABLE [Owners] (
  [Id] nvarchar(60) PRIMARY KEY,
  [FirstName] nvarchar(60) NOT NULL,
  [LastName] nvarchar(60) NOT NULL,
  [Email] nvarchar(60) NOT NULL
)
GO

CREATE TABLE [OwnerPet] (
  [OwnerId] nvarchar(60) NOT NULL,
  [PetId] nvarchar(60) NOT NULL,
  [PetType] nvarchar(60) NOT NULL,
  CONSTRAINT PK_OwnerPet PRIMARY KEY (OwnerId, PetId)
)
GO

CREATE TABLE [Pets] (
  [Id] nvarchar(60) PRIMARY KEY,
  [Name] nvarchar(60),
  [Breed] nvarchar(60),
  [Birth] datetime NOT NULL,
  [FeededNo] int DEFAULT 0,
  [TrainingDegree] int DEFAULT 1,
  [AdultHeight] int,
  [AdultLength] int,
  [CatchesMice] bit DEFAULT 0,
  [PetType] nvarchar(60) NOT NULL,
)
GO

ALTER TABLE [OwnerPet] ADD FOREIGN KEY ([OwnerId]) REFERENCES [Owners] ([Id])
GO

ALTER TABLE [OwnerPet] ADD FOREIGN KEY ([PetId]) REFERENCES [Pets] ([Id])
GO
