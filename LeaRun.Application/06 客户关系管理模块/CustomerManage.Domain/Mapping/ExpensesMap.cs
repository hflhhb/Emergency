using LeaRun.CustomerManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.CustomerManage.Mapping
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2016-2020 �Ϻ���������Ƽ����޹�˾
    /// �� ����westinfeng
    /// �� �ڣ�2016-04-20 11:23
    /// �� ��������֧��
    /// </summary>
    public class ExpensesMap : EntityTypeConfiguration<ExpensesEntity>
    {
        public ExpensesMap()
        {
            #region ������
            //��
            this.ToTable("Client_Expenses");
            //����
            this.HasKey(t => t.ExpensesId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
