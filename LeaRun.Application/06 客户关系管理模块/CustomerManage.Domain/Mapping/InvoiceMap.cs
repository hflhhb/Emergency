using LeaRun.CustomerManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.CustomerManage.Mapping
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2016-2020 �Ϻ���������Ƽ����޹�˾
    /// �� ������������Ա
    /// �� �ڣ�2016-04-01 14:33
    /// �� ������Ʊ��Ϣ
    /// </summary>
    public class InvoiceMap : EntityTypeConfiguration<InvoiceEntity>
    {
        public InvoiceMap()
        {
            #region ������
            //��
            this.ToTable("Client_Invoice");
            //����
            this.HasKey(t => t.InvoiceId);
            #endregion

            #region ���ù�ϵ
            #endregion
        }
    }
}
