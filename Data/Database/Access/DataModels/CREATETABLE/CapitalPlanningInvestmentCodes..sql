CREATE TABLE CapitalPlanningInvestmentCodes
(
	CapitalPlanningInvestmentCodesId AUTOINCREMENT NOT NULL UNIQUE,
	Type                             TEXT( 150 )   NULL DEFAULT NS,
	Code                             TEXT( 150 )   NULL DEFAULT NS,
	Name                             TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	CapitalPlanningInvestmentCodesPrimaryKey
)
	PRIMARY KEY
(
	CapitalPlanningInvestmentCodesId
)
	);
