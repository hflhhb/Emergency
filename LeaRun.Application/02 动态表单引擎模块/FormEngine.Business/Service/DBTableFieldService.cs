using System;
using System.Collections.Generic;
using System.Linq;
using LeaRun.Data;
using LeaRun.SystemManage.Entity;
using LeaRun.SystemManage.IService;

namespace LeaRun.SystemManage.Service
{
    /// <summary>
    /// �� �� 1.5
    /// Copyright (c) 2017-2020 Ф����
    /// �� ����admin
    /// �� �ڣ�2017-03-12 07:58
    /// �� �������ݿ���ֶ�DAO
    /// </summary>
    public class DBTableFieldService : Dao<DBTableFieldEntity>, IDBTableFieldService
    {
        /// <summary>
        /// �������ַ��������Ĺ��캯��
        /// </summary>
        /// <param name="dbcontext"></param>
        public DBTableFieldService(DbContextBase dbcontext) : base(dbcontext){ }

        #region ��ȡ����
        /// <summary>
        /// ��ȡ�б�
        /// </summary>
        /// <param name="queryJson">��ѯ����</param>
        /// <returns>�����б�</returns>
        public IEnumerable<DBTableFieldEntity> GetList(string queryJson)
        {
            return base.Queryable().ToList();
        }
        /// <summary>
        /// ��ȡʵ��
        /// </summary>
        /// <param name="keyValue">����ֵ</param>
        /// <returns></returns>
        public DBTableFieldEntity GetEntity(string keyValue)
        {
            return base.FindEntity(keyValue);
        }

        /// <summary>
        /// �������ݿ����ͱ�����ȡ��ʵ��
        /// </summary>
        /// <param name="dbName">���ݿ���</param>
        /// <param name="tableName">����</param>
        /// <param name="fieldName">�ֶ���</param>
        /// <returns></returns>
        public DBTableFieldEntity GetDBTableField(string dbName,string tableName, string fieldName)
        {
            return base.FindEntity(t => t.Field_DBName == dbName && t.Field_TableName== tableName && t.Field_Name == fieldName);
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
        public void SaveForm(string keyValue, DBTableFieldEntity entity)
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
