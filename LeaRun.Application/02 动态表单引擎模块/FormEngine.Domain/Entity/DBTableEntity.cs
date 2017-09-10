using System;
using LeaRun.WebBase;

namespace LeaRun.SystemManage.Entity
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2017-2020 Ф����
    /// �� ����admin
    /// �� �ڣ�2017-03-12 07:58
    /// �� �������ݿ��
    /// </summary>
    public class DBTableEntity : LeaRun.Data.BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// Table_Id
        /// </summary>
        /// <returns></returns>
        public string Table_Id { get; set; }
        /// <summary>
        /// ���ݿ���
        /// </summary>
        /// <returns></returns>
        public string Table_DBName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Table_Name { get; set; }
        /// <summary>
        /// ��˵��
        /// </summary>
        /// <returns></returns>
        public string Table_DisplayName { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        /// <returns></returns>
        public string Table_Desc { get; set; }
        /// <summary>
        /// ��������ģ��
        /// </summary>
        /// <returns></returns>
        public string Table_ModuleName { get; set; }
        /// <summary>
        /// ʵ��ģ�͵������ռ�
        /// </summary>
        /// <returns></returns>
        public string Table_NameSpace { get; set; }
        /// <summary>
        /// Ĭ��ʵ�������
        /// </summary>
        /// <returns></returns>
        public string Table_EntityClass { get; set; }
        /// <summary>
        /// ɾ����־
        /// </summary>
        /// <returns></returns>
        public int? Table_DeleteFlag { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// �����û�����
        /// </summary>
        /// <returns></returns>
        public string CreateUserId { get; set; }
        /// <summary>
        /// �����û�
        /// </summary>
        /// <returns></returns>
        public string CreateUserName { get; set; }
        /// <summary>
        /// �޸�����
        /// </summary>
        /// <returns></returns>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// �޸��û�����
        /// </summary>
        /// <returns></returns>
        public string ModifyUserId { get; set; }
        /// <summary>
        /// �޸��û�
        /// </summary>
        /// <returns></returns>
        public string ModifyUserName { get; set; }
        #endregion

        #region ��չ����
        /// <summary>
        /// ��������
        /// </summary>
        public override void Create()
        {
            this.Table_Id = Guid.NewGuid().ToString();
            this.CreateDate = DateTime.Now;
            this.CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.CreateUserName = OperatorProvider.Provider.Current().UserName;
        }
        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="keyValue"></param>
        public override void Modify(string keyValue)
        {
            this.Table_Id = keyValue;
            this.ModifyDate = DateTime.Now;
            this.ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}