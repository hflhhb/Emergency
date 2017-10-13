CREATE TABLE [dbo].[DutyUsers] (
    [Id]             NVARCHAR (50)  NOT NULL,
    [UserName]       NVARCHAR (50)  NULL,
    [DeptId]         NVARCHAR (50)  NULL,
    [DeptName]       NVARCHAR (50)  NULL,
    [DutyName]       NVARCHAR (100) NULL,
    [JobName]        NVARCHAR (100) NULL,
    [TelNo]          NVARCHAR (50)  NULL,
    [Mobile]         NVARCHAR (50)  NULL,
    [IsLeader]       BIT            NULL,
    [Sort]           INT            NULL,
    [CreateUserId]   NVARCHAR (50)  NULL,
    [CreateUserName] NVARCHAR (50)  NULL,
    [CreatedAt]      DATETIME       NULL,
    [CreateDeptId]   NVARCHAR (50)  NULL,
    CONSTRAINT [PK_DutyUsers] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人部门', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyUsers', @level2type = N'COLUMN', @level2name = N'CreateDeptId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyUsers', @level2type = N'COLUMN', @level2name = N'CreatedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyUsers', @level2type = N'COLUMN', @level2name = N'CreateUserName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyUsers', @level2type = N'COLUMN', @level2name = N'CreateUserId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'排序', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyUsers', @level2type = N'COLUMN', @level2name = N'Sort';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否领导', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyUsers', @level2type = N'COLUMN', @level2name = N'IsLeader';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'手机', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyUsers', @level2type = N'COLUMN', @level2name = N'Mobile';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'电话', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyUsers', @level2type = N'COLUMN', @level2name = N'TelNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'职责名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyUsers', @level2type = N'COLUMN', @level2name = N'JobName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'职务名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyUsers', @level2type = N'COLUMN', @level2name = N'DutyName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'部门名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyUsers', @level2type = N'COLUMN', @level2name = N'DeptName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'所在部门', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyUsers', @level2type = N'COLUMN', @level2name = N'DeptId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'值班人员名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyUsers', @level2type = N'COLUMN', @level2name = N'UserName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyUsers', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'值班人员表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyUsers';

