CREATE TABLE Allocations
(
	AllocationsId       AUTOINCREMENT NOT NULL UNIQUE,
	StatusOfFundsId     INTEGER       NOT NULL UNIQUE,
	BudgetLevel         TEXT( 150 )   NULL DEFAULT NS,
	BFY                 TEXT( 150 )   NULL DEFAULT NS,
	EFY                 TEXT( 150 )   NULL DEFAULT NS,
	FundCode            TEXT( 150 )   NULL DEFAULT NS,
	RpioCode            TEXT( 150 )   NULL DEFAULT NS,
	AhCode              TEXT( 150 )   NULL DEFAULT NS,
	OrgCode             TEXT( 150 )   NULL DEFAULT NS,
	AccountCode         TEXT( 150 )   NULL DEFAULT NS,
	BocCode             TEXT( 150 )   NULL DEFAULT NS,
	RcCode              TEXT( 150 )   NULL DEFAULT NS,
	Amount              FLOAT         NULL DEFAULT ('NS'),
	RpioName            TEXT( 150 )   NULL DEFAULT NS,
	FundName            TEXT( 150 )   NULL DEFAULT NS,
	AhName              TEXT( 150 )   NULL DEFAULT NS,
	BocName             TEXT( 150 )   NULL DEFAULT NS,
	RcName              TEXT( 150 )   NULL DEFAULT NS,
	OrgName             TEXT( 150 )   NULL DEFAULT NS,
	NpmName             TEXT( 150 )   NULL DEFAULT NS,
	NpmCode             TEXT( 150 )   NULL DEFAULT NS,
	ProgramProjectCode  TEXT( 150 )   NULL DEFAULT NS,
	ProgramProjectName  TEXT( 150 )   NULL DEFAULT NS,
	ProgramAreaCode     TEXT( 150 )   NULL DEFAULT NS,
	ProgramAreaName     TEXT( 150 )   NULL DEFAULT NS,
	TreasuryAccountCode TEXT( 150 )   NULL DEFAULT NS,
	TreasuryAccountName TEXT( 150 )   NULL DEFAULT NS,
	BudgetAccountCode   TEXT( 150 )   NULL DEFAULT NS,
	BudgetAccountName   TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	AllocationsPrimaryKey
) ) PRIMARY KEY(AllocationsId )
);
