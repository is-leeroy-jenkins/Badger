CREATE TABLE BudgetDocuments
(
	BudgetDocumentsId   INT           NOT NULL UNIQUE,
	BFY                 NVARCHAR(150) NULL DEFAULT ('NS'),
	EFY                 NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetLevel         NVARCHAR(150) NULL DEFAULT ('NS'),
	DocumentDate        DATETIME      NULL,
	DocumentType        NVARCHAR(150) NULL DEFAULT ('NS'),
	DocumentNumber      NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode            NVARCHAR(150) NULL DEFAULT ('NS'),
	FundName            NVARCHAR(150) NULL DEFAULT ('NS'),
	Budgeted            FLOAT         NULL DEFAULT (0.0),
	Posted              FLOAT         NULL DEFAULT (0.0),
	CarryoverOut        FLOAT         NULL DEFAULT (0.0),
	CarryoverIn         FLOAT         NULL DEFAULT (0.0),
	Recoveries          FLOAT         NULL DEFAULT (0.0),
	Reimbursements      FLOAT         NULL DEFAULT (0.0),
	TreasuryAccountCode NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasuryAccountName NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountCode   NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountName   NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT BudgetDocumentsPrimaryKey PRIMARY KEY
		(
		  BudgetDocumentsId
			)
);
