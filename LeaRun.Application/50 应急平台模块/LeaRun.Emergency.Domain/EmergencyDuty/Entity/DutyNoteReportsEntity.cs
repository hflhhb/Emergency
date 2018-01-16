using LeaRun.Data;
using LeaRun.WebBase;
using System;

namespace LeaRun.EmergencyDuty.Entity
{
    public partial class DutyNoteReportsEntity : BaseEntity
    {
        /// <summary>
        ///ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        ///日志ID
        /// </summary>
        public string NoteId { get; set; }
        /// <summary>
        ///接报时间
        /// </summary>
        public DateTime? LogedAt { get; set; }
        /// <summary>
        ///报送单位
        /// </summary>
        public string SendDept { get; set; }
        /// <summary>
        ///接报人
        /// </summary>
        public string ReportUser { get; set; }
        /// <summary>
        ///接报形式
        /// </summary>
        public string ReportWay { get; set; }
        /// <summary>
        ///内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        ///事件大类别
        /// </summary>
        public string EvtClass { get; set; }
        /// <summary>
        ///事件小类别
        /// </summary>
        public string EvtSubClass { get; set; }
        /// <summary>
        ///事发区域
        /// </summary>
        public string EvtArea { get; set; }
        /// <summary>
        ///(事件上报）事件Id
        /// </summary>
        public string EvtId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string RptType { get; set; }
        /// <summary>
        ///续报
        /// </summary>
        public string NextReport { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string ReportId { get; set; }
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
