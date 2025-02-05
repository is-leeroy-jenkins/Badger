CREATE TABLE RegionalOffices
(
	RegionalOfficesId         INT           NOT NULL UNIQUE,
	ResourcePlanningOfficesId INT           NULL,
	Code                      NVARCHAR(150) NULL DEFAULT ('NS'),
	Name                      NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT RegionalOfficesPrimaryKey PRIMARY KEY
		(
		  RegionalOfficesId ASC
			)
);
