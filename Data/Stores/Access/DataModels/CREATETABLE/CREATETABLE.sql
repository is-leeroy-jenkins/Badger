CREATE TABLE TableName
(
	TableNameId AUTOINCREMENT NOT NULL UNIQUE,
	FieldName TEXT(150) NULL DEFAULT NS,
	NumericName FLOAT NULL DEFAULT 0.0
	CONSTRAINT(TableNamePrimaryKey) )
		PRIMARY KEY(TableNameId)
);
