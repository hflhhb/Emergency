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
        ///标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        ///值班表类型
        ///<para>10: 月值班表 20: 午值班表 30: 机动值班表 40: 驾驶员值班表 50: 节假日领导值班表</para>
        /// </summary>
        public int? DutyClass { get; set; }
        /// <summary>
        ///开始时间
        /// </summary>
        public DateTime? StartedOn { get; set; }
        /// <summary>
        ///结束时间
        /// </summary>
        public DateTime? EndedOn { get; set; }
        /// <summary>
        ///联系人
        /// </summary>
        public string Contacts { get; set; }
        /// <summary>
        ///联系人电话
        /// </summary>
        public string ContactsTelNo { get; set; }
        /// <summary>
        ///备注
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        ///上传文件路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        ///是否审核
        /// </summary>
        public bool? IsCheck { get; set; }
        /// <summary>
        ///审核日期
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
        ///是否采用
        /// </summary>
        public bool? IsSend { get; set; }
        /// <summary>
        ///采用日期
        /// </summary>
        public DateTime? SentAt { get; set; }
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
