CREATE TABLE TransTypes
(
	TransTypesId          INT           NOT NULL UNIQUE,
	BFY                   NVARCHAR(150) NULL DEFAULT ('NS'),
	EFY                   NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode              NVARCHAR(150) NULL DEFAULT ('NS'),
	FundName              NVARCHAR(150) NULL DEFAULT ('NS'),
	TreasuryAccountCode   NVARCHAR(150) NULL DEFAULT ('NS'),
	DocType               NVARCHAR(150) NULL DEFAULT ('NS'),
	AppropriationBill     NVARCHAR(150) NULL DEFAULT ('NS'),
	ContinuingResolution  NVARCHAR(150) NULL DEFAULT ('NS'),
	RescissionCurrentYear NVARCHAR(150) NULL DEFAULT ('NS'),
	RescissionPriorYear   NVARCHAR(150) NULL DEFAULT ('NS'),
	SequesterReduction    NVARCHAR(150) NULL DEFAULT ('NS'),
	SequesterReturn       NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT TransTypesPrimaryKey PRIMARY KEY
		(
		  TransTypesId
			)
);
