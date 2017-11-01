CREATE TABLE [dbo].[DutyNoteDays] (
    [Id]             NVARCHAR (50)  NOT NULL,
    [LogName]        NVARCHAR (200) NULL,
    [ChiefUser]      NVARCHAR (50)  NULL,
    [ViceUser]       NVARCHAR (50)  NULL,
    [DutyType]       NVARCHAR (50)  NULL,
    [HotlineUser]    NVARCHAR (50)  NULL,
    [NextChiefUser]  NVARCHAR (50)  NULL,
    [Status]         INT            NULL,
    [StartedAt]      DATETIME       NULL,
    [EndedAt]        DATETIME       NULL,
    [CreateUserId]   NVARCHAR (50)  NULL,
    [CreateUserName] NVARCHAR (50)  NULL,
    [CreatedAt]      DATETIME       NULL,
    [CreateDeptId]   NVARCHAR (50)  NULL,
    CONSTRAINT [PK_DutyNoteDays] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人部门', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDays', @level2type = N'COLUMN', @level2name = N'CreateDeptId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDays', @level2type = N'COLUMN', @level2name = N'CreatedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDays', @level2type = N'COLUMN', @level2name = N'CreateUserName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDays', @level2type = N'COLUMN', @level2name = N'CreateUserId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'结束时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDays', @level2type = N'COLUMN', @level2name = N'EndedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'开始时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDays', @level2type = N'COLUMN', @level2name = N'StartedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'状态', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDays', @level2type = N'COLUMN', @level2name = N'Status';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'接班主值班人', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDays', @level2type = N'COLUMN', @level2name = N'NextChiefUser';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'热线办值班人', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDays', @level2type = N'COLUMN', @level2name = N'HotlineUser';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'值班班次', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDays', @level2type = N'COLUMN', @level2name = N'DutyType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'当前副值班人', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDays', @level2type = N'COLUMN', @level2name = N'ViceUser';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'当前主值班人', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDays', @level2type = N'COLUMN', @level2name = N'ChiefUser';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDays', @level2type = N'COLUMN', @level2name = N'LogName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDays', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'值班日日志', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDays';

