CREATE TABLE HeadquartersOffices
(
	HeadquartersOfficesId     INT           NOT NULL UNIQUE,
	ResourcePlanningOfficesId INT           NULL,
	Code                      NVARCHAR(150) NULL DEFAULT ('NS'),
	Name                      NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT HeadquartersOfficesPrimaryKey PRIMARY KEY
		(
		  HeadquartersOfficesId ASC
			)
);
