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
        ///值班人员名称
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        ///所在部门
        /// </summary>
        public string DeptId { get; set; }
        /// <summary>
        ///部门名称
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        ///职务名称
        /// </summary>
        public string DutyName { get; set; }
        /// <summary>
        ///职责名称
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        ///电话
        /// </summary>
        public string TelNo { get; set; }
        /// <summary>
        ///手机
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        ///是否领导
        /// </summary>
        public bool? IsLeader { get; set; }
        /// <summary>
        ///排序
        /// </summary>
        public int? Sort { get; set; }
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
