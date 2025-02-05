CREATE TABLE StatusOfBudgetaryResources
(
	StatusOfBudgetaryResourcesId  INT           NOT NULL UNIQUE,
	BFY                           NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasuryAccountCode           NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasuryAccountName           NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountName             NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountCode             NVARCHAR(150) NULL DEFAULT ('NS'),
	BeginningPeriodOfAvailability NVARCHAR(150) NULL DEFAULT ('NS'),
	EndingPeriodOfAvailability    NVARCHAR(150) NULL DEFAULT ('NS'),
	SectionNumber                 NVARCHAR(150) NULL DEFAULT ('NS'),
	SectionName                   NVARCHAR(150) NULL DEFAULT ('NS'),
	LineNumber                    NVARCHAR(150) NULL DEFAULT ('NS'),
	LineName                      NVARCHAR(150) NULL DEFAULT ('NS'),
	November                      FLOAT         NULL DEFAULT (0.0),
	December                      FLOAT         NULL DEFAULT (0.0),
	January                       FLOAT         NULL DEFAULT (0.0),
	Feburary                      FLOAT         NULL DEFAULT (0.0),
	March                         FLOAT         NULL DEFAULT (0.0),
	April                         FLOAT         NULL DEFAULT (0.0),
	May                           FLOAT         NULL DEFAULT (0.0),
	June                          FLOAT         NULL DEFAULT (0.0),
	July                          FLOAT         NULL DEFAULT (0.0),
	August                        FLOAT         NULL DEFAULT (0.0),
	September                     FLOAT         NULL DEFAULT (0.0),
	October                       FLOAT         NULL DEFAULT (0.0),
	LastUpdate                    DATETIME      NULL,
	CONSTRAINT StatusOfBudgetaryResourcesPrimaryKey PRIMARY KEY
		(
		  StatusOfBudgetaryResourcesId
			)
);
