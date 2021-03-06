CREATE TABLE IF NOT EXISTS Company (
	Id BIGINT CONSTRAINT PK_Company PRIMARY KEY GENERATED BY DEFAULT AS IDENTITY,
	Code VARCHAR(100) NOT NULL,
	Name VARCHAR(100) NOT NULL,
	MaxEmployeesNumber INT NOT NULL,
	Active BOOLEAN NOT NULL DEFAULT TRUE
);