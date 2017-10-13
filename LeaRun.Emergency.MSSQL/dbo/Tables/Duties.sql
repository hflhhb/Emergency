CREATE TABLE [dbo].[Duties] (
    [Id]             NVARCHAR (50)   NOT NULL,
    [Title]          NVARCHAR (200)  NULL,
    [DutyClass]      INT             NULL,
    [StartedOn]      DATETIME        NULL,
    [EndedOn]        DATETIME        NULL,
    [Contacts]       NVARCHAR (50)   NULL,
    [ContactsTelNo]  NVARCHAR (50)   NULL,
    [Remarks]        NVARCHAR (2000) NULL,
    [FilePath]       NVARCHAR (200)  NULL,
    [IsCheck]        BIT             NULL,
    [CheckedAt]      DATETIME        NULL,
    [IsBack]         BIT             NULL,
    [BackedAt]       DATETIME        NULL,
    [IsSend]         BIT             NULL,
    [SentAt]         DATETIME        NULL,
    [CreateUserId]   NVARCHAR (50)   NULL,
    [CreateUserName] NVARCHAR (50)   NULL,
    [CreatedAt]      DATETIME        NULL,
    [CreateDeptId]   NVARCHAR (50)   NULL,
    CONSTRAINT [PK_Duties] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人部门', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Duties', @level2type = N'COLUMN', @level2name = N'CreateDeptId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Duties', @level2type = N'COLUMN', @level2name = N'CreatedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Duties', @level2type = N'COLUMN', @level2name = N'CreateUserName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Duties', @level2type = N'COLUMN', @level2name = N'CreateUserId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'采用日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Duties', @level2type = N'COLUMN', @level2name = N'SentAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否采用', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Duties', @level2type = N'COLUMN', @level2name = N'IsSend';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'审核日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Duties', @level2type = N'COLUMN', @level2name = N'CheckedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否审核', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Duties', @level2type = N'COLUMN', @level2name = N'IsCheck';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'上传文件路径', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Duties', @level2type = N'COLUMN', @level2name = N'FilePath';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Duties', @level2type = N'COLUMN', @level2name = N'Remarks';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'联系人电话', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Duties', @level2type = N'COLUMN', @level2name = N'ContactsTelNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'联系人', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Duties', @level2type = N'COLUMN', @level2name = N'Contacts';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'结束时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Duties', @level2type = N'COLUMN', @level2name = N'EndedOn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'开始时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Duties', @level2type = N'COLUMN', @level2name = N'StartedOn';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'值班表类型 10: 月值班表 20: 午值班表 30: 机动值班表 40: 驾驶员值班表 50: 节假日领导值班表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Duties', @level2type = N'COLUMN', @level2name = N'DutyClass';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'标题', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Duties', @level2type = N'COLUMN', @level2name = N'Title';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Duties', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'值班表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Duties';

