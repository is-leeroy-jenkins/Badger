CREATE TABLE RecoveryAct
(
	RecoveryActId      INT           NOT NULL UNIQUE,
	BFY                NVARCHAR(150) NULL DEFAULT ('NS'),
	EFY                NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode           NVARCHAR(150) NULL DEFAULT ('NS'),
	FundName           NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode           NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioName           NVARCHAR(150) NULL DEFAULT ('NS'),
	OrgCode            NVARCHAR(150) NULL DEFAULT ('NS'),
	OrgName            NVARCHAR(150) NULL DEFAULT ('NS'),
	AccountCode        NVARCHAR(150) NULL DEFAULT ('NS'),
	ProgramProjectName NVARCHAR(150) NULL DEFAULT ('NS'),
	BocCode            NVARCHAR(150) NULL DEFAULT ('NS'),
	BocName            NVARCHAR(150) NULL DEFAULT ('NS'),
	Amount             FLOAT         NULL DEFAULT (0.0),
	CONSTRAINT RecoveryActPrimaryKey PRIMARY KEY
		(
		  RecoveryActId
			)
);
