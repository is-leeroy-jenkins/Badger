CREATE TABLE DataRuleDescriptions
(
	DataRuleDescriptionsId AUTOINCREMENT NOT NULL UNIQUE,
	Schedule               TEXT( 150 )   NULL DEFAULT NS,
	LineNumber             TEXT( 150 )   NULL DEFAULT NS,
	RuleNumber             TEXT( 150 )   NULL DEFAULT NS,
	RuleDescription        TEXT( MAX )   NULL DEFAULT NS,
	ScheduleOrder          TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	DataRuleDescriptionsPrimaryKey
)
	PRIMARY KEY
(
	DataRuleDescriptionsId
)
	);
