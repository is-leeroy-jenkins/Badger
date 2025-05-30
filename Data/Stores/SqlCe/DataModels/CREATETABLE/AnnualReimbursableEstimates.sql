CREATE TABLE AnnualReimbursableEstimates
(
	AnnualReimbursableEstimatesId INT           NOT NULL UNIQUE,
	BFY                           NVARCHAR(150) NULL DEFAULT ('NS'),
	EFY                           NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode                      NVARCHAR(150) NULL DEFAULT ('NS'),
	FundName                      NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasuryAccountCode           NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode                      NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioName                      NVARCHAR(150) NULL DEFAULT ('NS'),
	Amount                        FLOAT         NULL DEFAULT (0.0),
	OpenCommitments               FLOAT         NULL DEFAULT (0.0),
	Obligations                   FLOAT         NULL DEFAULT (0.0),
	Available                     FLOAT         NULL DEFAULT (0.0),
	Estimate                      FLOAT         NULL DEFAULT (0.0),
	CONSTRAINT AnnualReimbursableEstimatesPrimaryKey PRIMARY KEY
		(
		  AnnualReimbursableEstimatesId
			)
);
