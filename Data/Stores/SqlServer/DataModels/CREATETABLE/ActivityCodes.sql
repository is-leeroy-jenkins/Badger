CREATE TABLE ActivityCodes
(
	ActivityId  INT          NOT NULL UNIQUE,
	Code        NVARCHAR(80) NOT NULL,
	Name        NVARCHAR(50) NULL,
	Description NVARCHAR(50) NULL,
	CONSTRAINT ActivityCodesPrimaryKey PRIMARY KEY
		(
		  ActivityId ASC
			)
);
