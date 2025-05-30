CREATE TABLE  IF NOT EXISTS StatusOfBudgetaryResources 
(
	StatusOfBudgetaryResourcesId	INTEGER NOT NULL UNIQUE,
	FiscalYear	TEXT(150) DEFAULT NS,
	BFY	TEXT(150) DEFAULT NS,
	EFY	TEXT(150) DEFAULT NS,
	TreasuryAccountCode	TEXT(150) DEFAULT NS,
	FundCode	TEXT(150) DEFAULT NS,
	FundName	TEXT(150) DEFAULT NS,
	BeginningPeriodOfAvailability	TEXT(150) DEFAULT NS,
	EndingPeriodOfAvailability	TEXT(150) DEFAULT NS,
	SectionNumber	TEXT(150) DEFAULT NS,
	SectionName	TEXT(150) DEFAULT NS,
	LineNumber	TEXT(150) DEFAULT NS,
	LineName	TEXT(150) DEFAULT NS,
	November	DOUBLE DEFAULT 0.0,
	December	DOUBLE DEFAULT 0.0,
	January	DOUBLE DEFAULT 0.0,
	Feburary	DOUBLE DEFAULT 0.0,
	March	DOUBLE DEFAULT 0.0,
	April	DOUBLE DEFAULT 0.0,
	May	DOUBLE DEFAULT 0.0,
	June	DOUBLE DEFAULT 0.0,
	July	DOUBLE DEFAULT 0.0,
	August	DOUBLE DEFAULT 0.0,
	September	DOUBLE DEFAULT 0.0,
	October	DOUBLE DEFAULT 0.0,
	LastUpdate	TEXT(150) DEFAULT NS,
	TreasuryAccountName	TEXT(150) DEFAULT NS,
	MainAccount	TEXT(150) DEFAULT NS,
	BudgetAccountName	TEXT(150) DEFAULT NS,
	BudgetAccountCode	TEXT(150) DEFAULT NS,
	PRIMARY KEY(StatusOfBudgetaryResourcesId AUTOINCREMENT)
);