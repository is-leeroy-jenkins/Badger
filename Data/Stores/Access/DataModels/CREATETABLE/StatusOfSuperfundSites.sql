CREATE TABLE StatusOfSuperfundSites
(
	StatusOfSuperfundSitesId AUTOINCREMENT NOT NULL UNIQUE,
	FiscalYear               TEXT( 150 )   NULL DEFAULT NS,
	BFY                      TEXT( 150 )   NULL DEFAULT NS,
	EFY                      TEXT( 150 )   NULL DEFAULT NS,
	FundCode                 TEXT( 150 )   NULL DEFAULT NS,
	FundName                 TEXT( 150 )   NULL DEFAULT NS,
	RpioCode                 TEXT( 150 )   NULL DEFAULT NS,
	RpioName                 TEXT( 150 )   NULL DEFAULT NS,
	ProgramProjectCode       TEXT( 150 )   NULL DEFAULT NS,
	ProgramProjectName       TEXT( 150 )   NULL DEFAULT NS,
	StateCode                TEXT( 150 )   NULL DEFAULT NS,
	StateName                TEXT( 150 )   NULL DEFAULT NS,
	CountyName               TEXT( 150 )   NULL DEFAULT NS,
	CityName                 TEXT( 150 )   NULL DEFAULT NS,
	StreetAddress            TEXT( 150 )   NULL DEFAULT NS,
	ZipCode                  TEXT( 150 )   NULL DEFAULT NS,
	SiteId                   TEXT( 150 )   NULL DEFAULT NS,
	SiteName                 TEXT( 150 )   NULL DEFAULT NS,
	Obligations              DOUBLE        NULL DEFAULT 0.0,
	Deobligations            DOUBLE        NULL DEFAULT 0.0,
	Expenditures             DOUBLE        NULL DEFAULT 0.0, CONSTRAINT
(
	StatusOfSuperfundSitesPrimaryKey
)
	PRIMARY KEY
(
	StatusOfSuperfundSitesId
)
	);
