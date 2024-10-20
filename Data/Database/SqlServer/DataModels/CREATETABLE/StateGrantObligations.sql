CREATE TABLE StateGrantObligations
(
	StateGrantObligationsId INT           NOT NULL UNIQUE,
	BFY                     NVARCHAR(150) NULL DEFAULT ('NS'),
	EFY                     NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode                NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioName                NVARCHAR(150) NULL DEFAULT ('NS'),
	AhCode                  NVARCHAR(150) NULL DEFAULT ('NS'),
	AhName                  NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode                NVARCHAR(150) NULL DEFAULT ('NS'),
	FundName                NVARCHAR(150) NULL DEFAULT ('NS'),
	Approp                  Code NVARCHAR(150) NULL DEFAULT ('NS'),
	Approp                  Code Short TItle NVARCHAR (150) NULL DEFAULT ('NS'),
	OrgCode                 NVARCHAR(150) NULL DEFAULT ('NS'),
	OrgName                 NVARCHAR(150) NULL DEFAULT ('NS'),
	AccountCode             NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramProjectCode      NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramProjectName      NVARCHAR(150) NULL DEFAULT ('NS'),
	BocCode                 NVARCHAR(150) NULL DEFAULT ('NS'),
	BocName                 NVARCHAR(150) NULL DEFAULT ('NS'),
	RcCode                  NVARCHAR(150) NULL DEFAULT ('NS'),
	RcName                  NVARCHAR(150) NULL DEFAULT ('NS'),
	StateCode               NVARCHAR(150) NULL DEFAULT ('NS'),
	StateName               NVARCHAR(150) NULL DEFAULT ('NS'),
	Amount                  FLOAT         NULL DEFAULT (0.0),
	WholeDollars            FLOAT         NULL DEFAULT (0.0),
	CONSTRAINT StateGrantObligationsPrimaryKey PRIMARY KEY
		(
		  StateGrantObligationsId ASC
			)
);
