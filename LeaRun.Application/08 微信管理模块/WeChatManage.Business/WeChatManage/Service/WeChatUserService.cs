using LeaRun.WeChatManage.Entity;
using LeaRun.WeChatManage.IService;
using LeaRun.Data;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.WeChatManage.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创建人：肖海根
    /// 日 期：2016.12.23 11:31
    /// 描 述：企业号成员
    /// </summary>
    public class WeChatUserService : Dao<WeChatUserRelationEntity>, IWeChatUserService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public WeChatUserService(DbContextBase dbcontext) : base(dbcontext){ }

        #region 获取数据
        /// <summary>
        /// 成员列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WeChatUserRelationEntity> GetList()
        {
            return base.Queryable().ToList();
        }
        /// <summary>
        /// 成员实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public WeChatUserRelationEntity GetEntity(string keyValue)
        {
            return base.FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除成员
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            base.Delete(keyValue);
        }
        /// <summary>
        /// 成员（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="weChatUserRelationEntity">用户实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, WeChatUserRelationEntity weChatUserRelationEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                weChatUserRelationEntity.Modify(keyValue);
                base.Update(weChatUserRelationEntity);
            }
            else
            {
                weChatUserRelationEntity.Create();
                base.Insert(weChatUserRelationEntity);
            }
        }
        #endregion
    }
}
