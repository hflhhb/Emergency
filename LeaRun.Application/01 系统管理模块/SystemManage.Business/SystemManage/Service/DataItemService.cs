using LeaRun.SystemManage.Entity;
using LeaRun.SystemManage.IService;
using LeaRun.Data;
using LeaRun.Util.Extension;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.SystemManage.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.11.17 9:56
    /// 描 述：数据字典分类
    /// </summary>
    public class DataItemService : Dao<DataItemEntity>, IDataItemService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public DataItemService(DbContextBase dbcontext) : base(dbcontext){ }

        #region 获取数据
        /// <summary>
        /// 分类列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataItemEntity> GetList()
        {
            return base.Queryable().OrderBy(t => t.CreateDate).ToList();
        }
        /// <summary>
        /// 分类实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public DataItemEntity GetEntity(string keyValue)
        {
            return base.FindEntity(keyValue);
        }
        /// <summary>
        /// 根据分类编号获取实体对象
        /// </summary>
        /// <param name="ItemCode">编号</param>
        /// <returns></returns>
        public DataItemEntity GetEntityByCode(string ItemCode)
        {
            var expression = LinqExtensions.True<DataItemEntity>();
            if (!string.IsNullOrEmpty(ItemCode))
            {
                expression = expression.And(t => t.ItemCode == ItemCode);
            }
            return base.FindEntity(expression);
        }
        #endregion

        #region 验证数据
        /// <summary>
        /// 分类编号不能重复
        /// </summary>
        /// <param name="itemCode">编号</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistItemCode(string itemCode, string keyValue)
        {
            var expression = LinqExtensions.True<DataItemEntity>();
            expression = expression.And(t => t.ItemCode == itemCode);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.ItemId != keyValue);
            }
            return base.Queryable(expression).Count() == 0 ? true : false;
        }
        /// <summary>
        /// 分类名称不能重复
        /// </summary>
        /// <param name="itemName">名称</param>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        public bool ExistItemName(string itemName, string keyValue)
        {
            var expression = LinqExtensions.True<DataItemEntity>();
            expression = expression.And(t => t.ItemName == itemName);
            if (!string.IsNullOrEmpty(keyValue))
            {
                expression = expression.And(t => t.ItemId != keyValue);
            }
            return base.Queryable(expression).Count() == 0 ? true : false;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            base.Delete(keyValue);
        }
        /// <summary>
        /// 保存分类表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="dataItemEntity">分类实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, DataItemEntity dataItemEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                dataItemEntity.Modify(keyValue);
                base.Update(dataItemEntity);
            }
            else
            {
                dataItemEntity.Create();
                base.Insert(dataItemEntity);
            }
        }
        #endregion
    }
}
