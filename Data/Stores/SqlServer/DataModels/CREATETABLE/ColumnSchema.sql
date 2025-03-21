CREATE TABLE ColumnSchema
(
	ColumnSchemaId INT           NOT NULL UNIQUE,
	DataType       NVARCHAR(150) NULL DEFAULT ('NS'),
	ColumnName     NVARCHAR(150) NULL DEFAULT ('NS'),
	TableName      NVARCHAR(150) NULL DEFAULT ('NS'),
	ColumnCaption  NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT ColumnSchemaPrimaryKey PRIMARY KEY
		(
		  ColumnSchemaId ASC
			)
);
