CREATE TABLE Earmarks
(
	EarmarksId                INT           NOT NULL UNIQUE,
	RpioCode                  NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioName                  NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode                  NVARCHAR(150) NULL DEFAULT ('NS'),
	FundName                  NVARCHAR(150) NULL DEFAULT ('NS'),
	StateCode                 NVARCHAR(150) NULL DEFAULT ('NS'),
	Description               NVARCHAR(150) NULL DEFAULT ('NS'),
	Amount                    FLOAT         NULL DEFAULT (0.0),
	ProjectOfficerLastName    NVARCHAR(150) NULL DEFAULT ('NS'),
	ProjectOfficerFirstName   NVARCHAR(150) NULL DEFAULT ('NS'),
	ProjectOfficerPhoneNumber NVARCHAR(150) NULL DEFAULT ('NS'),
	ProjectOfficerMailCode    NVARCHAR(150) NULL DEFAULT ('NS'),
	CommitmentDate            DATETIME      NULL,
	ObligationDate            DATETIME      NULL,
	ProjectStatus             NVARCHAR(150) NULL DEFAULT ('NS'),
	ProjectOfficerComments    NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT EarmarksPrimaryKey PRIMARY KEY
		(
		  EarmarksId ASC
			)
);
