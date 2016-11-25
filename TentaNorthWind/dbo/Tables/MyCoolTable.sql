CREATE TABLE [dbo].[MyCoolTable] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [CoolTitle] NVARCHAR (25) NULL,
    CONSTRAINT [PK_MyCoolTable] PRIMARY KEY CLUSTERED ([ID] ASC)
);

