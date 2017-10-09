using LeaRun.Data;
using LeaRun.WebBase;
using System;

namespace LeaRun.EmergencyDuty.Entity
{
    public partial class DutyUsersEntity : BaseEntity
    {
        /// <summary>
        ///ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        ///ֵ����Ա����
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        ///���ڲ���
        /// </summary>
        public string DeptId { get; set; }
        /// <summary>
        ///��������
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        ///ְ������
        /// </summary>
        public string DutyName { get; set; }
        /// <summary>
        ///ְ������
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        ///�绰
        /// </summary>
        public string TelNo { get; set; }
        /// <summary>
        ///�ֻ�
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        ///�Ƿ��쵼
        /// </summary>
        public bool? IsLeader { get; set; }
        /// <summary>
        ///����
        /// </summary>
        public int? Sort { get; set; }
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
