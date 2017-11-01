using LeaRun.Data;
using LeaRun.WebBase;
using System;

namespace LeaRun.EmergencyDuty.Entity
{
    public partial class EmergencyReportsEntity : BaseEntity
    {
        /// <summary>
        ///ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        ///�¼�����
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        ///���͵�λ
        /// </summary>
        public string SendDept { get; set; }
        /// <summary>
        ///������Ա
        /// </summary>
        public string SendMan { get; set; }
        /// <summary>
        ///ǩ����Ա
        /// </summary>
        public string Signer { get; set; }
        /// <summary>
        ///��ϵ�绰
        /// </summary>
        public string ContactTelNo { get; set; }
        /// <summary>
        ///�·�ʱ��
        /// </summary>
        public DateTime? EvtDate { get; set; }
        /// <summary>
        ///�¼��̶�
        /// </summary>
        public string EvtDegree { get; set; }
        /// <summary>
        ///�·�����
        /// </summary>
        public string EvtArea { get; set; }
        /// <summary>
        ///�����ַ
        /// </summary>
        public string EvtAddress { get; set; }
        /// <summary>
        ///�¼�����
        /// </summary>
        public string EvtReason { get; set; }
        /// <summary>
        ///�¼������
        /// </summary>
        public int? EvtClass { get; set; }
        /// <summary>
        ///�¼�С���
        /// </summary>
        public int? EvtSubClass { get; set; }
        /// <summary>
        ///��������
        /// </summary>
        public string BaseInfo { get; set; }
        /// <summary>
        ///��������
        /// </summary>
        public int? DeathNum { get; set; }
        /// <summary>
        ///��������
        /// </summary>
        public int? SeriousHurtNum { get; set; }
        /// <summary>
        ///��������
        /// </summary>
        public int? MinorHurtNum { get; set; }
        /// <summary>
        ///�Ʋ���ʧ
        /// </summary>
        public string LoseInfo { get; set; }
        /// <summary>
        ///Ӱ������
        /// </summary>
        public string AffectAreas { get; set; }
        /// <summary>
        ///Ӱ������
        /// </summary>
        public int? AffectUserNum { get; set; }
        /// <summary>
        ///��չ����
        /// </summary>
        public string DriftInfo { get; set; }
        /// <summary>
        ///�������
        /// </summary>
        public string DealInfo { get; set; }
        /// <summary>
        ///���ȡ��ʩ
        /// </summary>
        public string PlanInfo { get; set; }
        /// <summary>
        ///�������˵��
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
        ///Guid��ʶ
        /// </summary>
        public string UniqueId { get; set; }
        /// <summary>
        ///״̬
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        ///�����¼�ID
        /// </summary>
        public string EvtId { get; set; }
        /// <summary>
        ///�˻�ʱ��
        /// </summary>
        public DateTime? BackedAt { get; set; }
        /// <summary>
        ///
        /// </summary>
        public int? Estimate { get; set; }
        /// <summary>
        ///������Ա
        /// </summary>
        public bool? IsSan { get; set; }
        /// <summary>
        ///��־
        /// </summary>
        public bool? IsLog { get; set; }
        /// <summary>
        ///
        /// </summary>
        public bool? IsSend1 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public bool? IsUsed1 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public DateTime? SendTime1 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public DateTime? UsedTime1 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public DateTime? BackTime1 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public int? Status1 { get; set; }
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
