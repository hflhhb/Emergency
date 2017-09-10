using LeaRun.CustomerManage.Entity;
using LeaRun.CustomerManage.IService;
using LeaRun.Data;
using LeaRun.Util.Extension;
using LeaRun.Util.Web;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.CustomerManage.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创 建：westinfeng
    /// 日 期：2016-03-21 16:10
    /// 描 述：跟进记录
    /// </summary>
    public class TrailRecordService : Dao<TrailRecordEntity>, ITrailRecordService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public TrailRecordService(DbContextBase dbcontext) : base(dbcontext){ }

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="objectId">对象Id</param>
        /// <returns>返回列表</returns>
        public IEnumerable<TrailRecordEntity> GetList(string objectId)
        {
            return base.Queryable(t => t.ObjectId.Equals(objectId)).OrderByDescending(t => t.CreateDate).ToList();
        }
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public TrailRecordEntity GetEntity(string keyValue)
        {
            return base.FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            base.Delete(keyValue);
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, TrailRecordEntity entity)
        {
            db.BeginTrans();
            try
            {
                switch (entity.ObjectSort)
                {
                    case 1:         //商机
                        ChanceEntity chanceEntity = new ChanceEntity();
                        chanceEntity.Modify(entity.ObjectId);
                        db.Update<ChanceEntity>(chanceEntity);
                        break;
                    case 2:         //客户
                        CustomerEntity customerEntity = new CustomerEntity();
                        customerEntity.Modify(entity.ObjectId);
                        db.Update<CustomerEntity>(customerEntity);
                        break;
                    default:
                        break;
                }
                entity.Create();
                db.Insert(entity);

                db.Commit();
            }
            catch (Exception)
            {
                db.Rollback();
                throw;
            }
        }
        #endregion
    }
}