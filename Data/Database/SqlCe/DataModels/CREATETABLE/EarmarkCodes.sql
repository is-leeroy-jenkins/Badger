CREATE TABLE EarmarkCodes
(
	EarmarkCodesId INT           NOT NULL UNIQUE,
	BFY            NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode       NVARCHAR(150) NULL DEFAULT ('NS'),
	AhCode         NVARCHAR(150) NULL DEFAULT ('NS'),
	AhName         NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT EarmarkCodesPrimaryKey PRIMARY KEY
		(
		  EarmarkCodesId
			)
);
