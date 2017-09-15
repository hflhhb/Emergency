using LeaRun.ResourceManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.ResourceManage.Mapping
{
    /// <summary>
    /// �� ��
    /// Copyright (c) 2017-2020 Ф����
    /// �� ����HFL
    /// �� �ڣ�2017-09-13 00:46
    /// �� ����Camera
    /// </summary>
    public class CameraMap : EntityTypeConfiguration<CameraEntity>
    {
        public CameraMap()
        {
            #region ������
            //��
            this.ToTable("RC_Camera");
            //����
            this.HasKey(t => t.Id);
            #endregion

            #region ���ù�ϵ
            this.Property(o => o.Longitude).IsRequired().HasPrecision(19, 16);
            this.Property(o => o.Latitude).IsRequired().HasPrecision(19, 16);
            #endregion
        }
    }
}
