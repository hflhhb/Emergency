using LeaRun.SystemManage.Entity;
using LeaRun.SystemManage.IService;
using LeaRun.Data;
using LeaRun.Util.Web;
using System.Collections.Generic;
using System.Linq;

namespace LeaRun.SystemManage.Service
{
    /// <summary>
    /// �� �� 1.5
    /// Copyright (c) 2017-2020 Ф����
    /// �� ����admin
    /// �� �ڣ�2017-03-12 07:58
    /// �� �������ݿ��DAO
    /// </summary>
    public class DBTableService : Dao<DBTableEntity>, IDBTableService
    {
        /// <summary>
        /// �������ַ��������Ĺ��캯��
        /// </summary>
        /// <param name="dbcontext"></param>
        public DBTableService(DbContextBase dbcontext) : base(dbcontext){ }

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<DBTableEntity> GetList(string queryJson)
        {
            return base.Queryable().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public DBTableEntity GetEntity(string keyValue)
        {
            return base.FindEntity(keyValue);
        }

        /// <summary>
        /// �������ݿ����ͱ�����ȡ��ʵ��
        /// </summary>
        /// <param name="dbName">���ݿ���</param>
        /// <param name="tableName">����</param>
        /// <returns></returns>
        public DBTableEntity GetDBTable(string dbName,string tableName)
        {
            return base.FindEntity(t => t.Table_DBName == dbName && t.Table_Name== tableName);
        }
        #endregion

        #region �ύ����
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="keyValue">����</param>
        public void RemoveForm(string keyValue)
        {
            base.Delete(keyValue);
        }
        /// <summary>
        /// ��������������޸ģ�
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <param name="entity">ʵ�����</param>
        /// <returns></returns>
        public void SaveForm(string keyValue, DBTableEntity entity)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                entity.Modify(keyValue);
                base.Update(entity);
            }
            else
            {
                entity.Create();
                base.Insert(entity);
            }
        }
        #endregion
    }
}
