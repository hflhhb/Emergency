CREATE TABLE [dbo].[DutyDetails] (
    [Id]        NVARCHAR (50)  NOT NULL,
    [DutyId]    NVARCHAR (50)  NULL,
    [IsLeader]  BIT            NULL,
    [DutyDay]   DATETIME       NULL,
    [DutyUsers] NVARCHAR (200) NULL,
    [DutyType]  INT            NULL,
    [Sort]      INT            NULL,
    [IsChange]  BIT            NULL,
    [ChangedAt] DATETIME       NULL,
    [GroupId]   INT            NULL,
    CONSTRAINT [PK_DutyDetails] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'改变日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyDetails', @level2type = N'COLUMN', @level2name = N'ChangedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否改变', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyDetails', @level2type = N'COLUMN', @level2name = N'IsChange';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'排序', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyDetails', @level2type = N'COLUMN', @level2name = N'Sort';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'值班类型', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyDetails', @level2type = N'COLUMN', @level2name = N'DutyType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'值班人员', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyDetails', @level2type = N'COLUMN', @level2name = N'DutyUsers';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'值班日', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyDetails', @level2type = N'COLUMN', @level2name = N'DutyDay';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否领导', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyDetails', @level2type = N'COLUMN', @level2name = N'IsLeader';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'值班表ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyDetails', @level2type = N'COLUMN', @level2name = N'DutyId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyDetails', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'值班详情表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyDetails';

