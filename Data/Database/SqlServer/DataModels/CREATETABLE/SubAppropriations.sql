CREATE TABLE SubAppropriations
(
	SubAppropriationsId INT           NOT NULL UNIQUE,
	Code                NVARCHAR(150) NULL DEFAULT ('NS'),
	Name                NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT SubAppropriationsPrimaryKey PRIMARY KEY
		(
		  SubAppropriationsId ASC
			)
);
