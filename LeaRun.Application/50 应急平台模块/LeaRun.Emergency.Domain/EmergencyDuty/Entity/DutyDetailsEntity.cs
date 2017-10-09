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
        ///值班表ID
        /// </summary>
        public string DutyId { get; set; }
        /// <summary>
        ///是否领导
        /// </summary>
        public bool? IsLeader { get; set; }
        /// <summary>
        ///值班日
        /// </summary>
        public DateTime? DutyDay { get; set; }
        /// <summary>
        ///值班人员
        /// </summary>
        public string DutyUsers { get; set; }
        /// <summary>
        ///值班类型
        /// </summary>
        public int? DutyType { get; set; }
        /// <summary>
        ///排序
        /// </summary>
        public int? Sort { get; set; }
        /// <summary>
        ///是否改变
        /// </summary>
        public bool? IsChange { get; set; }
        /// <summary>
        ///改变日期
        /// </summary>
        public DateTime? ChangedAt { get; set; }
        /// <summary>
        ///
        /// </summary>
        public int? GroupId { get; set; }

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.Id = Guid.NewGuid().ToString();

        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.Id = keyValue;

        }
        #endregion

    }
}
