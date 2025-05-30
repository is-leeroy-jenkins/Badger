CREATE TABLE TreasurySymbols
(
	TreasurySymbolsId                INT           NOT NULL UNIQUE,
	ShortKey                         NVARCHAR(150) NULL DEFAULT ('NS'),
	AllocationTransferAgency         NVARCHAR(150) NULL DEFAULT ('NS'),
	AgencyIdentifier                 NVARCHAR(150) NULL DEFAULT ('NS'),
	BeginningPeriodOfAvailability    NVARCHAR(150) NULL DEFAULT ('NS'),
	EndingPeriodOfAvailability       NVARCHAR(150) NULL DEFAULT ('NS'),
	AvailabilityType                 NVARCHAR(150) NULL DEFAULT ('NS'),
	MainAccount                      NVARCHAR(150) NULL DEFAULT ('NS'),
	SubAccount                       NVARCHAR(150) NULL DEFAULT ('NS'),
	Lapsed                           NVARCHAR(150) NULL DEFAULT ('NS'),
	UseCancelledYearSpendingAccounts NVARCHAR(150) NULL DEFAULT ('NS'),
	AgencyTreasurySymbol             NVARCHAR(150) NULL DEFAULT ('NS'),
	InUse                            NVARCHAR(150) NULL DEFAULT ('NS'),
	PreventNewUse                    NVARCHAR(150) NULL DEFAULT ('NS'),
	Status                           NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT TreasurySymbolsPrimaryKey PRIMARY KEY
		(
		  TreasurySymbolsId
			)
);
