CREATE TABLE IF NOT EXISTS ReportingLines
(
	ReportingLinesId INTEGER NOT NULL UNIQUE,
	Number TEXT(150) NULL DEFAULT NS,
	Name TEXT(150) NULL DEFAULT NS,
	Caption TEXT(150) NULL DEFAULT NS,
	Category TEXT(150) NULL DEFAULT NS,
	Range TEXT(150) NULL DEFAULT NS,
	CONSTRAINT ReportingLinesPrimaryKey 
		PRIMARY KEY(ReportingLinesId)
);
