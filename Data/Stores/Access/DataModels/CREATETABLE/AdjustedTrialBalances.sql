CREATE TABLE AdjustedTrialBalances 
(
	AdjustedTrialBalancesId INT NOT NULL UNIQUE,
	AgencyIdentifier	TEXT(150) DEFAULT NS,
	AllocationTransferAgency	TEXT(150) DEFAULT NS,
	AvailabilityType	TEXT(150) DEFAULT NS,
	MainAccount	TEXT(150) DEFAULT NS,
	SubAccount	TEXT(150) DEFAULT NS,
	TreasurySymbol	TEXT(150) DEFAULT NS,
	BFY	TEXT(150) DEFAULT NS,
	EFY	TEXT(150) DEFAULT NS,
	FundCode	TEXT(150) DEFAULT NS,
	FundName	TEXT(150) DEFAULT NS,
	LedgerAccount	TEXT(150) DEFAULT NS,
	AccountName	TEXT(150) DEFAULT NS,
	BeginningBalance	DOUBLE DEFAULT 0.0,
	CreditBalance	DOUBLE DEFAULT 0.0,
	DebitBalance	DOUBLE DEFAULT 0.0,
	EndingBalance	DOUBLE DEFAULT 0.0,
	TreasuryAccountCode	TEXT(150) DEFAULT NS,
	TreasuryAccountName	TEXT(150) DEFAULT NS,
	BudgetAccountCode	TEXT(150) DEFAULT NS,
	BudgetAccountName	TEXT(150) DEFAULT NS,
	CONSTRAINT AdjustedTrialBalances PRIMARY KEY
	(
		AdjustedTrialBalancesId  ASC
	)
);