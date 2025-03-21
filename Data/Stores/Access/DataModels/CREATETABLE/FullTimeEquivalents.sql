CREATE TABLE FullTimeEquivalents
(
	FullTimeEquivialentsId AUTOINCREMENT NOT NULL UNIQUE,
	OperatingPlansId       INT           NULL,
	RpioCode               TEXT( 150 )   NULL DEFAULT NS,
	RpioName               TEXT( 150 )   NULL DEFAULT NS,
	BFY                    TEXT( 150 )   NULL DEFAULT NS,
	EFY                    TEXT( 150 )   NULL DEFAULT NS,
	AhCode                 TEXT( 150 )   NULL DEFAULT NS,
	FundCode               TEXT( 150 )   NULL DEFAULT NS,
	OrgCode                TEXT( 150 )   NULL DEFAULT NS,
	AccountCode            TEXT( 150 )   NULL DEFAULT NS,
	RcCode                 TEXT( 150 )   NULL DEFAULT NS,
	BocCode                TEXT( 150 )   NULL DEFAULT NS,
	BocName                TEXT( 150 )   NULL DEFAULT NS,
	Amount                 DOUBLE        NULL DEFAULT 0.0,
	ITProjectCode          TEXT( 150 )   NULL DEFAULT NS,
	ProjectCode            TEXT( 150 )   NULL DEFAULT NS,
	ProjectName            TEXT( 150 )   NULL DEFAULT NS,
	NpmCode                TEXT( 150 )   NULL DEFAULT NS,
	ProjectTypeName        TEXT( 150 )   NULL DEFAULT NS,
	ProjectTypeCode        TEXT( 150 )   NULL DEFAULT NS,
	ProgramProjectCode     TEXT( 150 )   NULL DEFAULT NS,
	ProgramAreaCode        TEXT( 150 )   NULL DEFAULT NS,
	NpmName                TEXT( 150 )   NULL DEFAULT NS,
	AhName                 TEXT( 150 )   NULL DEFAULT NS,
	FundName               TEXT( 150 )   NULL DEFAULT NS,
	OrgName                TEXT( 150 )   NULL DEFAULT NS,
	RcName                 TEXT( 150 )   NULL DEFAULT NS,
	ProgramProjectName     TEXT( 150 )   NULL DEFAULT NS,
	ActivityCode           TEXT( 150 )   NULL DEFAULT NS,
	ActivityName           TEXT( 150 )   NULL DEFAULT NS,
	LocalCode              TEXT( 150 )   NULL DEFAULT NS,
	LocalCodeName          TEXT( 150 )   NULL DEFAULT NS,
	ProgramAreaName        TEXT( 150 )   NULL DEFAULT NS,
	CostAreaCode           TEXT( 150 )   NULL DEFAULT NS,
	CostAreaName           TEXT( 150 )   NULL DEFAULT NS,
	GoalCode               TEXT( 150 )   NULL DEFAULT NS,
	GoalName               TEXT( 150 )   NULL DEFAULT NS,
	ObjectiveCode          TEXT( 150 )   NULL DEFAULT NS,
	ObjectiveName          TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	FullTimeEquivalentsPrimaryKey
)
	PRIMARY KEY
(
	FullTimeEquivialentsId
)
	);
