CREATE TABLE NationalPrograms
(
	NationalProgramsId AUTOINCREMENT  NOT NULL UNIQUE,
	Code               TEXT( 80 ) NOT NULL,
	Name               TEXT( 150 )    NULL DEFAULT NS,
	RpioCode           TEXT( 150 )    NULL DEFAULT NS,
	Title              TEXT( 150 )    NULL DEFAULT NS, CONSTRAINT
(
	NationalProgramsPrimaryKey
)
	PRIMARY KEY
(
	NationalProgramsId
)
	);
