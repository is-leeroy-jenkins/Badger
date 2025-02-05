CREATE TABLE IF NOT EXISTS ReimbursableFunds
(
	ReimbursableFundsId INTEGER NOT NULL UNIQUE,
	BFY TEXT(150) NULL DEFAULT NS,
	FundCode TEXT(150) NULL DEFAULT NS,
	AgreeementNumber TEXT(150) NULL DEFAULT NS,
	RpioCode TEXT(150) NULL DEFAULT NS,
	AccountCode TEXT(150) NULL DEFAULT NS,
	Amount money NULL,
	OpenCommitments DOUBLE NULL DEFAULT 0.0,
	Obligations DOUBLE NULL DEFAULT 0.0,
	UnliquidatedObligations DOUBLE NULL DEFAULT 0.0,
	Available DOUBLE NULL DEFAULT 0.0,
	CONSTRAINT ReimbursableFundsPrimaryKey 
		PRIMARY KEY(ReimbursableFundsId)
);
