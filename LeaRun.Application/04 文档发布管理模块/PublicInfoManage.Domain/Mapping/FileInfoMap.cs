using LeaRun.PublicInfoManage.Entity;
using System.Data.Entity.ModelConfiguration;

namespace LeaRun.PublicInfoManage.Mapping
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.12.15 10:56
    /// 描 述：文件
    /// </summary>
    public class FileInfoMap : EntityTypeConfiguration<FileInfoEntity>
    {
        public FileInfoMap()
        {
            #region 表、主键
            //表
            this.ToTable("Base_FileInfo");
            //主键
            this.HasKey(t => t.FileId);
            #endregion

            #region 配置关系
            #endregion
        }
    }
}
