CREATE TABLE Providers
(
	ProvidersId   AUTOINCREMENT NOT NULL UNIQUE,
	ProviderName  TEXT( 150 )   NULL DEFAULT NS,
	FileExtension TEXT( 150 )   NULL DEFAULT NS,
	Connection    TEXT( 150 )   NULL DEFAULT NS,
	Properties    TEXT( 150 )   NULL DEFAULT NS, CONSTRAINT
(
	ProvidersPrimaryKey
)
	PRIMARY KEY
(
	ProvidersId
)
	);
