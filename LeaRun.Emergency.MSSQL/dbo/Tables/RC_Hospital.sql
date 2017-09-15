CREATE TABLE [dbo].[RC_Hospital] (
    [Id]           VARCHAR (50)     NOT NULL,
    [Name]         VARCHAR (100)    NULL,
    [LinkPerson]   VARCHAR (50)     NULL,
    [LinkPhone]    VARCHAR (50)     NULL,
    [HospitalType] VARCHAR (50)     NULL,
    [Address]      VARCHAR (200)    NULL,
    [Longitude]    DECIMAL (19, 16) CONSTRAINT [DF_RC_Hospital_Longitude] DEFAULT ((0)) NOT NULL,
    [Latitude]     DECIMAL (19, 16) CONSTRAINT [DF_RC_Hospital_Latitude] DEFAULT ((0)) NOT NULL,
    [CreateTime]   DATETIME         NULL,
    [CreateUser]   VARCHAR (50)     NULL,
    [Remark]       VARCHAR (300)    NULL,
    CONSTRAINT [PK_RC_Hospital] PRIMARY KEY CLUSTERED ([Id] ASC)
);

