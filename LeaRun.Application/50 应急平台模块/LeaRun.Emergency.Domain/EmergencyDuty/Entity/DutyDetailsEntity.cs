using LeaRun.Data;
using LeaRun.WebBase;
using System;

namespace LeaRun.EmergencyDuty.Entity
{
    public partial class DutyDetailsEntity : BaseEntity
    {
        /// <summary>
        ///ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        ///ֵ���ID
        /// </summary>
        public string DutyId { get; set; }
        /// <summary>
        ///�Ƿ��쵼
        /// </summary>
        public bool? IsLeader { get; set; }
        /// <summary>
        ///ֵ����
        /// </summary>
        public DateTime? DutyDay { get; set; }
        /// <summary>
        ///ֵ����Ա
        /// </summary>
        public string DutyUsers { get; set; }
        /// <summary>
        ///ֵ������
        /// </summary>
        public int? DutyType { get; set; }
        /// <summary>
        ///����
        /// </summary>
        public int? Sort { get; set; }
        /// <summary>
        ///�Ƿ�ı�
        /// </summary>
        public bool? IsChange { get; set; }
        /// <summary>
        ///�ı�����
        /// </summary>
        public DateTime? ChangedAt { get; set; }
        /// <summary>
        ///
        /// </summary>
        public int? GroupId { get; set; }

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.Id = Guid.NewGuid().ToString();

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
