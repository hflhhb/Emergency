using LeaRun.SystemManage.Entity; 
using System.Collections.Generic;

namespace LeaRun.SystemManage.IService
{
    /// <summary>
    /// �� �� 1.5
    /// Copyright (c) 2017-2020 Ф����
    /// �� ����admin
    /// �� �ڣ�2017-03-12 07:00
    /// �� �������ݿ��DAO
    /// </summary>
    public interface IDBTableService
    {
        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        IEnumerable<DBTableEntity> GetList(string queryJson);
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        DBTableEntity GetEntity(string keyValue);

        /// <summary>
        /// �������ݿ����ͱ�����ȡ��ʵ��
        /// </summary>
        /// <param name="dbName">���ݿ���</param>
        /// <param name="tableName">����</param>
        /// <returns></returns>
        DBTableEntity GetDBTable(string dbName, string tableName);
        #endregion

        #region �ύ����
         

        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        void SaveForm(string keyValue, DBTableEntity entity);

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        void RemoveForm(string keyValue);

        #endregion
    }
}
