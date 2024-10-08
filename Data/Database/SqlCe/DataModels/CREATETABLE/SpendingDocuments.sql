CREATE TABLE SpendingDocuments
(
	SpendingDocumentsId    INT           NOT NULL UNIQUE,
	BFY                    NVARCHAR(150) NULL DEFAULT ('NS'),
	EFY                    NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasurySymbol         NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode               NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioName               NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode               NVARCHAR(150) NULL DEFAULT ('NS'),
	FundName               NVARCHAR(150) NULL DEFAULT ('NS'),
	AhCode                 NVARCHAR(150) NULL DEFAULT ('NS'),
	AhName                 NVARCHAR(150) NULL DEFAULT ('NS'),
	AccountCode            NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioActivityCode       NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramProjectName     NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramAreaCode        NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramAreaName        NVARCHAR(150) NULL DEFAULT ('NS'),
	PurchaseRequestNumber  NVARCHAR(150) NULL DEFAULT ('NS'),
	DocumentType           NVARCHAR(150) NULL DEFAULT ('NS'),
	DocumentControlNumber  NVARCHAR(150) NULL DEFAULT ('NS'),
	BocCode                NVARCHAR(150) NULL DEFAULT ('NS'),
	BocName                NVARCHAR(150) NULL DEFAULT ('NS'),
	OriginalActionDate     DATETIME      NULL,
	LastActionDate         DATETIME      NULL,
	Commitments            FLOAT         NULL DEFAULT (0.0),
	Obligations            FLOAT         NULL DEFAULT (0.0),
	Deobligations          FLOAT         NULL DEFAULT (0.0),
	UnliqudatedObligations FLOAT         NULL DEFAULT (0.0),
	CONSTRAINT SpendingDocumentsPrimaryKey PRIMARY KEY
		(
		  SpendingDocumentsId
			)
);
