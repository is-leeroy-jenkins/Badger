CREATE TABLE FinanceObjectClasses
(
	FinanceObjectClassesId AUTOINCREMENT NOT NULL UNIQUE,
	Code                   TEXT( 150 )   NULL DEFAULT NS,
	Name                   TEXT( 150 )   NULL DEFAULT NS,
	BocCode                TEXT( 150 )   NULL DEFAULT NS,
	BocName                TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	FinanceObjectClassesPrimaryKey
)
	PRIMARY KEY
(
	FinanceObjectClassesId
)
	);
