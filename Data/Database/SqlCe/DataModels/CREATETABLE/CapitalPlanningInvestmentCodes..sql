CREATE TABLE CapitalPlanningInvestmentCodes
(
	CapitalPlanningInvestmentCodesId INT           NOT NULL UNIQUE,
	Type                             NVARCHAR(150) NULL DEFAULT ('NS'),
	Code                             NVARCHAR(150) NULL DEFAULT ('NS'),
	Name                             NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT CapitalPlanningInvestmentCodesPrimaryKey PRIMARY KEY
		(
		  CapitalPlanningInvestmentCodesId
			)
);
