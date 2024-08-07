CREATE TABLE Organizations
(
	OrganizationsId AUTOINCREMENT NOT NULL UNIQUE,
	BFY             TEXT( 150 )   NULL DEFAULT NS,
	Code            TEXT( 150 )   NULL DEFAULT NS,
	PreventNewUse   TEXT( 150 )   NULL DEFAULT NS,
	Name            TEXT( 150 )   NULL DEFAULT NS,
	Status          TEXT( 150 )   NULL DEFAULT NS,
	SecurityOrg     TEXT( 150 )   NULL DEFAULT NS,
	Usage           TEXT( 150 )   NULL DEFAULT NS,
	UseAsCostOrg    TEXT( 150 )   NULL DEFAULT NS,
	SubCodeRequired TEXT( 150 )   NULL DEFAULT NS,
	RpioCode        TEXT( 150 )   NULL DEFAULT NS,
	AhCode          TEXT( 150 )   NULL DEFAULT NS,
	RcCode          TEXT( 150 )   NULL DEFAULT NS,
	SubRcCode       TEXT( 150 )   NULL DEFAULT NS,
	Description     TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	OrganizationsPrimaryKey
)
	PRIMARY KEY
(
	OrganizationsId
)
	);
