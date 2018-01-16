using LeaRun.Data;
using LeaRun.WebBase;
using System;

namespace LeaRun.EmergencyDuty.Entity
{
    public partial class DutyNoteDaysEntity : BaseEntity
    {
        /// <summary>
        ///ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        ///��־����
        /// </summary>
        public string LogName { get; set; }
        /// <summary>
        ///��ǰ��ֵ����
        /// </summary>
        public string ChiefUser { get; set; }
        /// <summary>
        ///��ǰ��ֵ����
        /// </summary>
        public string ViceUser { get; set; }
        /// <summary>
        ///ֵ����
        /// </summary>
        public string DutyType { get; set; }
        /// <summary>
        ///���߰�ֵ����
        /// </summary>
        public string HotlineUser { get; set; }
        /// <summary>
        ///�Ӱ���ֵ����
        /// </summary>
        public string NextChiefUser { get; set; }
        /// <summary>
        ///״̬
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        ///��ʼʱ��
        /// </summary>
        public DateTime? StartedAt { get; set; }
        /// <summary>
        ///����ʱ��
        /// </summary>
        public DateTime? EndedAt { get; set; }
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
