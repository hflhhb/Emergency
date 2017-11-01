using LeaRun.Data;
using LeaRun.WebBase;
using System;

namespace LeaRun.EmergencyDuty.Entity
{
    public partial class DutyNoteDealsEntity : BaseEntity
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
        ///����ʱ��
        /// </summary>
        public DateTime? DealedAt { get; set; }
        /// <summary>
        ///����
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        ///״̬
        /// </summary>
        public string Status { get; set; }
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
