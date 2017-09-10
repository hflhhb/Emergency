using LeaRun.CustomerManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.CustomerManage.Mapping
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2016-2020 �Ϻ���������Ƽ����޹�˾
    /// �� ����westinfeng
    /// �� �ڣ�2016-03-14 09:47
    /// �� �����ͻ���Ϣ
    /// </summary>
    public class CustomerMap : EntityTypeConfiguration<CustomerEntity>
    {
        public CustomerMap()
        {
            #region ������
            //��
            this.ToTable("Client_Customer");
            //����
            this.HasKey(t => t.CustomerId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
