CREATE TABLE AppropriationDocuments
(
	AppropriationDocumentsId      INT           NOT NULL UNIQUE,
	FiscalYear                    NVARCHAR(150) NULL DEFAULT ('NS'),
	BFY                           NVARCHAR(150) NULL DEFAULT ('NS'),
	EFY                           NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode                      NVARCHAR(150) NULL DEFAULT ('NS'),
	AppropriationFund             NVARCHAR(150) NULL DEFAULT ('NS'),
	DocumentType                  NVARCHAR(150) NULL DEFAULT ('NS'),
	DocumentNumber                NVARCHAR(150) NULL DEFAULT ('NS'),
	DocumentDate                  DATETIME      NULL,
	BudgetLevel                   NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetingControls             NVARCHAR(150) NULL DEFAULT ('NS'),
	PostingControls               NVARCHAR(150) NULL DEFAULT ('NS'),
	PreCommitmentControls         NVARCHAR(150) NULL DEFAULT ('NS'),
	CommitmentControls            NVARCHAR(150) NULL DEFAULT ('NS'),
	ObligationControls            NVARCHAR(150) NULL DEFAULT ('NS'),
	AccrualControls               NVARCHAR(150) NULL DEFAULT ('NS'),
	ExpenditureControls           NVARCHAR(255) NULL,
	ExpenseControls               NVARCHAR(150) NULL DEFAULT ('NS'),
	ReimbursementControls         NVARCHAR(150) NULL DEFAULT ('NS'),
	ReimbursableAgreementControls NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasuryAccountCode           NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasuryAccountName           NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountCode             NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountName             NVARCHAR(150) NULL DEFAULT ('NS'),
	Budgeted                      FLOAT         NULL DEFAULT (0.0),
	Posted                        FLOAT         NULL DEFAULT (0.0),
	CarryoverOut                  FLOAT         NULL DEFAULT (0.0),
	CarryoverIn                   FLOAT         NULL DEFAULT (0.0),
	Reimbursements                FLOAT         NULL DEFAULT (0.0),
	Recoveries                    FLOAT         NULL DEFAULT (0.0),
	CONSTRAINT AppropriationDocumentsPrimaryKey PRIMARY KEY
		(
		  AppropriationDocumentsId
			)
);
