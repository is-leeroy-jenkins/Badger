CREATE TABLE PayPeriods
(
	PayPeriodsId INT           NOT NULL UNIQUE,
	BFY          NVARCHAR(150) NULL DEFAULT ('NS'),
	Number       NVARCHAR(150) NULL DEFAULT ('NS'),
	Period NVARCHAR(150
) NULL DEFAULT ('NS'),
	Type NVARCHAR(150) NULL DEFAULT ('NS'),
	SecurityOrg NVARCHAR(150) NULL DEFAULT ('NS'),
	StartDate DATETIME NULL,
	EndDate DATETIME NULL,
	SplitPayPeriod NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT PayPeriodsPrimaryKey PRIMARY KEY
	(
		PayPeriodsId ASC
	)
);
