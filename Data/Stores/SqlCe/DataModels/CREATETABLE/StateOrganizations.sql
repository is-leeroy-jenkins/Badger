CREATE TABLE StateOrganizations
(
	StateOrganizationsId INT           NOT NULL UNIQUE,
	Name                 NVARCHAR(150) NULL DEFAULT ('NS'),
	Code                 NVARCHAR(150) NULL DEFAULT ('NS'),
	OrgCode              NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioName             NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode             NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT StateOrganizationsPrimaryKey PRIMARY KEY
		(
		  StateOrganizationsId
			)
);
