CREATE TABLE BudgetAuthorityAndOutlays
(
	BudgetAuthorityAndOutlaysId INT           NOT NULL UNIQUE,
	ReportYear                  NVARCHAR(150) NULL DEFAULT ('NS'),
	Category                    NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountName           NVARCHAR(150) NULL DEFAULT ('NS'),
	LineNumber                  NVARCHAR(150) NULL DEFAULT ('NS'),
	LineName                    NVARCHAR(150) NULL DEFAULT ('NS'),
	AccountType                 NVARCHAR(150) NULL DEFAULT ('NS'),
	AuthorityType               NVARCHAR(150) NULL DEFAULT ('NS'),
	PriorYear                   FLOAT         NULL DEFAULT (0.0),
	CurrentYear                 FLOAT         NULL DEFAULT (0.0),
	BudgetYear                  FLOAT         NULL DEFAULT (0.0),
	OutYear1                    FLOAT         NULL DEFAULT (0.0),
	OutYear2                    FLOAT         NULL DEFAULT (0.0),
	OutYear3                    FLOAT         NULL DEFAULT (0.0),
	OutYear4                    FLOAT         NULL DEFAULT (0.0),
	OutYear5                    FLOAT         NULL DEFAULT (0.0),
	OutYear6                    FLOAT         NULL DEFAULT (0.0),
	OutYear7                    FLOAT         NULL DEFAULT (0.0),
	OutYear8                    FLOAT         NULL DEFAULT (0.0),
	OutYear9                    FLOAT         NULL DEFAULT (0.0),
	CONSTRAINT BudgetAuthorityAndOutlaysPrimaryKey PRIMARY KEY
		(
		  BudgetAuthorityAndOutlaysId
			)
);
