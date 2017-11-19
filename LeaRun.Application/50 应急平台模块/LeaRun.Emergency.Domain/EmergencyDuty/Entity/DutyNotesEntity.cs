using LeaRun.Data;
using LeaRun.WebBase;
using System;

namespace LeaRun.EmergencyDuty.Entity
{
    public partial class DutyNotesEntity : BaseEntity
    {
        /// <summary>
        ///ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        ///ֵ����Id
        /// </summary>
        public int? DayId { get; set; }
        /// <summary>
        ///����
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        ///�·�ʱ��
        /// </summary>
        public DateTime? LogedAt { get; set; }
        /// <summary>
        ///���͵�λ
        /// </summary>
        public string SendDept { get; set; }
        /// <summary>
        ///�ӱ���
        /// </summary>
        public string ReportUser { get; set; }
        /// <summary>
        ///�ӱ���ʽ
        /// </summary>
        public string ReportWay { get; set; }
        /// <summary>
        ///�¼������
        /// </summary>
        public string EvtClass { get; set; }
        /// <summary>
        ///�¼�С���
        /// </summary>
        public string EvtSubClass { get; set; }
        /// <summary>
        ///����
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        ///������
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        ///��ע
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        ///�Ƿ��ϱ�
        /// </summary>
        public bool? IsSend { get; set; }
        /// <summary>
        ///�ϱ�ʱ��
        /// </summary>
        public DateTime? SentAt { get; set; }
        /// <summary>
        ///�Ƿ����
        /// </summary>
        public bool? IsUsed { get; set; }
        /// <summary>
        ///����ʱ��
        /// </summary>
        public DateTime? UsededAt { get; set; }
        /// <summary>
        ///�·�����
        /// </summary>
        public string EvtArea { get; set; }
        /// <summary>
        ///Guid��ʶ
        /// </summary>
        public string UniqueId { get; set; }
        /// <summary>
        ///�Ƿ�Ϊ��Ϣ����
        /// </summary>
        public bool? IsEmeRpt { get; set; }
        /// <summary>
        ///�Ƿ����
        /// </summary>
        public bool? IsSms { get; set; }
        /// <summary>
        ///�Ƿ�ժ��
        /// </summary>
        public bool? IsSummary { get; set; }
        /// <summary>
        ///�Ƿ�챨
        /// </summary>
        public bool? IsExpress { get; set; }
        /// <summary>
        ///�Ƿ�ר��
        /// </summary>
        public bool? IsSpecial { get; set; }
        /// <summary>
        ///�Ƿ�浵
        /// </summary>
        public bool? IsArchive { get; set; }
        /// <summary>
        ///��Ϣ��Դ
        /// </summary>
        public int? InfoType { get; set; }
        /// <summary>
        ///��־����
        ///<para>0:���� 1:�¼�</para>
        /// </summary>
        public int? NoteType { get; set; }
        /// <summary>
        ///�¼��̶�
        /// </summary>
        public string EvtDegree { get; set; }
        /// <summary>
        ///��������
        /// </summary>
        public string RptType { get; set; }
        /// <summary>
        ///����ʱ��
        /// </summary>
        public DateTime? FirstReportedAt { get; set; }
        /// <summary>
        ///�¼����
        /// </summary>
        public string EvtNo { get; set; }
        /// <summary>
        ///���Ͳ���ID
        /// </summary>
        public int? ReportDeptId { get; set; }
        /// <summary>
        ///���Ͳ�������
        /// </summary>
        public string ReportDeptName { get; set; }
        /// <summary>
        ///�ӱ�ʱ��
        /// </summary>
        public DateTime? ReceivedAt { get; set; }
        /// <summary>
        ///�����˱�ʶ
        /// </summary>
        public string CreateUserId { get; set; }
        /// <summary>
        ///����������
        /// </summary>
        public string CreateUserName { get; set; }
        /// <summary>
        ///����ʱ��
        /// </summary>
        public DateTime? CreatedAt { get; set; }
        /// <summary>
        ///�����˲���
        /// </summary>
        public string CreateDeptId { get; set; }

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedAt = DateTime.Now;
            this.CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.CreateUserName = OperatorProvider.Provider.Current().UserName;
            this.CreateDeptId = OperatorProvider.Provider.Current().DepartmentId;

        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.Id = keyValue;

        }
        #endregion

    }
}
