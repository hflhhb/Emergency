﻿using LeaRun.PublicInfoManage.Entity;
using LeaRun.PublicInfoManage.IService;
using LeaRun.Data;
using LeaRun.Util;
using LeaRun.Util.Extension;
using LeaRun.Util.Web;
using System.Collections.Generic;

namespace LeaRun.PublicInfoManage.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.12.7 16:40
    /// 描 述：电子公告
    /// </summary>
    public class NoticeService : Dao<NewsEntity>, INoticeService
    {
        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public NoticeService(DbContextBase dbcontext) : base(dbcontext){ }

        #region 获取数据
        /// <summary>
        /// 公告列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<NewsEntity> GetPageList(Pagination pagination, string queryJson)
        {
            var expression = LinqExtensions.True<NewsEntity>();
            var queryParam = queryJson.ToJObject();
            if (!queryParam["FullHead"].IsEmpty())
            {
                string FullHead = queryParam["FullHead"].ToString();
                expression = expression.And(t => t.FullHead.Contains(FullHead));
            }
            if (!queryParam["Category"].IsEmpty())
            {
                string Category = queryParam["Category"].ToString();
                expression = expression.And(t => t.Category == Category);
            }
            expression = expression.And(t => t.TypeId == 2);
            return base.FindList(expression, pagination);
        }
        /// <summary>
        /// 公告实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public NewsEntity GetEntity(string keyValue)
        {
            return base.FindEntity(keyValue);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            base.Delete(keyValue);
        }
        /// <summary>
        /// 保存公告表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="newsEntity">公告实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, NewsEntity newsEntity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                newsEntity.Modify(keyValue);
                newsEntity.TypeId = 2;
                base.Update(newsEntity);
            }
            else
            {
                newsEntity.Create();
                newsEntity.TypeId = 2;
                base.Insert(newsEntity);
            }
        }
        #endregion
    }
}
