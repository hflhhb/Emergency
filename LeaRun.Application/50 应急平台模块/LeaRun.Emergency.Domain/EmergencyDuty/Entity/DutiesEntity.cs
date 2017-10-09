using LeaRun.Data;
using LeaRun.WebBase;
using System;

namespace LeaRun.EmergencyDuty.Entity
{
    public partial class DutiesEntity : BaseEntity
    {
        /// <summary>
        ///ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        ///����
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        ///ֵ�������
        ///<para>10: ��ֵ��� 20: ��ֵ��� 30: ����ֵ��� 40: ��ʻԱֵ��� 50: �ڼ����쵼ֵ���</para>
        /// </summary>
        public int? DutyClass { get; set; }
        /// <summary>
        ///��ʼʱ��
        /// </summary>
        public DateTime? StartedOn { get; set; }
        /// <summary>
        ///����ʱ��
        /// </summary>
        public DateTime? EndedOn { get; set; }
        /// <summary>
        ///��ϵ��
        /// </summary>
        public string Contacts { get; set; }
        /// <summary>
        ///��ϵ�˵绰
        /// </summary>
        public string ContactsTelNo { get; set; }
        /// <summary>
        ///��ע
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        ///�ϴ��ļ�·��
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        ///�Ƿ����
        /// </summary>
        public bool? IsCheck { get; set; }
        /// <summary>
        ///�������
        /// </summary>
        public DateTime? CheckedAt { get; set; }
        /// <summary>
        ///
        /// </summary>
        public bool? IsBack { get; set; }
        /// <summary>
        ///
        /// </summary>
        public DateTime? BackedAt { get; set; }
        /// <summary>
        ///�Ƿ����
        /// </summary>
        public bool? IsSend { get; set; }
        /// <summary>
        ///��������
        /// </summary>
        public DateTime? SentAt { get; set; }
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
