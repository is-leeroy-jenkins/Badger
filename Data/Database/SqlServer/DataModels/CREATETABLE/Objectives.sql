CREATE TABLE Objectives
(
	ObjectivesId INT           NOT NULL UNIQUE,
	Code         NVARCHAR(150) NULL DEFAULT ('NS'),
	Name         NVARCHAR(150) NULL DEFAULT ('NS'),
	Title        NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT ObjectivesPrimaryKey PRIMARY KEY
		(
		  ObjectivesId ASC
			)
);
