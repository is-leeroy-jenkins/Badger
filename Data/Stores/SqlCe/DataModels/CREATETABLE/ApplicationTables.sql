CREATE TABLE ApplicationTables
(
	ApplicationTablesId INT           NOT NULL UNIQUE,
	TableName           NVARCHAR(150) NULL DEFAULT ('NS'),
	Model               NVARCHAR(150) NULL DEFAULT ('NS'),
	Title               NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT ApplicationTablesPrimaryKey PRIMARY KEY
		(
		  ApplicationTablesId
			)
);
