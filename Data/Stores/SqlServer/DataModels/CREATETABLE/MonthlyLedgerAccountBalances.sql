CREATE TABLE MonthlyLedgerAccountBalances
(
	MonthlyLedgerAccountBalancesId INT           NOT NULL UNIQUE,
	FiscalYear                     NVARCHAR(150) NULL DEFAULT ('NS'),
	BFY                            NVARCHAR(150) NULL DEFAULT ('NS'),
	EFY                            NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode                       NVARCHAR(150) NULL DEFAULT ('NS'),
	FundName                       NVARCHAR(150) NULL DEFAULT ('NS'),
	LedgerAccount                  NVARCHAR(150) NULL DEFAULT ('NS'),
	LedgerName                     NVARCHAR(150) NULL DEFAULT ('NS'),
	ApportionmentAccountCode       NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasurySymbol                 NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasurySymbolName             NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountCode              NVARCHAR(150) NULL DEFAULT ('NS'),
	BudgetAccountName              NVARCHAR(150) NULL DEFAULT ('NS'),
	FiscalMonth                    NVARCHAR(150) NULL DEFAULT ('NS'),
	CreditBalance                  FLOAT         NULL DEFAULT (0.0),
	DebitBalance                   FLOAT         NULL DEFAULT (0.0),
	YearToDateAmount               FLOAT         NULL DEFAULT (0.0),
	CONSTRAINT MonthlyLedgerAccountBalancesPrimaryKey PRIMARY KEY
		(
		  MonthlyLedgerAccountBalancesId ASC
			)
);
