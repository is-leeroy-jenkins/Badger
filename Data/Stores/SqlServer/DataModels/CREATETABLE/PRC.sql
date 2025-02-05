CREATE TABLE PRC
(
	PrcId           INT           NOT NULL UNIQUE,
	StatusOfFundsId INT           NULL,
	BFY             NVARCHAR(150) NULL DEFAULT ('NS'),
	EFY             NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode        NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode        NVARCHAR(150) NULL DEFAULT ('NS'),
	AhCode          NVARCHAR(150) NULL DEFAULT ('NS'),
	OrgCode         NVARCHAR(150) NULL DEFAULT ('NS'),
	AccountCode     NVARCHAR(150) NULL DEFAULT ('NS'),
	BocCode         NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT PRCPrimaryKey PRIMARY KEY
		(
		  PrcId ASC
			)
);
