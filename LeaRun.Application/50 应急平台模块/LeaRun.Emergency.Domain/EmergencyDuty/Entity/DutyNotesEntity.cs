using LeaRun.Data;
using LeaRun.WebBase;
using System;

namespace LeaRun.EmergencyDuty.Entity
{
    public partial class DutyNotesEntity : BaseEntity
    {
        /// <summary>
        ///ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        ///值班日Id
        /// </summary>
        public int? DayId { get; set; }
        /// <summary>
        ///标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        ///事发时间
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
        ///事件大类别
        /// </summary>
        public string EvtClass { get; set; }
        /// <summary>
        ///事件小类别
        /// </summary>
        public string EvtSubClass { get; set; }
        /// <summary>
        ///内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        ///处理结果
        /// </summary>
        public string Result { get; set; }
        /// <summary>
        ///备注
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        ///是否上报
        /// </summary>
        public bool? IsSend { get; set; }
        /// <summary>
        ///上报时间
        /// </summary>
        public DateTime? SentAt { get; set; }
        /// <summary>
        ///是否采用
        /// </summary>
        public bool? IsUsed { get; set; }
        /// <summary>
        ///采用时间
        /// </summary>
        public DateTime? UsededAt { get; set; }
        /// <summary>
        ///事发区域
        /// </summary>
        public string EvtArea { get; set; }
        /// <summary>
        ///Guid标识
        /// </summary>
        public string UniqueId { get; set; }
        /// <summary>
        ///是否为信息报送
        /// </summary>
        public bool? IsEmeRpt { get; set; }
        /// <summary>
        ///是否短信
        /// </summary>
        public bool? IsSms { get; set; }
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
        ///信息来源
        /// </summary>
        public int? InfoType { get; set; }
        /// <summary>
        ///日志类型
        ///<para>0:其他 1:事件</para>
        /// </summary>
        public int? NoteType { get; set; }
        /// <summary>
        ///事件程度
        /// </summary>
        public string EvtDegree { get; set; }
        /// <summary>
        ///报送类型
        /// </summary>
        public string RptType { get; set; }
        /// <summary>
        ///初报时间
        /// </summary>
        public DateTime? FirstReportedAt { get; set; }
        /// <summary>
        ///事件编号
        /// </summary>
        public string EvtNo { get; set; }
        /// <summary>
        ///报送部门ID
        /// </summary>
        public int? ReportDeptId { get; set; }
        /// <summary>
        ///报送部门名称
        /// </summary>
        public string ReportDeptName { get; set; }
        /// <summary>
        ///接报时间
        /// </summary>
        public DateTime? ReceivedAt { get; set; }
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
