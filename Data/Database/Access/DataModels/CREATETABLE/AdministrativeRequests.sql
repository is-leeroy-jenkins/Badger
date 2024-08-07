CREATE TABLE AdministrativeRequests
(
	AdministrativeRequestsId AUTOINCREMENT NOT NULL UNIQUE,
	RequestId                DOUBLE        NULL DEFAULT 0.0,
	Analyst                  TEXT( 150 )   NULL DEFAULT NS,
	RpioCode                 TEXT( 150 )   NULL DEFAULT NS,
	DocumentTitle            TEXT( 150 )   NULL DEFAULT NS,
	Amount                   DOUBLE        NULL DEFAULT 0.0,
	FundCode                 TEXT( 150 )   NULL DEFAULT NS,
	BFY                      TEXT( 150 )   NULL DEFAULT NS,
	Status                   TEXT( 150 )   NULL DEFAULT NS,
	OriginalRequestDate      DATETIME      NULL,
	LastActivityDate         DATETIME      NULL,
	Duration                 DOUBLE        NULL DEFAULT 0.0,
	BudgetFormulationSystem  TEXT( 150 )   NULL DEFAULT NS,
	Comments                 TEXT( MAX )   NULL DEFAULT NS,
	RequestDocument          TEXT( MAX )   NULL DEFAULT NS,
	RequestType              TEXT( 150 )   NULL DEFAULT NS,
	TypeCode                 TEXT( 150 )   NULL DEFAULT NS,
	Decision                 TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	AdministrativeRequestsPrimaryKey
)
	PRIMARY KEY
(
	AdministrativeRequestsId
)
	);
