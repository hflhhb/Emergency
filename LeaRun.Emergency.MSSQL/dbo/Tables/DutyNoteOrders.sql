CREATE TABLE [dbo].[DutyNoteOrders] (
    [Id]             NVARCHAR (50)   NOT NULL,
    [NoteId]         NVARCHAR (50)   NULL,
    [Title]          NVARCHAR (500)  NULL,
    [Leaderships]    NVARCHAR (1000) NULL,
    [CarbonCopy1]    NVARCHAR (200)  NULL,
    [CarbonCopy2]    NVARCHAR (200)  NULL,
    [IsSms]          BIT             NULL,
    [IsHeadline]     BIT             NULL,
    [IsSummary]      BIT             NULL,
    [IsExpress]      BIT             NULL,
    [IsSpecial]      BIT             NULL,
    [IsArchive]      BIT             NULL,
    [AuditComment]   NVARCHAR (2000) NULL,
    [DealComment]    NVARCHAR (2000) NULL,
    [Status]         INT             NULL,
    [Auditor]        NVARCHAR (50)   NULL,
    [AuditedAt]      DATETIME        NULL,
    [Operator]       NVARCHAR (50)   NULL,
    [OperatedAt]     DATETIME        NULL,
    [CreateUserId]   NVARCHAR (50)   NULL,
    [CreateUserName] NVARCHAR (50)   NULL,
    [CreatedAt]      DATETIME        NULL,
    [CreateDeptId]   NVARCHAR (50)   NULL,
    CONSTRAINT [PK_DutyNoteOrders] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人部门', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'CreateDeptId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'CreatedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'CreateUserName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'CreateUserId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'操作时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'OperatedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'经办人', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'Operator';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'审核时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'AuditedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'审核人', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'Auditor';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'状态', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'Status';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'办理情况', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'DealComment';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'审核意见', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'AuditComment';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否存档', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'IsArchive';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否专报', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'IsSpecial';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否快报', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'IsExpress';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否摘报', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'IsSummary';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否贴头报', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'IsHeadline';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否短信', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'IsSms';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'抄送人2', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'CarbonCopy2';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'抄送人1', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'CarbonCopy1';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'领导', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'Leaderships';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'标题', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'Title';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'关联日志ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'NoteId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'值班日志处理单', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteOrders';

