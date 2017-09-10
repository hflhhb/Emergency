using LeaRun.SystemManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.SystemManage.Mapping
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2017-2020 Ф����
    /// �� ����admin
    /// �� �ڣ�2017-03-12 07:58
    /// �� �������ݿ��
    /// </summary>
    public class DBTableMap : EntityTypeConfiguration<DBTableEntity>
    {
        public DBTableMap()
        {
            #region ������
            //��
            this.ToTable("Base_DBTable");
            //����
            this.HasKey(t => t.Table_Id);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
