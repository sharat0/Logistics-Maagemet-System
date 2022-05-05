CREATE TABLE [dbo].[customer]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [name] VARCHAR(50) NOT NULL, 
    [phone] BIGINT NOT NULL, 
    [address] VARCHAR(50) NOT NULL, 
    [city] VARCHAR(50) NOT NULL, 
    [pin] INT NOT NULL
)
