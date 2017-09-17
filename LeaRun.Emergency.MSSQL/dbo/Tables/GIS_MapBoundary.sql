CREATE TABLE [dbo].[GIS_MapBoundary] (
    [Id]         VARCHAR (50)     NOT NULL,
    [Code]       VARCHAR (50)     NULL,
    [Group]      VARCHAR (50)     NULL,
    [Area]       VARCHAR (100)    NULL,
    [Name]       VARCHAR (50)     NULL,
    [Address]    VARCHAR (100)    NULL,
    [Longitude]  DECIMAL (19, 16) CONSTRAINT [DF__GIS_MapBo__Longi__5CD6CB2B] DEFAULT ((0)) NOT NULL,
    [Latitude]   DECIMAL (19, 16) CONSTRAINT [DF__GIS_MapBo__Latit__5DCAEF64] DEFAULT ((0)) NOT NULL,
    [Boundary]   VARCHAR (MAX)    NULL,
    [Content]    NVARCHAR (MAX)   NULL,
    [CreateTime] DATETIME         NULL,
    [CreateUser] VARCHAR (50)     NULL,
    [Remark]     VARCHAR (200)    NULL,
    CONSTRAINT [PK_GIS_MapBoundary] PRIMARY KEY CLUSTERED ([Id] ASC)
);

