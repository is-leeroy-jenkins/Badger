CREATE TABLE SpendingDocuments
(
	SpendingDocumentsId    AUTOINCREMENT NOT NULL UNIQUE,
	BFY                    TEXT( 150 )   NULL DEFAULT NS,
	EFY                    TEXT( 150 )   NULL DEFAULT NS,
	TreasurySymbol         TEXT( 150 )   NULL DEFAULT NS,
	RpioCode               TEXT( 150 )   NULL DEFAULT NS,
	RpioName               TEXT( 150 )   NULL DEFAULT NS,
	FundCode               TEXT( 150 )   NULL DEFAULT NS,
	FundName               TEXT( 150 )   NULL DEFAULT NS,
	AhCode                 TEXT( 150 )   NULL DEFAULT NS,
	AhName                 TEXT( 150 )   NULL DEFAULT NS,
	AccountCode            TEXT( 150 )   NULL DEFAULT NS,
	RpioActivityCode       TEXT( 150 )   NULL DEFAULT NS,
	ProgramProjectName     TEXT( 150 )   NULL DEFAULT NS,
	ProgramAreaCode        TEXT( 150 )   NULL DEFAULT NS,
	ProgramAreaName        TEXT( 150 )   NULL DEFAULT NS,
	PurchaseRequestNumber  TEXT( 150 )   NULL DEFAULT NS,
	DocumentType           TEXT( 150 )   NULL DEFAULT NS,
	DocumentControlNumber  TEXT( 150 )   NULL DEFAULT NS,
	BocCode                TEXT( 150 )   NULL DEFAULT NS,
	BocName                TEXT( 150 )   NULL DEFAULT NS,
	OriginalActionDate     DATETIME      NULL,
	LastActionDate         DATETIME      NULL,
	Commitments            DOUBLE        NULL DEFAULT 0.0,
	Obligations            DOUBLE        NULL DEFAULT 0.0,
	Deobligations          DOUBLE        NULL DEFAULT 0.0,
	UnliqudatedObligations DOUBLE        NULL DEFAULT 0.0, CONSTRAINT
(
	SpendingDocumentsPrimaryKey
)
	PRIMARY KEY
(
	SpendingDocumentsId
)
	);
