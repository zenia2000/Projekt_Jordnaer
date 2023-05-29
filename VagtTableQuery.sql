use [JordnærDB-Sarah]
CREATE TABLE Vagter(
VagtID int NOT NULL PRIMARY KEY,
VagtName VARCHAR(50) NOT NULL,
VagtDescription VARCHAR(100) NOT NULL,
VagtStart DATE NOT NULL,
VagtEnd DATE NOT NULL);

INSERT INTO Vagt VALUES(1,'CafeMan1','Cafe mandag 2 arbejdere','2023-05-01 10:30:00','2023-05-01 12:30:00')