CREATE TABLE [dbo].[DutyNoteDeals] (
    [Id]             NVARCHAR (50) NOT NULL,
    [NoteId]         NVARCHAR (50) NULL,
    [DealedAt]       DATETIME      NULL,
    [Content]        NVARCHAR (50) NULL,
    [Status]         NVARCHAR (50) NULL,
    [CreateUserId]   NVARCHAR (50) NULL,
    [CreateUserName] NVARCHAR (50) NULL,
    [CreatedAt]      DATETIME      NULL,
    [CreateDeptId]   NVARCHAR (50) NULL,
    CONSTRAINT [PK_DutyNoteDeals] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人部门', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDeals', @level2type = N'COLUMN', @level2name = N'CreateDeptId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDeals', @level2type = N'COLUMN', @level2name = N'CreatedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDeals', @level2type = N'COLUMN', @level2name = N'CreateUserName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDeals', @level2type = N'COLUMN', @level2name = N'CreateUserId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'状态', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDeals', @level2type = N'COLUMN', @level2name = N'Status';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'内容', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDeals', @level2type = N'COLUMN', @level2name = N'Content';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'处置时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDeals', @level2type = N'COLUMN', @level2name = N'DealedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDeals', @level2type = N'COLUMN', @level2name = N'NoteId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDeals', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'值班日志处置', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteDeals';

