CREATE TABLE MonthlyActuals
(
	MonthlyActualsId     INT           NOT NULL UNIQUE,
	BFY                  NVARCHAR(150) NULL DEFAULT ('NS'),
	EFY                  NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode             NVARCHAR(150) NULL DEFAULT ('NS'),
	FundName             NVARCHAR(150) NULL DEFAULT ('NS'),
	AppropriationCode    NVARCHAR(150) NULL DEFAULT ('NS'),
	AppropriationName    NVARCHAR(150) NULL DEFAULT ('NS'),
	SubAppropriationCode NVARCHAR(150) NULL DEFAULT ('NS'),
	SubAppropriationName NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode             NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioName             NVARCHAR(150) NULL DEFAULT ('NS'),
	AhCode               NVARCHAR(150) NULL DEFAULT ('NS'),
	AhName               NVARCHAR(150) NULL DEFAULT ('NS'),
	OrgCode              NVARCHAR(150) NULL DEFAULT ('NS'),
	OrgName              NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioActivityCode     NVARCHAR(150) NULL DEFAULT ('NS'),
	AccountCode          NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramProjectCode   NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramProjectName   NVARCHAR(150) NULL DEFAULT ('NS'),
	BocCode              NVARCHAR(150) NULL DEFAULT ('NS'),
	BocName              NVARCHAR(150) NULL DEFAULT ('NS'),
	NetOutlays           FLOAT         NULL DEFAULT (0.0),
	GrossOutlays         FLOAT         NULL DEFAULT (0.0),
	Obligations          FLOAT         NULL DEFAULT (0.0),
	TreasuryAccountCode  NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasuryAccountName  NVARCHAR(MAX) NULL,
	BudgetAccountCode    NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountName    NVARCHAR(MAX) NULL,
	CONSTRAINT MonthlyActualsPrimaryKey PRIMARY KEY
		(
		  MonthlyActualsId ASC
			)
);
