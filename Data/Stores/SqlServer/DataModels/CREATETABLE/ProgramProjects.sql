CREATE TABLE ProgramProjects
(
	ProgramProjectsId INT           NOT NULL UNIQUE,
	Code              NVARCHAR(150) NULL DEFAULT ('NS'),
	Name              NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramAreaCode   NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramAreaName   NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT ProgramProjectsPrimaryKey PRIMARY KEY
		(
		  ProgramProjectsId ASC
			)
);
