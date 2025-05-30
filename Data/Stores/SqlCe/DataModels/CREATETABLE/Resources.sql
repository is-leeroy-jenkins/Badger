CREATE TABLE Resources
(
	ResourcesId   INT           NOT NULL UNIQUE,
	Identifier    NVARCHAR(150) NULL DEFAULT ('NS'),
	Type          NVARCHAR(150) NULL DEFAULT ('NS'),
	Location      NVARCHAR(150) NULL DEFAULT ('NS'),
	FileExtension NVARCHAR(150) NULL DEFAULT ('NS'),
	Caption       NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT ResourcesPrimaryKey PRIMARY KEY
		(
		  ResourcesId
			)
);
