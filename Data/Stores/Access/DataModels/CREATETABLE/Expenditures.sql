CREATE TABLE Expenditures
(
	ExpendituresId        AUTOINCREMENT NOT NULL UNIQUE,
	ObligationsId         INT           NULL,
	BFY                   TEXT( 150 )   NULL DEFAULT NS,
	EFY                   TEXT( 150 )   NULL DEFAULT NS,
	FundCode              TEXT( 150 )   NULL DEFAULT NS,
	FundName              TEXT( 150 )   NULL DEFAULT NS,
	TreasuryAccountCode   TEXT( 150 )   NULL DEFAULT NS,
	RpioCode              TEXT( 150 )   NULL DEFAULT NS,
	RpioName              TEXT( 150 )   NULL DEFAULT NS,
	AhCode                TEXT( 150 )   NULL DEFAULT NS,
	AhName                TEXT( 150 )   NULL DEFAULT NS,
	OrgCode               TEXT( 150 )   NULL DEFAULT NS,
	OrgName               TEXT( 150 )   NULL DEFAULT NS,
	AccountCode           TEXT( 150 )   NULL DEFAULT NS,
	ProgramProjectCode    TEXT( 150 )   NULL DEFAULT NS,
	ProgramProjectName    TEXT( 150 )   NULL DEFAULT NS,
	RcCode                TEXT( 150 )   NULL DEFAULT NS,
	RcName                TEXT( 150 )   NULL DEFAULT NS,
	DocumentType          TEXT( 150 )   NULL DEFAULT NS,
	DocumentNumber        TEXT( 150 )   NULL DEFAULT NS,
	DocumentControlNumber TEXT( 150 )   NULL DEFAULT NS,
	ProcessedDate         DATETIME      NULL,
	LastActivityDate      DATETIME      NULL,
	Age                   DOUBLE        NULL DEFAULT 0.0,
	BocCode               TEXT( 255 )   NULL DEFAULT NS,
	BocName               TEXT( 150 )   NULL DEFAULT NS,
	FocCode               TEXT( 150 )   NULL DEFAULT NS,
	FocName               TEXT( 150 )   NULL DEFAULT NS,
	NpmCode               TEXT( 150 )   NULL DEFAULT NS,
	NpmName               TEXT( 150 )   NULL DEFAULT NS,
	VendorCode            TEXT( 150 )   NULL DEFAULT NS,
	VendorName            TEXT( 150 )   NULL DEFAULT NS,
	Amount                DOUBLE        NULL DEFAULT 0.0,
	TreasuryAccountName   TEXT( MAX )   NULL DEFAULT NS,
	BudgetAccountCode     TEXT( 150 )   NULL DEFAULT NS,
	BudgetAccountName     TEXT( MAX )   NULL DEFAULT NS, CONSTRAINT
(
	ExpendituresPrimaryKey
)
	PRIMARY KEY
(
	ExpendituresId
)
	);
