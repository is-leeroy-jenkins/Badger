CREATE TABLE Projects
(
	ProjectsId AUTOINCREMENT NOT NULL UNIQUE,
	Code       TEXT( 150 )   NULL DEFAULT NS,
	Name       TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	ProjectsPrimaryKey
)
	PRIMARY KEY
(
	ProjectsId
)
	);
