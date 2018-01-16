using LeaRun.Data;
using LeaRun.WebBase;
using System;

namespace LeaRun.EmergencyDuty.Entity
{
    public partial class DutyNoteOrdersEntity : BaseEntity
    {
        /// <summary>
        ///ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        ///关联日志ID
        /// </summary>
        public string NoteId { get; set; }
        /// <summary>
        ///标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        ///领导
        /// </summary>
        public string Leaderships { get; set; }
        /// <summary>
        ///抄送人1
        /// </summary>
        public string CarbonCopy1 { get; set; }
        /// <summary>
        ///抄送人2
        /// </summary>
        public string CarbonCopy2 { get; set; }
        /// <summary>
        ///是否短信
        /// </summary>
        public bool? IsSms { get; set; }
        /// <summary>
        ///是否贴头报
        /// </summary>
        public bool? IsHeadline { get; set; }
        /// <summary>
        ///是否摘报
        /// </summary>
        public bool? IsSummary { get; set; }
        /// <summary>
        ///是否快报
        /// </summary>
        public bool? IsExpress { get; set; }
        /// <summary>
        ///是否专报
        /// </summary>
        public bool? IsSpecial { get; set; }
        /// <summary>
        ///是否存档
        /// </summary>
        public bool? IsArchive { get; set; }
        /// <summary>
        ///审核意见
        /// </summary>
        public string AuditComment { get; set; }
        /// <summary>
        ///办理情况
        /// </summary>
        public string DealComment { get; set; }
        /// <summary>
        ///状态
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        ///审核人
        /// </summary>
        public string Auditor { get; set; }
        /// <summary>
        ///审核时间
        /// </summary>
        public DateTime? AuditedAt { get; set; }
        /// <summary>
        ///经办人
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        ///操作时间
        /// </summary>
        public DateTime? OperatedAt { get; set; }
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
