CREATE TABLE ReimbursableAgreements
(
	ReimbursableAgreementsId INT           NOT NULL UNIQUE,
	RPIO                     NVARCHAR(150) NULL DEFAULT ('NS'),
	BFY                      NVARCHAR(150) NULL DEFAULT ('NS'),
	AgreementNumber          NVARCHAR(150) NULL DEFAULT ('NS'),
	FundCode                 NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode                 NVARCHAR(150) NULL DEFAULT ('NS'),
	StartDate                DATETIME      NULL,
	EndDate                  DATETIME      NULL,
	RcCode                   NVARCHAR(150) NULL DEFAULT ('NS'),
	RcName                   NVARCHAR(150) NULL DEFAULT ('NS'),
	OrgCode                  NVARCHAR(150) NULL DEFAULT ('NS'),
	SiteProjectCode          NVARCHAR(150) NULL DEFAULT ('NS'),
	AccountCode              NVARCHAR(150) NULL DEFAULT ('NS'),
	VendorCode               NVARCHAR(150) NULL DEFAULT ('NS'),
	VendorName               NVARCHAR(150) NULL DEFAULT ('NS'),
	Amount                   FLOAT         NULL DEFAULT (0.0),
	OpenCommitments          FLOAT         NULL DEFAULT (0.0),
	Obligations              FLOAT         NULL DEFAULT (0.0),
	UnliquidatedObligations  FLOAT         NULL DEFAULT (0.0),
	Available                FLOAT         NULL DEFAULT (0.0),
	CONSTRAINT ReimbursableAgreementsPrimaryKey PRIMARY KEY
		(
		  ReimbursableAgreementsId
			)
);
