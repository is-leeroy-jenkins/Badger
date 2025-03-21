CREATE TABLE StatusOfSuperfundSites
(
	StatusOfSuperfundSitesId INT           NOT NULL UNIQUE,
	FiscalYear               NVARCHAR(150) NULL DEFAULT ('NS'),
	BFY                      NVARCHAR(150) NULL DEFAULT ('NS'),
	EFY                      NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode                 NVARCHAR(150) NULL DEFAULT ('NS'),
	FundName                 NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode                 NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioName                 NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramProjectCode       NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramProjectName       NVARCHAR(150) NULL DEFAULT ('NS'),
	StateCode                NVARCHAR(150) NULL DEFAULT ('NS'),
	StateName                NVARCHAR(150) NULL DEFAULT ('NS'),
	CountyName               NVARCHAR(150) NULL DEFAULT ('NS'),
	CityName                 NVARCHAR(150) NULL DEFAULT ('NS'),
	StreetAddress            NVARCHAR(150) NULL DEFAULT ('NS'),
	ZipCode                  NVARCHAR(150) NULL DEFAULT ('NS'),
	SiteId                   NVARCHAR(150) NULL DEFAULT ('NS'),
	SiteName                 NVARCHAR(150) NULL DEFAULT ('NS'),
	Obligations              FLOAT         NULL DEFAULT (0.0),
	Deobligations            FLOAT         NULL DEFAULT (0.0),
	Expenditures             FLOAT         NULL DEFAULT (0.0),
	CONSTRAINT StatusOfSuperfundSitesPrimaryKey PRIMARY KEY
		(
		  StatusOfSuperfundSitesId ASC
			)
);
