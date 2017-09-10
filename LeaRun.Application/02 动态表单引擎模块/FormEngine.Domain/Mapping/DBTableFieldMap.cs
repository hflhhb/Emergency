using LeaRun.SystemManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.SystemManage.Mapping
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2017-2020 Ф����
    /// �� ����admin
    /// �� �ڣ�2017-03-12 07:58
    /// �� �������ݿ���ֶ�
    /// </summary>
    public class DBTableFieldMap : EntityTypeConfiguration<DBTableFieldEntity>
    {
        public DBTableFieldMap()
        {
            #region ������
            //��
            this.ToTable("Base_DBTableField");
            //����
            this.HasKey(t => t.Field_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
