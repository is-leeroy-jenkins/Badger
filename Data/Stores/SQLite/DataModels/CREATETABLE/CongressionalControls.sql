CREATE TABLE IF NOT EXISTS CongressionalControls
(
	CongressionalControlsId INTEGER NOT NULL UNIQUE,
	FundCode TEXT(150) NULL DEFAULT NS,
	FundName TEXT(150) NULL DEFAULT NS,
	ProgramAreaCode TEXT(150) NULL DEFAULT NS,
	ProgramAreaName TEXT(150) NULL DEFAULT NS,
	ProgramProjectCode TEXT(150) NULL DEFAULT NS,
	ProgramProjectName TEXT(150) NULL DEFAULT NS,
	SubProjectCode TEXT(150) NULL DEFAULT NS,
	SubProjectName TEXT(150) NULL DEFAULT NS,
	ReprogrammingRestriction TEXT(150) NULL DEFAULT NS,
	IncreaseRestriction TEXT(150) NULL DEFAULT NS,
	DecreaseRestriction TEXT(150) NULL DEFAULT NS,
	MemoRequirement TEXT(150) NULL DEFAULT NS,
	CONSTRAINT CongressionalControlsPrimaryKey 
		PRIMARY KEY(CongressionalControlsId)
);
