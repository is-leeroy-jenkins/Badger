CREATE TABLE TransTypes
(
	TransTypesId          AUTOINCREMENT NOT NULL UNIQUE,
	BFY                   TEXT( 150 )   NULL DEFAULT NS,
	EFY                   TEXT( 150 )   NULL DEFAULT NS,
	FundCode              TEXT( 150 )   NULL DEFAULT NS,
	FundName              TEXT( 150 )   NULL DEFAULT NS,
	TreasuryAccountCode   TEXT( 150 )   NULL DEFAULT NS,
	DocType               TEXT( 150 )   NULL DEFAULT NS,
	AppropriationBill     TEXT( 150 )   NULL DEFAULT NS,
	ContinuingResolution  TEXT( 150 )   NULL DEFAULT NS,
	RescissionCurrentYear TEXT( 150 )   NULL DEFAULT NS,
	RescissionPriorYear   TEXT( 150 )   NULL DEFAULT NS,
	SequesterReduction    TEXT( 150 )   NULL DEFAULT NS,
	SequesterReturn       TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	TransTypesPrimaryKey
)
	PRIMARY KEY
(
	TransTypesId
)
	);
