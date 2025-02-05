CREATE TABLE Providers
(
	ProvidersId   INT           NOT NULL UNIQUE,
	ProviderName  NVARCHAR(150) NULL DEFAULT ('NS'),
	FileExtension NVARCHAR(150) NULL DEFAULT ('NS'),
	Connection    NVARCHAR(150) NULL DEFAULT ('NS'),
	Properties    NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT ProvidersPrimaryKey PRIMARY KEY
		(
		  ProvidersId
			)
);
