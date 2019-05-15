IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Cuisines] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Type] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Cuisines] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Dishs] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Description] nvarchar(500) NULL,
    [CuisineId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Dishs] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Dishs_Cuisines_CuisineId] FOREIGN KEY ([CuisineId]) REFERENCES [Cuisines] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Dishs_CuisineId] ON [Dishs] ([CuisineId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190515012447_init', N'2.2.4-servicing-10062');

GO

