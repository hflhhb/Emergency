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
    /// �� ������������Ա
    /// �� �ڣ�2016-04-01 14:33
    /// �� ������Ʊ��Ϣ
    /// </summary>
    public class InvoiceBLL
    {
        private IInvoiceService service = new InvoiceService(LeaRun.Data.DbFactory.CRM());

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="pagination">��ҳ</param>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>���ط�ҳ�б�</returns>
        public IEnumerable<InvoiceEntity> GetPageList(Pagination pagination, string queryJson)
        {
            return service.GetPageList(pagination, queryJson);
        }
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<InvoiceEntity> GetList(string queryJson)
        {
            return service.GetList(queryJson);
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public InvoiceEntity GetEntity(string keyValue)
        {
            return service.GetEntity(keyValue);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
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
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, InvoiceEntity entity)
        {
            try
            {
                service.SaveForm(keyValue, entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
