CREATE TABLE BudgetContacts
(
	BudgetContactsId INT           NOT NULL UNIQUE,
	FirstName        NVARCHAR(180) NULL DEFAULT ('NS'),
	LastName         NVARCHAR(180) NULL DEFAULT ('NS'),
	RpioName         NVARCHAR(180) NULL DEFAULT ('NS'),
	Section          NVARCHAR(180) NULL DEFAULT ('NS'),
	JobTitle         NVARCHAR(180) NULL DEFAULT ('NS'),
	Street           NVARCHAR(180) NULL DEFAULT ('NS'),
	City             NVARCHAR(180) NULL DEFAULT ('NS'),
	State            NVARCHAR(180) NULL DEFAULT ('NS'),
	ZipCode          NVARCHAR(180) NULL DEFAULT ('NS'),
	Account          NVARCHAR(180) NULL DEFAULT ('NS'),
	EmailAddress     NVARCHAR(180) NULL DEFAULT ('NS'),
	EmailType        NVARCHAR(180) NULL DEFAULT ('NS'),
	DisplayName      NVARCHAR(180) NULL DEFAULT ('NS'),
	OfficeLocation   NVARCHAR(180) NULL DEFAULT ('NS'),
	RpioCode         NVARCHAR(180) NULL DEFAULT ('NS'),
	CONSTRAINT BudgetContactsPrimaryKey PRIMARY KEY
		(
		  BudgetContactsId
			)
);
