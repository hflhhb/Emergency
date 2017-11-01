CREATE TABLE [dbo].[DutyNoteReports] (
    [Id]             NVARCHAR (50)   NOT NULL,
    [NoteId]         NVARCHAR (50)   NULL,
    [LogedAt]        DATETIME        NULL,
    [SendDept]       NVARCHAR (500)  NULL,
    [ReportUser]     NVARCHAR (50)   NULL,
    [ReportWay]      NVARCHAR (50)   NULL,
    [Content]        NVARCHAR (2000) NULL,
    [EvtClass]       INT             NULL,
    [EvtSubClass]    INT             NULL,
    [EvtArea]        NVARCHAR (50)   NULL,
    [EvtId]          NVARCHAR (50)   NULL,
    [RptType]        NVARCHAR (50)   NULL,
    [NextReport]     NVARCHAR (50)   NULL,
    [ReportId]       NVARCHAR (50)   NULL,
    [CreateUserId]   NVARCHAR (50)   NULL,
    [CreateUserName] NVARCHAR (50)   NULL,
    [CreatedAt]      DATETIME        NULL,
    [CreateDeptId]   NVARCHAR (50)   NULL,
    CONSTRAINT [PK_DutyNoteReports] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人部门', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteReports', @level2type = N'COLUMN', @level2name = N'CreateDeptId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteReports', @level2type = N'COLUMN', @level2name = N'CreatedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteReports', @level2type = N'COLUMN', @level2name = N'CreateUserName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteReports', @level2type = N'COLUMN', @level2name = N'CreateUserId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'续报', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteReports', @level2type = N'COLUMN', @level2name = N'NextReport';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'(事件上报）事件Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteReports', @level2type = N'COLUMN', @level2name = N'EvtId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'事发区域', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteReports', @level2type = N'COLUMN', @level2name = N'EvtArea';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'事件小类别', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteReports', @level2type = N'COLUMN', @level2name = N'EvtSubClass';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'事件大类别', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteReports', @level2type = N'COLUMN', @level2name = N'EvtClass';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'内容', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteReports', @level2type = N'COLUMN', @level2name = N'Content';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'接报形式', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteReports', @level2type = N'COLUMN', @level2name = N'ReportWay';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'接报人', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteReports', @level2type = N'COLUMN', @level2name = N'ReportUser';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'报送单位', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteReports', @level2type = N'COLUMN', @level2name = N'SendDept';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'接报时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteReports', @level2type = N'COLUMN', @level2name = N'LogedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteReports', @level2type = N'COLUMN', @level2name = N'NoteId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteReports', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'值班日志报送', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNoteReports';

