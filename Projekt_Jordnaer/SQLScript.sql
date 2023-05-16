DROP TABLE[dbo].[Vagter]

CREATE TABLE [dbo].[Vagt] (
    [VagtID]          INT           IDENTITY (1, 1) NOT NULL,
    [VagtName]        VARCHAR (50)  NOT NULL,
    [VagtDescription] VARCHAR (100) NOT NULL,
    [VagtStart]       DATETIME      NOT NULL,
    [VagtEnd]         DATETIME      NOT NULL,
    [VagtType]        INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([VagtID] ASC)
);

DROP TABLE [dbo].[Medlem]

CREATE TABLE [dbo].[Medlem]
(
	[MedlemID] INT IDENTITY (1,1) NOT NULL UNIQUE, 
    [Name] VARCHAR(80) NOT NULL, 
    [Address] VARCHAR(100) NOT NULL, 
    [Email] VARCHAR(80) NOT NULL, 
    [Certificate] BIT NOT NULL, 
    [Admin] BIT NOT NULL, 
    PRIMARY KEY CLUSTERED ([MedlemID] ASC)
)

