﻿CREATE TABLE [dbo].[Task]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Description] NVARCHAR(250) NOT NULL, 
    [Deadline] DATETIME NULL

)
