using LeaRun.MessageManage.Entity;
using System.Collections.Generic;

namespace LeaRun.MessageManage.IService
{
    /// <summary>
    /// 版 本 V6.1
    /// Copyright (c) 2016-2020 上海赞心数码科技有限公司
    /// 创建人：肖海根
    /// 日 期：2016.11.26 11:14
    /// 描 述：即时通信用户管理
    /// </summary>
    public interface IMsgUserService
    {
        /// <summary>
        /// 获取联系人列表（即时通信）
        /// </summary>
        /// <returns></returns>
        IEnumerable<IMUserModel> GetList(string OrganizeId);
    }
}
