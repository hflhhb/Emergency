CREATE TABLE [dbo].[RC_Camera] (
    [Id]         VARCHAR (50)     CONSTRAINT [DF_RC_Camera_Id] DEFAULT ((0)) NOT NULL,
    [Code]       VARCHAR (50)     NULL,
    [Area]       VARCHAR (100)    NULL,
    [Name]       VARCHAR (50)     NULL,
    [Address]    VARCHAR (100)    NULL,
    [Longitude]  DECIMAL (19, 16) CONSTRAINT [DF_RC_Camera_Longitude] DEFAULT ((0)) NOT NULL,
    [Latitude]   DECIMAL (19, 16) CONSTRAINT [DF_RC_Camera_Latitude] DEFAULT ((0)) NOT NULL,
    [Url]        VARCHAR (100)    NULL,
    [CreateTime] DATETIME         NULL,
    [CreateUser] VARCHAR (50)     NULL,
    [Remark]     VARCHAR (200)    NULL,
    CONSTRAINT [PK_RC_Camera] PRIMARY KEY CLUSTERED ([Id] ASC)
);



