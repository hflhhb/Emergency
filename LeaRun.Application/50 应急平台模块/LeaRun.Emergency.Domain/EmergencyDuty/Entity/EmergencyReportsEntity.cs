using LeaRun.Data;
using LeaRun.WebBase;
using System;

namespace LeaRun.EmergencyDuty.Entity
{
    public partial class EmergencyReportsEntity : BaseEntity
    {
        /// <summary>
        ///ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        ///事件标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        ///报送单位
        /// </summary>
        public string SendDept { get; set; }
        /// <summary>
        ///报送人员
        /// </summary>
        public string SendMan { get; set; }
        /// <summary>
        ///签发人员
        /// </summary>
        public string Signer { get; set; }
        /// <summary>
        ///联系电话
        /// </summary>
        public string ContactTelNo { get; set; }
        /// <summary>
        ///事发时间
        /// </summary>
        public DateTime? EvtDate { get; set; }
        /// <summary>
        ///事件程度
        /// </summary>
        public string EvtDegree { get; set; }
        /// <summary>
        ///事发区域
        /// </summary>
        public string EvtArea { get; set; }
        /// <summary>
        ///具体地址
        /// </summary>
        public string EvtAddress { get; set; }
        /// <summary>
        ///事件起因
        /// </summary>
        public string EvtReason { get; set; }
        /// <summary>
        ///事件大类别
        /// </summary>
        public int? EvtClass { get; set; }
        /// <summary>
        ///事件小类别
        /// </summary>
        public int? EvtSubClass { get; set; }
        /// <summary>
        ///基本过程
        /// </summary>
        public string BaseInfo { get; set; }
        /// <summary>
        ///死亡人数
        /// </summary>
        public int? DeathNum { get; set; }
        /// <summary>
        ///重伤人数
        /// </summary>
        public int? SeriousHurtNum { get; set; }
        /// <summary>
        ///轻伤人数
        /// </summary>
        public int? MinorHurtNum { get; set; }
        /// <summary>
        ///财产损失
        /// </summary>
        public string LoseInfo { get; set; }
        /// <summary>
        ///影响区域
        /// </summary>
        public string AffectAreas { get; set; }
        /// <summary>
        ///影响人数
        /// </summary>
        public int? AffectUserNum { get; set; }
        /// <summary>
        ///发展趋势
        /// </summary>
        public string DriftInfo { get; set; }
        /// <summary>
        ///处置情况
        /// </summary>
        public string DealInfo { get; set; }
        /// <summary>
        ///拟采取措施
        /// </summary>
        public string PlanInfo { get; set; }
        /// <summary>
        ///其他情况说明
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
        ///Guid标识
        /// </summary>
        public string UniqueId { get; set; }
        /// <summary>
        ///状态
        /// </summary>
        public int? Status { get; set; }
        /// <summary>
        ///关联事件ID
        /// </summary>
        public string EvtId { get; set; }
        /// <summary>
        ///退回时间
        /// </summary>
        public DateTime? BackedAt { get; set; }
        /// <summary>
        ///
        /// </summary>
        public int? Estimate { get; set; }
        /// <summary>
        ///三级人员
        /// </summary>
        public bool? IsSan { get; set; }
        /// <summary>
        ///日志
        /// </summary>
        public bool? IsLog { get; set; }
        /// <summary>
        ///
        /// </summary>
        public bool? IsSend1 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public bool? IsUsed1 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public DateTime? SendTime1 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public DateTime? UsedTime1 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public DateTime? BackTime1 { get; set; }
        /// <summary>
        ///
        /// </summary>
        public int? Status1 { get; set; }
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
