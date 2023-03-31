# Ingenium

### Sample project made using Modular Monolith architecture and MediatR

To run change connection string in appsettings.json and **possibly BaseAddress in WebUI Program.cs**

### Migration script (the migrations are applied automatically, but here is the actual script)
     IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
     BEGIN
         CREATE TABLE [__EFMigrationsHistory] (
             [MigrationId] nvarchar(150) NOT NULL,
             [ProductVersion] nvarchar(32) NOT NULL,
             CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
         );
     END;
     GO
     
     BEGIN TRANSACTION;
     GO
     
     IF SCHEMA_ID(N'Contacts') IS NULL EXEC(N'CREATE SCHEMA [Contacts];');
     GO
     
     CREATE TABLE [Contacts].[Contact] (
         [Id] bigint NOT NULL IDENTITY,
         [FirstName] nvarchar(256) NOT NULL,
         [LastName] nvarchar(256) NOT NULL,
         [IsActive] bit NOT NULL,
         [BirthDate] datetime2 NOT NULL,
         [Email] nvarchar(256) NOT NULL,
         [TelephoneNumber] nvarchar(32) NOT NULL,
         CONSTRAINT [PK_Contact] PRIMARY KEY ([Id])
     );
     GO
     
     INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
     VALUES (N'20230330181014_Initial', N'7.0.4');
     GO
     
     COMMIT;
     GO

