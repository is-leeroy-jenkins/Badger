CREATE TABLE URL
(
	SourceId INT           NOT NULL UNIQUE,
	Name     NVARCHAR(150) NULL DEFAULT ('NS'),
	Location NVARCHAR(150) NULL DEFAULT ('NS'),
	Address  NVARCHAR(255) NULL,
	CONSTRAINT URLPrimaryKey PRIMARY KEY
		(
		  SourceId
			)
);
