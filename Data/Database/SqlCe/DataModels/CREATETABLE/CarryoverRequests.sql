CREATE TABLE CarryoverRequests
(
	CarryoverRequestsId     INT           NOT NULL UNIQUE,
	Analyst                 NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode                NVARCHAR(150) NULL DEFAULT ('NS'),
	DocumentTitle           NVARCHAR(255) NULL,
	Amount                  FLOAT         NULL DEFAULT (0.0),
	FundCode                NVARCHAR(150) NULL DEFAULT ('NS'),
	Status                  NVARCHAR(150) NULL DEFAULT ('NS'),
	OriginalRequestDate     DATETIME      NULL,
	LastActivityDate        DATETIME      NULL,
	BudgetFormulationSystem NVARCHAR(150) NULL DEFAULT ('NS'),
	Comments                NVARCHAR(255) NULL DEFAULT ('NS'),
	RequestDocument         NVARCHAR(255) NULL DEFAULT ('NS'),
	Duration                FLOAT         NULL DEFAULT (0.0),
	CONSTRAINT CarryoverRequestsPrimaryKey PRIMARY KEY
		(
		  CarryoverRequestsId
			)
);
