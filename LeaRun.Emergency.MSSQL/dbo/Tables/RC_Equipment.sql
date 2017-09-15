CREATE TABLE [dbo].[RC_Equipment] (
    [Id]           VARCHAR (50)  NOT NULL,
    [Name]         VARCHAR (100) NULL,
    [Number]       INT           NULL,
    [Address]      VARCHAR (300) NULL,
    [LinkPerson]   VARCHAR (50)  NULL,
    [LinkPhone]    VARCHAR (50)  NULL,
    [EquipType]    VARCHAR (50)  NULL,
    [EquipSubType] VARCHAR (50)  NULL,
    [OrgName]      VARCHAR (50)  NULL,
    [State]        VARCHAR (20)  NULL,
    [Remark]       VARCHAR (300) NULL,
    [CreateTime]   DATETIME      NULL,
    [CreateUser]   VARCHAR (50)  NULL,
    [IsOk]         VARCHAR (20)  NULL,
    CONSTRAINT [PK_RC_Equipment] PRIMARY KEY CLUSTERED ([Id] ASC)
);

