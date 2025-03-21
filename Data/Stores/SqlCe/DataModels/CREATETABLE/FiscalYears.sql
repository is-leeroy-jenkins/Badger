CREATE TABLE FiscalYears
(
	FiscalYearsId       INT           NOT NULL UNIQUE,
	BFY                 NVARCHAR(80)  NOT NULL,
	EFY                 NVARCHAR(150) NULL DEFAULT ('NS'),
	StartDate           NVARCHAR(150) NULL DEFAULT ('NS'),
	ColumbusDay         DATETIME      NULL,
	VeteransDay         DATETIME      NULL,
	ThanksgivingDay     DATETIME      NULL,
	ChristmasDay        DATETIME      NULL,
	NewYearsDay         DATETIME      NULL,
	MartinLutherKingDay DATETIME      NULL,
	WashingtonsDay      DATETIME      NULL,
	MemorialDay         DATETIME      NULL,
	JuneteenthDay       DATETIME      NULL,
	IndependenceDay     DATETIME      NULL,
	LaborDay            DATETIME      NULL,
	ExpiringYear        NVARCHAR(150) NULL DEFAULT ('NS'),
	ExpirationDate      NVARCHAR(150) NULL DEFAULT ('NS'),
	WorkDays            FLOAT         NULL DEFAULT (0.0),
	WeekDays            FLOAT         NULL DEFAULT (0.0),
	WeekEnds            FLOAT         NULL DEFAULT (0.0),
	EndDate             NVARCHAR(150) NULL DEFAULT ('NS'),
	Availability        NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT FiscalYearsPrimaryKey PRIMARY KEY
		(
		  FiscalYearsId
			)
);
