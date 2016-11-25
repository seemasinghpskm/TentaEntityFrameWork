CREATE PROCEDURE AddTerritory  (@TerritoryID nvarchar(20)
           ,@TerritoryDescription nchar(50)
           ,@RegionID int)
AS

INSERT INTO [dbo].[Territories]
           ([TerritoryID]
           ,[TerritoryDescription]
           ,[RegionID])
     VALUES
           (@TerritoryID 
           ,@TerritoryDescription
           ,@RegionID )