CREATE TABLE Deobligations
(
	DeobligationsId     AUTOINCREMENT NOT NULL UNIQUE,
	BFY                 TEXT( 150 )   NULL DEFAULT NS,
	EFY                 TEXT( 150 )   NULL DEFAULT NS,
	FundCode            TEXT( 150 )   NULL DEFAULT NS,
	FundName            TEXT( 150 )   NULL DEFAULT NS,
	TreasuryAccountCode TEXT( 150 )   NULL DEFAULT NS,
	BudgetAccountCode   TEXT( 150 )   NULL DEFAULT NS,
	BudgetAccountName   TEXT( 150 )   NULL DEFAULT NS,
	RpioCode            TEXT( 150 )   NULL DEFAULT NS,
	RpioName            TEXT( 150 )   NULL DEFAULT NS,
	AhCode              TEXT( 150 )   NULL DEFAULT NS,
	AhName              TEXT( 150 )   NULL DEFAULT NS,
	AccountCode         TEXT( 150 )   NULL DEFAULT NS,
	NpmCode             TEXT( 150 )   NULL DEFAULT NS,
	NpmName             TEXT( 150 )   NULL DEFAULT NS,
	ProgramProjectCode  TEXT( 150 )   NULL DEFAULT NS,
	ProgramProjectName  TEXT( 150 )   NULL DEFAULT NS,
	OrgCode             TEXT( 150 )   NULL DEFAULT NS,
	OrgName             TEXT( 150 )   NULL DEFAULT NS,
	BocCode             TEXT( 150 )   NULL DEFAULT NS,
	BocName             TEXT( 150 )   NULL DEFAULT NS,
	DocumentNumber      TEXT( 150 )   NULL DEFAULT NS,
	FocCode             TEXT( 150 )   NULL DEFAULT NS,
	FocName             TEXT( 150 )   NULL DEFAULT NS,
	ProcessedDate       DATETIME      NULL,
	Amount              DOUBLE        NULL DEFAULT 0.0, CONSTRAINT
(
	DeobligationsPrimaryKey
)
	PRIMARY KEY
(
	DeobligationsId
)
	);
