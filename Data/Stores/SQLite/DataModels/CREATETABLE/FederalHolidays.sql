CREATE TABLE IF NOT EXISTS FederalHolidays
(
	FederalHolidaysId INTEGER NOT NULL UNIQUE,
	BFY TEXT(150) NULL DEFAULT NS,
	ColumbusDay DATETIME NULL,
	VeteransDay DATETIME NULL,
	ThanksgivingDay DATETIME NULL,
	ChristmasDay DATETIME NULL,
	NewYearsDay DATETIME NULL,
	MartinLutherKingDay DATETIME NULL,
	WashingtonsDay DATETIME NULL,
	MemorialDay DATETIME NULL,
	JuneteenthDay DATETIME NULL,
	IndependenceDay DATETIME NULL,
	LaborDay DATETIME NULL,
	CONSTRAINT FederalHolidaysPrimaryKey 
		PRIMARY KEY(FederalHolidaysId)
);
