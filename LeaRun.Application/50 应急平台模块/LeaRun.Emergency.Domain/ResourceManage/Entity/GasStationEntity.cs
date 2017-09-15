using System;
using LeaRun.Data;
using LeaRun.WebBase;

namespace LeaRun.ResourceManage.Entity
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2017-2020 HFL
    /// 创 建：admin
    /// 日 期：2017-09-15 18:12
    /// 描 述：GasStation
    /// </summary>
    public class GasStationEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        public string Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        /// <returns></returns>
        public string Address { get; set; }
        /// <summary>
        /// LinkPhone
        /// </summary>
        /// <returns></returns>
        public string LinkPhone { get; set; }
        /// <summary>
        /// LegalPerson
        /// </summary>
        /// <returns></returns>
        public string LegalPerson { get; set; }
        /// <summary>
        /// LinkPerson
        /// </summary>
        /// <returns></returns>
        public string LinkPerson { get; set; }
        /// <summary>
        /// StartTime
        /// </summary>
        /// <returns></returns>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// Longitude
        /// </summary>
        /// <returns></returns>
        public decimal? Longitude { get; set; }
        /// <summary>
        /// Latitude
        /// </summary>
        /// <returns></returns>
        public decimal? Latitude { get; set; }
        /// <summary>
        /// Remark
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// State
        /// </summary>
        /// <returns></returns>
        public string State { get; set; }
        /// <summary>
        /// CreateTime
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// CreateUser
        /// </summary>
        /// <returns></returns>
        public string CreateUser { get; set; }
        #endregion

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