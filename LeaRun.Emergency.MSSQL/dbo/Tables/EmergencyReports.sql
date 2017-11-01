CREATE TABLE [dbo].[EmergencyReports] (
    [Id]             NVARCHAR (50)   NOT NULL,
    [Title]          NVARCHAR (500)  NULL,
    [SendDept]       NVARCHAR (500)  NULL,
    [SendMan]        NVARCHAR (50)   NULL,
    [Signer]         NVARCHAR (50)   NULL,
    [ContactTelNo]   NVARCHAR (50)   NULL,
    [EvtDate]        DATETIME        NULL,
    [EvtDegree]      NVARCHAR (10)   NULL,
    [EvtArea]        NVARCHAR (50)   NULL,
    [EvtAddress]     NVARCHAR (500)  NULL,
    [EvtReason]      NVARCHAR (2000) NULL,
    [EvtClass]       INT             NULL,
    [EvtSubClass]    INT             NULL,
    [BaseInfo]       NVARCHAR (2000) NULL,
    [DeathNum]       INT             NULL,
    [SeriousHurtNum] INT             NULL,
    [MinorHurtNum]   INT             NULL,
    [LoseInfo]       NVARCHAR (2000) NULL,
    [AffectAreas]    NVARCHAR (4000) NULL,
    [AffectUserNum]  INT             NULL,
    [DriftInfo]      NVARCHAR (2000) NULL,
    [DealInfo]       NVARCHAR (2000) NULL,
    [PlanInfo]       NVARCHAR (2000) NULL,
    [Remarks]        NVARCHAR (2000) NULL,
    [IsSend]         BIT             NULL,
    [SentAt]         DATETIME        NULL,
    [IsUsed]         BIT             NULL,
    [UsededAt]       DATETIME        NULL,
    [UniqueId]       NVARCHAR (50)   NULL,
    [Status]         INT             NULL,
    [EvtId]          NVARCHAR (50)   NULL,
    [BackedAt]       DATETIME        NULL,
    [Estimate]       INT             NULL,
    [IsSan]          BIT             NULL,
    [IsLog]          BIT             NULL,
    [IsSend1]        BIT             NULL,
    [IsUsed1]        BIT             NULL,
    [SendTime1]      DATETIME        NULL,
    [UsedTime1]      DATETIME        NULL,
    [BackTime1]      DATETIME        NULL,
    [Status1]        INT             NULL,
    [CreateUserId]   NVARCHAR (50)   NULL,
    [CreateUserName] NVARCHAR (50)   NULL,
    [CreatedAt]      DATETIME        NULL,
    [CreateDeptId]   NVARCHAR (50)   NULL,
    CONSTRAINT [PK_EmergencyReports] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人部门', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'CreateDeptId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'CreatedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'CreateUserName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'创建人标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'CreateUserId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'日志', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'IsLog';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'三级人员', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'IsSan';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'退回时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'BackedAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'关联事件ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'EvtId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'状态', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'Status';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Guid标识', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'UniqueId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'采用时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'UsededAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否采用', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'IsUsed';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'上报时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'SentAt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'是否上报', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'IsSend';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'其他情况说明', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'Remarks';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'拟采取措施', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'PlanInfo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'处置情况', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'DealInfo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'发展趋势', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'DriftInfo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'影响人数', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'AffectUserNum';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'影响区域', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'AffectAreas';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'财产损失', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'LoseInfo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'轻伤人数', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'MinorHurtNum';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'重伤人数', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'SeriousHurtNum';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'死亡人数', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'DeathNum';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'基本过程', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'BaseInfo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'事件小类别', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'EvtSubClass';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'事件大类别', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'EvtClass';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'事件起因', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'EvtReason';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'具体地址', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'EvtAddress';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'事发区域', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'EvtArea';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'事件程度', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'EvtDegree';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'事发时间', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'EvtDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'联系电话', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'ContactTelNo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'签发人员', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'Signer';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'报送人员', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'SendMan';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'报送单位', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'SendDept';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'事件标题', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'Title';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports', @level2type = N'COLUMN', @level2name = N'Id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'突发事件上报', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'EmergencyReports';

