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
        ///日志名称
        /// </summary>
        public string LogName { get; set; }
        /// <summary>
        ///当前主值班人
        /// </summary>
        public string ChiefUser { get; set; }
        /// <summary>
        ///当前副值班人
        /// </summary>
        public string ViceUser { get; set; }
        /// <summary>
        ///值班班次
        /// </summary>
        public string DutyType { get; set; }
        /// <summary>
        ///热线办值班人
        /// </summary>
        public string HotlineUser { get; set; }
        /// <summary>
        ///接班主值班人
        /// </summary>
        public string NextChiefUser { get; set; }
        /// <summary>
        ///状态
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        ///开始时间
        /// </summary>
        public DateTime? StartedAt { get; set; }
        /// <summary>
        ///结束时间
        /// </summary>
        public DateTime? EndedAt { get; set; }
        /// <summary>
        ///创建人标识
        /// </summary>
        public string CreateUserId { get; set; }
        /// <summary>
        ///创建人名称
        /// </summary>
        public string CreateUserName { get; set; }
        /// <summary>
        ///创建时间
        /// </summary>
        public DateTime? CreatedAt { get; set; }
        /// <summary>
        ///创建人部门
        /// </summary>
        public string CreateDeptId { get; set; }

        #region 扩展操作
        /// <summary>
        /// 新增调用
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
