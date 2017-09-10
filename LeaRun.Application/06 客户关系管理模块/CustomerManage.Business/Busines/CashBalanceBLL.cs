using LeaRun.CustomerManage.Entity;
using LeaRun.CustomerManage.IService;
using LeaRun.CustomerManage.Service;
using LeaRun.Util.Web;
using System.Collections.Generic;
using System;

namespace LeaRun.CustomerManage.Business
{
    /// <summary>
    /// �� �� 1.5
    /// Copyright (c) 2016-2020 �Ϻ���������Ƽ����޹�˾
    /// �� ����westinfeng
    /// �� �ڣ�2016-04-28 16:48
    /// �� �����ֽ����
    /// </summary>
    public class CashBalanceBLL
    {
        private ICashBalanceService service = new CashBalanceService(LeaRun.Data.DbFactory.CRM());

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<CashBalanceEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        #endregion

        #region �ύ����
        #endregion
    }
}
