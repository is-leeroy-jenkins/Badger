CREATE TABLE GsPayScales
(
	GsPayScalesId INT           NOT NULL UNIQUE,
	LOCNAME       NVARCHAR(150) NULL DEFAULT ('NS'),
	GRADE         FLOAT         NULL DEFAULT (0.0),
	ANNUAL1       FLOAT         NULL DEFAULT (0.0),
	HOURLY1       NVARCHAR(150) NULL DEFAULT ('NS'),
	OVERTIME1     NVARCHAR(150) NULL DEFAULT ('NS'),
	ANNUAL2       FLOAT         NULL DEFAULT (0.0),
	HOURLY2       NVARCHAR(150) NULL DEFAULT ('NS'),
	OVERTIME2     NVARCHAR(150) NULL DEFAULT ('NS'),
	ANNUAL3       FLOAT         NULL DEFAULT (0.0),
	HOURLY3       NVARCHAR(150) NULL DEFAULT ('NS'),
	OVERTIME3     NVARCHAR(150) NULL DEFAULT ('NS'),
	ANNUAL4       FLOAT         NULL DEFAULT (0.0),
	HOURLY4       NVARCHAR(150) NULL DEFAULT ('NS'),
	OVERTIME4     NVARCHAR(150) NULL DEFAULT ('NS'),
	ANNUAL5       FLOAT         NULL DEFAULT (0.0),
	HOURLY5       NVARCHAR(150) NULL DEFAULT ('NS'),
	OVERTIME5     NVARCHAR(150) NULL DEFAULT ('NS'),
	ANNUAL6       FLOAT         NULL DEFAULT (0.0),
	HOURLY6       NVARCHAR(150) NULL DEFAULT ('NS'),
	OVERTIME6     NVARCHAR(150) NULL DEFAULT ('NS'),
	ANNUAL7       FLOAT         NULL DEFAULT (0.0),
	HOURLY7       NVARCHAR(150) NULL DEFAULT ('NS'),
	OVERTIME7     NVARCHAR(150) NULL DEFAULT ('NS'),
	ANNUAL8       FLOAT         NULL DEFAULT (0.0),
	HOURLY8       NVARCHAR(150) NULL DEFAULT ('NS'),
	OVERTIME8     NVARCHAR(150) NULL DEFAULT ('NS'),
	ANNUAL9       FLOAT         NULL DEFAULT (0.0),
	HOURLY9       NVARCHAR(150) NULL DEFAULT ('NS'),
	OVERTIME9     NVARCHAR(150) NULL DEFAULT ('NS'),
	ANNUAL10      FLOAT         NULL DEFAULT (0.0),
	HOURLY10      NVARCHAR(150) NULL DEFAULT ('NS'),
	OVERTIME10    NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT GsPayScalesPrimaryKey PRIMARY KEY
		(
		  GsPayScalesId ASC
			)
);
