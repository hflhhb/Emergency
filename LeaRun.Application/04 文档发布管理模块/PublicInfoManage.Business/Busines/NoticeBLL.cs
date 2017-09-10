﻿using LeaRun.PublicInfoManage.Entity;
using LeaRun.PublicInfoManage.IService;
using LeaRun.PublicInfoManage.Service;
using LeaRun.Util;
using LeaRun.Util.Web;
using System;
using System.Collections.Generic;

namespace LeaRun.PublicInfoManage.Business
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创建人：肖海根
    /// 日 期：2016.12.7 16:40
    /// 描 述：电子公告
    /// </summary>
    public class NoticeBLL
    {
        private INoticeService service = new NoticeService(LeaRun.Data.DbFactory.OA());

        #region 获取数据
        /// <summary>
        /// 公告列表
        /// </summary>
        /// <param name="pagination">分页</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns></returns>
        public IEnumerable<NewsEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// 公告实体
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        public NewsEntity GetEntity(string keyValue)
        {
            NewsEntity newsEntity = service.GetEntity(keyValue);
            newsEntity.NewsContent = WebHelper.HtmlDecode(newsEntity.NewsContent);
            return newsEntity;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="keyValue">主键</param>
        public void RemoveForm(string keyValue)
        {
            try
            {
                service.RemoveForm(keyValue);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 保存公告表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="newsEntity">公告实体</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, NewsEntity newsEntity)
        {
            try
            {
                newsEntity.NewsContent = WebHelper.HtmlEncode(newsEntity.NewsContent);
                service.SaveForm(keyValue, newsEntity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
