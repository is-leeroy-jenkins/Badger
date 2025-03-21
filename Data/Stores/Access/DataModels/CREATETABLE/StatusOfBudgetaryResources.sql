CREATE TABLE StatusOfBudgetaryResources
(
	StatusOfBudgetaryResourcesId  AUTOINCREMENT NOT NULL UNIQUE,
	BFY                           TEXT( 150 )   NULL DEFAULT NS,
	TreasuryAccountCode           TEXT( 150 )   NULL DEFAULT NS,
	TreasuryAccountName           TEXT( 150 )   NULL DEFAULT NS,
	BudgetAccountName             TEXT( 150 )   NULL DEFAULT NS,
	BudgetAccountCode             TEXT( 150 )   NULL DEFAULT NS,
	BeginningPeriodOfAvailability TEXT( 150 )   NULL DEFAULT NS,
	EndingPeriodOfAvailability    TEXT( 150 )   NULL DEFAULT NS,
	SectionNumber                 TEXT( 150 )   NULL DEFAULT NS,
	SectionName                   TEXT( 150 )   NULL DEFAULT NS,
	LineNumber                    TEXT( 150 )   NULL DEFAULT NS,
	LineName                      TEXT( 150 )   NULL DEFAULT NS,
	November                      DOUBLE        NULL DEFAULT 0.0,
	December                      DOUBLE        NULL DEFAULT 0.0,
	January                       DOUBLE        NULL DEFAULT 0.0,
	Feburary                      DOUBLE        NULL DEFAULT 0.0,
	March                         DOUBLE        NULL DEFAULT 0.0,
	April                         DOUBLE        NULL DEFAULT 0.0,
	May                           DOUBLE        NULL DEFAULT 0.0,
	June                          DOUBLE        NULL DEFAULT 0.0,
	July                          DOUBLE        NULL DEFAULT 0.0,
	August                        DOUBLE        NULL DEFAULT 0.0,
	September                     DOUBLE        NULL DEFAULT 0.0,
	October                       DOUBLE        NULL DEFAULT 0.0,
	LastUpdate                    DATETIME      NULL, CONSTRAINT
(
	StatusOfBudgetaryResourcesPrimaryKey
)
	PRIMARY KEY
(
	StatusOfBudgetaryResourcesId
)
	);
