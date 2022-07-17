USE [happetDB]
GO

INSERT INTO [dbo].[Vaccines]
           ([Id]
           ,[Description]
           ,[CreateDate])
     VALUES
           (NEWID(),
           'Antirrábica',
           GETDATE())

INSERT INTO [dbo].[Vaccines]
           ([Id]
           ,[Description]
           ,[CreateDate])
     VALUES
           (NEWID(),
           'Leishmaniose',
           GETDATE())

INSERT INTO [dbo].[Vaccines]
           ([Id]
           ,[Description]
           ,[CreateDate])
     VALUES
           (NEWID(),
           'Contra Giárdia',
           GETDATE())

INSERT INTO [dbo].[Vaccines]
           ([Id]
           ,[Description]
           ,[CreateDate])
     VALUES
           (NEWID(),
           'V10',
           GETDATE())

INSERT INTO [dbo].[Vaccines]
           ([Id]
           ,[Description]
           ,[CreateDate])
     VALUES
           (NEWID(),
           'Cinomose',
           GETDATE())

INSERT INTO [dbo].[Vaccines]
           ([Id]
           ,[Description]
           ,[CreateDate])
     VALUES
           (NEWID(),
           'Parvovirose',
           GETDATE())