CREATE TABLE CongressionalProjects
(
	CongressionalEarmarksId INT           NOT NULL UNIQUE,
	BFY                     NVARCHAR(150) NULL DEFAULT ('NS'),
	EFY                     NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode                NVARCHAR(150) NULL DEFAULT ('NS'),
	FundName                NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode                NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioName                NVARCHAR(150) NULL DEFAULT ('NS'),
	AhCode                  NVARCHAR(150) NULL DEFAULT ('NS'),
	AhName                  NVARCHAR(150) NULL DEFAULT ('NS'),
	NpmCode                 NVARCHAR(150) NULL DEFAULT ('NS'),
	NpmName                 NVARCHAR(150) NULL DEFAULT ('NS'),
	AccountCode             NVARCHAR(150) NULL DEFAULT ('NS'),
	BocCode                 NVARCHAR(150) NULL DEFAULT ('NS'),
	BocName                 NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramProjectCode      NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramProjectName      NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramAreaCode         NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramAreaName         NVARCHAR(150) NULL DEFAULT ('NS'),
	StateCode               NVARCHAR(150) NULL DEFAULT ('NS'),
	StateName               NVARCHAR(150) NULL DEFAULT ('NS'),
	Project                 NVARCHAR(150) NULL DEFAULT ('NS'),
	Amount                  FLOAT         NULL DEFAULT (0.0),
	TreasuryAccountCode     NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasuryAccountName     NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountCode       NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountName       NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT CongressionalProjectsPrimaryKey PRIMARY KEY
		(
		  CongressionalEarmarksId
			)
);
