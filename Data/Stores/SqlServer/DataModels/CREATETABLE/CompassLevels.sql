CREATE TABLE CompassLevels
(
	CompassLevelsId     INT           NOT NULL UNIQUE,
	BFY                 NVARCHAR(150) NULL DEFAULT ('NS'),
	EFY                 NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode            NVARCHAR(150) NULL DEFAULT ('NS'),
	FundName            NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasurySymbol      NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetLevel         NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode            NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioName            NVARCHAR(150) NULL DEFAULT ('NS'),
	AccountCode         NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramProjectName  NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramAreaCode     NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramAreaName     NVARCHAR(150) NULL DEFAULT ('NS'),
	Authority           FLOAT         NULL DEFAULT (0.0),
	CarryoverIn         FLOAT         NULL DEFAULT (0.0),
	CarryoverOut        FLOAT         NULL DEFAULT (0.0),
	Recoveries          FLOAT         NULL DEFAULT (0.0),
	Reimbursements      FLOAT         NULL DEFAULT (0.0),
	TreasuryAccountCode NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasuryAccountName NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountCode   NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountName   NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT CompassLevelsPrimaryKey PRIMARY KEY
		(
		  CompassLevelsId ASC
			)
);
