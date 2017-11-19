using LeaRun.Data;
using LeaRun.WebBase;
using System;

namespace LeaRun.EmergencyDuty.Entity
{
    public partial class DutyNoteReportsEntity : BaseEntity
    {
        /// <summary>
        ///ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        ///��־ID
        /// </summary>
        public string NoteId { get; set; }
        /// <summary>
        ///�ӱ�ʱ��
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
        ///����
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        ///�¼������
        /// </summary>
        public string EvtClass { get; set; }
        /// <summary>
        ///�¼�С���
        /// </summary>
        public string EvtSubClass { get; set; }
        /// <summary>
        ///�·�����
        /// </summary>
        public string EvtArea { get; set; }
        /// <summary>
        ///(�¼��ϱ����¼�Id
        /// </summary>
        public string EvtId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string RptType { get; set; }
        /// <summary>
        ///����
        /// </summary>
        public string NextReport { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string ReportId { get; set; }
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
