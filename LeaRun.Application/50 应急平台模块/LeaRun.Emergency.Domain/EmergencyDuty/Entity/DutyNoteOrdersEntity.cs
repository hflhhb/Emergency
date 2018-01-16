using LeaRun.Data;
using LeaRun.WebBase;
using System;

namespace LeaRun.EmergencyDuty.Entity
{
    public partial class DutyNoteOrdersEntity : BaseEntity
    {
        /// <summary>
        ///ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        ///������־ID
        /// </summary>
        public string NoteId { get; set; }
        /// <summary>
        ///����
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        ///�쵼
        /// </summary>
        public string Leaderships { get; set; }
        /// <summary>
        ///������1
        /// </summary>
        public string CarbonCopy1 { get; set; }
        /// <summary>
        ///������2
        /// </summary>
        public string CarbonCopy2 { get; set; }
        /// <summary>
        ///�Ƿ����
        /// </summary>
        public bool? IsSms { get; set; }
        /// <summary>
        ///�Ƿ���ͷ��
        /// </summary>
        public bool? IsHeadline { get; set; }
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
        ///������
        /// </summary>
        public string AuditComment { get; set; }
        /// <summary>
        ///�������
        /// </summary>
        public string DealComment { get; set; }
        /// <summary>
        ///״̬
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        ///�����
        /// </summary>
        public string Auditor { get; set; }
        /// <summary>
        ///���ʱ��
        /// </summary>
        public DateTime? AuditedAt { get; set; }
        /// <summary>
        ///������
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        ///����ʱ��
        /// </summary>
        public DateTime? OperatedAt { get; set; }
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
