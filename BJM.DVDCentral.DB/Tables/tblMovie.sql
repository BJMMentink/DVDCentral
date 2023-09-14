﻿CREATE TABLE [dbo].[tblMovies]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Title] VARCHAR(50) NOT NULL,
	[Description] VARCHAR(50) NOT NULL, 
    [Cost] FLOAT NOT NULL,
	[RatingId] INT NOT NULL,
	[FormatId] INT NOT NULL,
	[DirectorId] INT NOT NULL,
	[InStkQty] INT NOT NULL,
	[ImagePath] VARCHAR(250) NOT NULL
)