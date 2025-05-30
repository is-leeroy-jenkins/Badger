CREATE TABLE ApportionmentData
(
	ApportionmentDataId      INT           NOT NULL UNIQUE,
	FiscalYear               NVARCHAR(150) NULL DEFAULT ('NS'),
	BFY                      NVARCHAR(150) NULL DEFAULT ('NS'),
	EFY                      NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasuryAccountCode      NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasuryAccountName      NVARCHAR(150) NULL DEFAULT ('NS'),
	ApportionmentAccountCode NVARCHAR(150) NULL DEFAULT ('NS'),
	ApportionmentAccountName NVARCHAR(150) NULL DEFAULT ('NS'),
	AvailabilityType         NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountCode        NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountName        NVARCHAR(150) NULL DEFAULT ('NS'),
	ApprovalDate             DATETIME      NULL,
	LineNumber               NVARCHAR(150) NULL DEFAULT ('NS'),
	LineName                 NVARCHAR(150) NULL DEFAULT ('NS'),
	Amount                   FLOAT         NULL DEFAULT (0.0),
	FundCode                 NVARCHAR(150) NULL DEFAULT ('NS'),
	FundName                 NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT ApportionmentDataPrimaryKey PRIMARY KEY
		(
		  ApportionmentDataId
			)
);
