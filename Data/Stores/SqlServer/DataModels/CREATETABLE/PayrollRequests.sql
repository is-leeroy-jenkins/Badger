CREATE TABLE PayrollRequests
(
	PayrollRequestsId   INT           NOT NULL UNIQUE,
	ControlTeamAnalyst  NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode            NVARCHAR(150) NULL DEFAULT ('NS'),
	DocumentTitle       NVARCHAR(150) NULL DEFAULT ('NS'),
	Amount              FLOAT         NULL DEFAULT (0.0),
	FundCode            NVARCHAR(150) NULL DEFAULT ('NS'),
	Status              NVARCHAR(150) NULL DEFAULT ('NS'),
	OriginalRequestDate DATETIME      NULL,
	LastActivityDate    DATETIME      NULL,
	BFS                 NVARCHAR(150) NULL DEFAULT ('NS'),
	Comments            NVARCHAR(MAX) NULL,
	RequestDocument     NVARCHAR(MAX) NULL,
	Duration            FLOAT         NULL DEFAULT (0.0),
	CONSTRAINT PayrollRequestsPrimaryKey PRIMARY KEY
		(
		  PayrollRequestsId ASC
			)
);
