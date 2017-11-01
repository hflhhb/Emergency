CREATE TABLE [dbo].[DutyNotes] (
    [Id]              NVARCHAR (50)   NOT NULL,
    [DayId]           INT             NULL,
    [Title]           NVARCHAR (500)  NULL,
    [LogedAt]         DATETIME        NULL,
    [SendDept]        NVARCHAR (50)   NULL,
    [ReportUser]      NVARCHAR (50)   NULL,
    [ReportWay]       NVARCHAR (50)   NULL,
    [EvtClass]        INT             NULL,
    [EvtSubClass]     INT             NULL,
    [Content]         NVARCHAR (2000) NULL,
    [Result]          NVARCHAR (500)  NULL,
    [Remarks]         NVARCHAR (500)  NULL,
    [IsSend]          BIT             NULL,
    [SentAt]          DATETIME        NULL,
    [IsUsed]          BIT             NULL,
    [UsededAt]        DATETIME        NULL,
    [EvtArea]         NVARCHAR (50)   NULL,
    [UniqueId]        NVARCHAR (50)   NULL,
    [IsEmeRpt]        BIT             NULL,
    [IsSms]           BIT             NULL,
    [IsSummary]       BIT             NULL,
    [IsExpress]       BIT             NULL,
    [IsSpecial]       BIT             NULL,
    [IsArchive]       BIT             NULL,
    [InfoType]        INT             NULL,
    [NoteType]        INT             NULL,
    [EvtDegree]       NVARCHAR (50)   NULL,
    [RptType]         NVARCHAR (50)   NULL,
    [FirstReportedAt] DATETIME        NULL,
    [EvtNo]           NVARCHAR (50)   NULL,
    [ReportDeptId]    INT             NULL,
    [ReportDeptName]  NVARCHAR (50)   NULL,
    [ReceivedAt]      DATETIME        NULL,
    [CreateUserId]    NVARCHAR (50)   NULL,
    [CreateUserName]  NVARCHAR (50)   NULL,
    [CreatedAt]       DATETIME        NULL,
    [CreateDeptId]    NVARCHAR (50)   NULL,
    CONSTRAINT [PK_DutyNotes] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人部门', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'CreateDeptId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'CreatedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'CreateUserName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'CreateUserId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'接报时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'ReceivedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'报送部门名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'ReportDeptName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'报送部门ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'ReportDeptId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'事件编号', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'EvtNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'初报时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'FirstReportedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'报送类型', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'RptType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'事件程度', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'EvtDegree';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志类型 0:其他 1:事件', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'NoteType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'信息来源', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'InfoType';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否存档', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'IsArchive';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否专报', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'IsSpecial';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否快报', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'IsExpress';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否摘报', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'IsSummary';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否短信', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'IsSms';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否为信息报送', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'IsEmeRpt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Guid标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'UniqueId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'事发区域', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'EvtArea';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'采用时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'UsededAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否采用', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'IsUsed';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'上报时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'SentAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否上报', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'IsSend';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'备注', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'Remarks';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'处理结果', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'Result';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'内容', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'Content';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'事件小类别', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'EvtSubClass';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'事件大类别', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'EvtClass';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'接报形式', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'ReportWay';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'接报人', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'ReportUser';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'报送单位', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'SendDept';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'事发时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'LogedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'标题', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'Title';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'值班日Id', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'DayId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'值班日志详情', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DutyNotes';

