CREATE TABLE StatusOfAppropriations
(
	StatusOfAppropriationsId INT           NOT NULL UNIQUE,
	BFY                      NVARCHAR(150) NULL DEFAULT ('NS'),
	EFY                      NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetLevel              NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode                 NVARCHAR(150) NULL DEFAULT ('NS'),
	FundName                 NVARCHAR(150) NULL DEFAULT ('NS'),
	Availability             NVARCHAR(150) NULL DEFAULT ('NS'),
	TransType                NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasurySymbol           NVARCHAR(150) NULL DEFAULT ('NS'),
	OriginalAmount           FLOAT         NULL DEFAULT (0.0),
	Authority                FLOAT         NULL DEFAULT (0.0),
	Budgeted                 FLOAT         NULL DEFAULT (0.0),
	Posted                   FLOAT         NULL DEFAULT (0.0),
	CarryoverOut             FLOAT         NULL DEFAULT (0.0),
	CarryoverIn              FLOAT         NULL DEFAULT (0.0),
	TransferIn               FLOAT         NULL DEFAULT (0.0),
	TransferOut              FLOAT         NULL DEFAULT (0.0),
	OpenCommitments          FLOAT         NULL DEFAULT (0.0),
	Obligations              FLOAT         NULL DEFAULT (0.0),
	Used                     FLOAT         NULL DEFAULT (0.0),
	Expenditures             FLOAT         NULL DEFAULT (0.0),
	UnliquidatedObligations  FLOAT         NULL DEFAULT (0.0),
	Available                FLOAT         NULL DEFAULT (0.0),
	TreasuryAccountCode      NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasuryAccountName      NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountCode        NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountName        NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT StatusOfAppropriationsPrimaryKey PRIMARY KEY
		(
		  StatusOfAppropriationsId
			)
);
