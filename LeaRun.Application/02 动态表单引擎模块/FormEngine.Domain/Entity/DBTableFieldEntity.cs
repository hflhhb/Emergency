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
    public class DBTableFieldEntity : LeaRun.Data.BaseEntity
    {
        #region ʵ���Ա
        /// <summary>
        /// �ֶ�ID
        /// </summary>
        /// <returns></returns>
        public string Field_Id { get; set; }
        /// <summary>
        /// ���ݿ���
        /// </summary>
        /// <returns></returns>
        public string Field_DBName { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        public string Field_TableName { get; set; }
        /// <summary>
        /// �ֶ���
        /// </summary>
        /// <returns></returns>
        public string Field_Name { get; set; }
        /// <summary>
        /// �ֶ�˵��
        /// </summary>
        /// <returns></returns>
        public string Field_Desc { get; set; }
        /// <summary>
        /// �Ƿ���������
        /// </summary>
        /// <returns></returns>
        public int Field_IsIdentity { get; set; }

        /// <summary>
        /// �Ƿ�����
        /// </summary>
        /// <returns></returns>
        public int Field_IsPK { get; set; }

        /// <summary>
        /// �Ƿ�����NULL
        /// </summary>
        /// <returns></returns>
        public int Field_IsNullable { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public string Field_Type { get; set; }

        /// <summary>
        /// �ֶγ���
        /// </summary>
        /// <returns></returns>
        public int Field_Length { get; set; }

        /// <summary>
        /// ���ݾ���
        /// </summary>
        /// <returns></returns>
        public int Field_Precision { get; set; }

        /// <summary>
        /// С��λ��
        /// </summary>
        /// <returns></returns>
        public int Field_Scale { get; set; }
        /// <summary>
        /// ȱʡֵ
        /// </summary>
        /// <returns></returns>
        public string Field_DefaultValue { get; set; }
         
        /// <summary>
        /// ��˳��
        /// </summary>
        /// <returns></returns>
        public int Field_ColOrder { get; set; }
         
        /// <summary>
        /// ����Դ����
        /// </summary>
        /// <returns></returns>
        public string Field_DataSourceType { get; set; }

        /// <summary>
        /// ö������
        /// </summary>
        /// <returns></returns>
        public string Field_EnumType { get; set; }

        /// <summary>
        /// ѡ��ֵ�б�
        /// </summary>
        /// <returns></returns>
        public string Field_SelectValues { get; set; }

        /// <summary>
        /// �ֵ��������GUID
        /// </summary>
        /// <returns></returns>
        public string Field_DictParentGUID { get; set; }

        /// <summary>
        /// �ֵ��ֵ�ֶ���
        /// </summary>
        /// <returns></returns>
        public string Field_DictValueField { get; set; }

        /// <summary>
        /// ���ݱ��Ӧ�Ĺ����ֶ���1
        /// </summary>
        /// <returns></returns>
        public string Field_DictForeignField1 { get; set; }

        /// <summary>
        /// �ֵ���й����ֶ���1
        /// </summary>
        /// <returns></returns>
        public string Field_DictFilterField1 { get; set; }

        /// <summary>
        /// ���ݱ��Ӧ�Ĺ����ֶ���2
        /// </summary>
        /// <returns></returns>
        public string Field_DictForeignField2 { get; set; }

        /// <summary>
        /// �ֵ���й����ֶ���2
        /// </summary>
        /// <returns></returns>
        public string Field_DictFilterField2 { get; set; }

        /// <summary>
        /// ���������ݿ���
        /// </summary>
        /// <returns></returns>
        public string Field_PrimaryDBName { get; set; }

        /// <summary>
        /// �����������
        /// </summary>
        /// <returns></returns>
        public string Field_PrimaryTable { get; set; }
        /// <summary>
        /// ��������ԴSQL
        /// </summary>
        /// <returns></returns>
        public string Field_DataSourceSQL { get; set; }
        /// <summary>
        /// Ĭ�ϵ������ֶ���
        /// </summary>
        /// <returns></returns>
        public string Field_PrimaryField { get; set; }

        /// <summary>
        /// ���ݱ�������ֶ���1
        /// </summary>
        /// <returns></returns>
        public string Field_ForeignField1 { get; set; }

        /// <summary>
        /// �������������ֶ�1
        /// </summary>
        /// <returns></returns>
        public string Field_PrimaryField1 { get; set; }

        /// <summary>
        /// ���ݱ�������ֶ���2
        /// </summary>
        /// <returns></returns>
        public string Field_ForeignField2 { get; set; }

        /// <summary>
        /// �������������ֶ�2
        /// </summary>
        /// <returns></returns>
        public string Field_PrimaryField2 { get; set; }

        /// <summary>
        /// ���ݱ�������ֶ���3
        /// </summary>
        /// <returns></returns>
        public string Field_ForeignField3 { get; set; }

        /// <summary>
        /// �������������ֶ�3
        /// </summary>
        /// <returns></returns>
        public string Field_PrimaryField3 { get; set; }

        /// <summary>
        /// ���ݱ�������ֶ���4
        /// </summary>
        /// <returns></returns>
        public string Field_ForeignField4 { get; set; }


        /// <summary>
        /// �������������ֶ�4
        /// </summary>
        /// <returns></returns>
        public string Field_PrimaryField4 { get; set; }
         
        /// <summary>
        /// ɾ����־
        /// </summary>
        /// <returns></returns>
        public int? Field_DeleteFlag { get; set; }
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
            this.Field_Id = Guid.NewGuid().ToString();
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
            this.Field_Id = keyValue;
            this.ModifyDate = DateTime.Now;
            this.ModifyUserId = OperatorProvider.Provider.Current().UserId;
            this.ModifyUserName = OperatorProvider.Provider.Current().UserName;
        }
        #endregion
    }
}