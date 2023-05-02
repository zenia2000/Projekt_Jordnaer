CREATE TABLE [dbo].[Vagter] (
    [VagtID]          INT           IDENTITY (1, 1) NOT NULL,
    [VagtName]        VARCHAR (50)  NOT NULL,
    [VagtDescription] VARCHAR (100) NOT NULL,
    [VagtStart]       DATETIME      NOT NULL,
    [VagtEnd]         DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([VagtID] ASC)
);

