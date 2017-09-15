CREATE TABLE [dbo].[RC_GasStation] (
    [Id]          VARCHAR (50)     NOT NULL,
    [Name]        VARCHAR (100)    NULL,
    [Address]     VARCHAR (100)    NULL,
    [LinkPhone]   VARCHAR (50)     NULL,
    [LegalPerson] VARCHAR (50)     NULL,
    [LinkPerson]  VARCHAR (50)     NULL,
    [StartTime]   DATETIME         NULL,
    [Longitude]   DECIMAL (19, 16) CONSTRAINT [DF_RC_GasStation_Longitude] DEFAULT ((0)) NOT NULL,
    [Latitude]    DECIMAL (19, 16) CONSTRAINT [DF_RC_GasStation_Latitude] DEFAULT ((0)) NOT NULL,
    [Remark]      VARCHAR (300)    NULL,
    [State]       VARCHAR (50)     NULL,
    [CreateTime]  DATETIME         NULL,
    [CreateUser]  VARCHAR (50)     NULL,
    CONSTRAINT [PK_RC_GasStation] PRIMARY KEY CLUSTERED ([Id] ASC)
);

