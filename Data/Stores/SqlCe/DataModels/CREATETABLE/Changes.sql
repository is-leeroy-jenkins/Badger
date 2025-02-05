CREATE TABLE Changes
(
	ChangesId INT           NOT NULL UNIQUE,
	TableName NVARCHAR(150) NULL DEFAULT ('NS'),
	FieldName NVARCHAR(150) NULL DEFAULT ('NS'),
	Action    NVARCHAR(150) NULL DEFAULT ('NS'),
	OldValue  NVARCHAR(150) NULL DEFAULT ('NS'),
	NewValue  NVARCHAR(150) NULL DEFAULT ('NS'),
	TimeStamp DATETIME      NULL,
	Message   NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT ChangesPrimaryKey PRIMARY KEY
		(
		  ChangesId
			)
);
