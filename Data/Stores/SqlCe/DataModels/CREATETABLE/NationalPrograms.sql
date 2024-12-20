CREATE TABLE NationalPrograms
(
	NationalProgramsId INT           NOT NULL UNIQUE,
	Code               NVARCHAR(80)  NOT NULL,
	Name               NVARCHAR(150) NULL DEFAULT ('NS'),
	RpioCode           NVARCHAR(150) NULL DEFAULT ('NS'),
	Title              NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT NationalProgramsPrimaryKey PRIMARY KEY
		(
		  NationalProgramsId
			)
);
