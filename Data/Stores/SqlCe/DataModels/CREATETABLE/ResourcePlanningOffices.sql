CREATE TABLE ResourcePlanningOffices
(
	ResourcePlanningOfficesId INT           NOT NULL UNIQUE,
	Code                      NVARCHAR(150) NULL DEFAULT ('NS'),
	Name                      NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT ResourcePlanningOfficesPrimaryKey PRIMARY KEY
		(
		  ResourcePlanningOfficesId
			)
);
