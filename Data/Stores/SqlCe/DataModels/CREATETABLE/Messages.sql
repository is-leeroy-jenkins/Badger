CREATE TABLE Messages
(
	MessageId INT           NOT NULL UNIQUE,
	Message   NVARCHAR(255) NULL,
	Type      NVARCHAR(150) NULL DEFAULT ('NS'),
	Form      NVARCHAR(150) NULL DEFAULT ('NS'),
	CONSTRAINT MessagesPrimaryKey PRIMARY KEY
		(
		  MessageId
			)
);
