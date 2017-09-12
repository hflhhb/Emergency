using System;
using LeaRun.Data;
using LeaRun.WebBase;

namespace LeaRun.ResourceManage.Entity
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2017-2020 肖海根
    /// 创 建：HFL
    /// 日 期：2017-09-13 00:46
    /// 描 述：Camera
    /// </summary>
    public class CameraEntity : BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// Id
        /// </summary>
        /// <returns></returns>
        public string Id { get; set; }
        /// <summary>
        /// Code
        /// </summary>
        /// <returns></returns>
        public string Code { get; set; }
        /// <summary>
        /// Area
        /// </summary>
        /// <returns></returns>
        public string Area { get; set; }
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
        /// Latitude
        /// </summary>
        /// <returns></returns>
        public decimal? Latitude { get; set; }
        /// <summary>
        /// Longitude
        /// </summary>
        /// <returns></returns>
        public decimal? Longitude { get; set; }
        /// <summary>
        /// Url
        /// </summary>
        /// <returns></returns>
        public string Url { get; set; }
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
        /// <summary>
        /// Remark
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
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