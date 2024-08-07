CREATE TABLE MonthlyLedgerAccountBalances
(
	MonthlyLedgerAccountBalancesId AUTOINCREMENT NOT NULL UNIQUE,
	FiscalYear                     TEXT( 150 )   NULL DEFAULT NS,
	BFY                            TEXT( 150 )   NULL DEFAULT NS,
	EFY                            TEXT( 150 )   NULL DEFAULT NS,
	FundCode                       TEXT( 150 )   NULL DEFAULT NS,
	FundName                       TEXT( 150 )   NULL DEFAULT NS,
	LedgerAccount                  TEXT( 150 )   NULL DEFAULT NS,
	LedgerName                     TEXT( 150 )   NULL DEFAULT NS,
	ApportionmentAccountCode       TEXT( 150 )   NULL DEFAULT NS,
	TreasurySymbol                 TEXT( 150 )   NULL DEFAULT NS,
	TreasurySymbolName             TEXT( 150 )   NULL DEFAULT NS,
	BudgetAccountCode              TEXT( 150 )   NULL DEFAULT NS,
	BudgetAccountName              TEXT( 150 )   NULL DEFAULT NS,
	FiscalMonth                    TEXT( 150 )   NULL DEFAULT NS,
	CreditBalance                  DOUBLE        NULL DEFAULT 0.0,
	DebitBalance                   DOUBLE        NULL DEFAULT 0.0,
	YearToDateAmount               DOUBLE        NULL DEFAULT 0.0, CONSTRAINT
(
	MonthlyLedgerAccountBalancesPrimaryKey
)
	PRIMARY KEY
(
	MonthlyLedgerAccountBalancesId
)
	);
