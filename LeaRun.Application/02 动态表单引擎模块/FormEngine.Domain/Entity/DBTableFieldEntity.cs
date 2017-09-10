using System;
using LeaRun.WebBase;

namespace LeaRun.SystemManage.Entity
{
    /// <summary>
    /// 版 本
    /// Copyright (c) 2017-2020 肖海根
    /// 创 建：admin
    /// 日 期：2017-03-12 07:58
    /// 描 述：数据库表
    /// </summary>
    public class DBTableFieldEntity : LeaRun.Data.BaseEntity
    {
        #region 实体成员
        /// <summary>
        /// 字段ID
        /// </summary>
        /// <returns></returns>
        public string Field_Id { get; set; }
        /// <summary>
        /// 数据库名
        /// </summary>
        /// <returns></returns>
        public string Field_DBName { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        /// <returns></returns>
        public string Field_TableName { get; set; }
        /// <summary>
        /// 字段名
        /// </summary>
        /// <returns></returns>
        public string Field_Name { get; set; }
        /// <summary>
        /// 字段说明
        /// </summary>
        /// <returns></returns>
        public string Field_Desc { get; set; }
        /// <summary>
        /// 是否自增长列
        /// </summary>
        /// <returns></returns>
        public int Field_IsIdentity { get; set; }

        /// <summary>
        /// 是否主键
        /// </summary>
        /// <returns></returns>
        public int Field_IsPK { get; set; }

        /// <summary>
        /// 是否允许NULL
        /// </summary>
        /// <returns></returns>
        public int Field_IsNullable { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        /// <returns></returns>
        public string Field_Type { get; set; }

        /// <summary>
        /// 字段长度
        /// </summary>
        /// <returns></returns>
        public int Field_Length { get; set; }

        /// <summary>
        /// 数据精度
        /// </summary>
        /// <returns></returns>
        public int Field_Precision { get; set; }

        /// <summary>
        /// 小数位数
        /// </summary>
        /// <returns></returns>
        public int Field_Scale { get; set; }
        /// <summary>
        /// 缺省值
        /// </summary>
        /// <returns></returns>
        public string Field_DefaultValue { get; set; }
         
        /// <summary>
        /// 列顺序
        /// </summary>
        /// <returns></returns>
        public int Field_ColOrder { get; set; }
         
        /// <summary>
        /// 数据源类型
        /// </summary>
        /// <returns></returns>
        public string Field_DataSourceType { get; set; }

        /// <summary>
        /// 枚举类型
        /// </summary>
        /// <returns></returns>
        public string Field_EnumType { get; set; }

        /// <summary>
        /// 选择值列表
        /// </summary>
        /// <returns></returns>
        public string Field_SelectValues { get; set; }

        /// <summary>
        /// 字典表父级对象GUID
        /// </summary>
        /// <returns></returns>
        public string Field_DictParentGUID { get; set; }

        /// <summary>
        /// 字典表值字段名
        /// </summary>
        /// <returns></returns>
        public string Field_DictValueField { get; set; }

        /// <summary>
        /// 数据表对应的过滤字段名1
        /// </summary>
        /// <returns></returns>
        public string Field_DictForeignField1 { get; set; }

        /// <summary>
        /// 字典表中过滤字段名1
        /// </summary>
        /// <returns></returns>
        public string Field_DictFilterField1 { get; set; }

        /// <summary>
        /// 数据表对应的过滤字段名2
        /// </summary>
        /// <returns></returns>
        public string Field_DictForeignField2 { get; set; }

        /// <summary>
        /// 字典表中过滤字段名2
        /// </summary>
        /// <returns></returns>
        public string Field_DictFilterField2 { get; set; }

        /// <summary>
        /// 主键表数据库名
        /// </summary>
        /// <returns></returns>
        public string Field_PrimaryDBName { get; set; }

        /// <summary>
        /// 主键物理表名
        /// </summary>
        /// <returns></returns>
        public string Field_PrimaryTable { get; set; }
        /// <summary>
        /// 下拉数据源SQL
        /// </summary>
        /// <returns></returns>
        public string Field_DataSourceSQL { get; set; }
        /// <summary>
        /// 默认的主键字段名
        /// </summary>
        /// <returns></returns>
        public string Field_PrimaryField { get; set; }

        /// <summary>
        /// 数据表辅助外键字段名1
        /// </summary>
        /// <returns></returns>
        public string Field_ForeignField1 { get; set; }

        /// <summary>
        /// 主键表辅助过滤字段1
        /// </summary>
        /// <returns></returns>
        public string Field_PrimaryField1 { get; set; }

        /// <summary>
        /// 数据表辅助外键字段名2
        /// </summary>
        /// <returns></returns>
        public string Field_ForeignField2 { get; set; }

        /// <summary>
        /// 主键表辅助过滤字段2
        /// </summary>
        /// <returns></returns>
        public string Field_PrimaryField2 { get; set; }

        /// <summary>
        /// 数据表辅助外键字段名3
        /// </summary>
        /// <returns></returns>
        public string Field_ForeignField3 { get; set; }

        /// <summary>
        /// 主键表辅助过滤字段3
        /// </summary>
        /// <returns></returns>
        public string Field_PrimaryField3 { get; set; }

        /// <summary>
        /// 数据表辅助外键字段名4
        /// </summary>
        /// <returns></returns>
        public string Field_ForeignField4 { get; set; }


        /// <summary>
        /// 主键表辅助过滤字段4
        /// </summary>
        /// <returns></returns>
        public string Field_PrimaryField4 { get; set; }
         
        /// <summary>
        /// 删除标志
        /// </summary>
        /// <returns></returns>
        public int? Field_DeleteFlag { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 创建用户主键
        /// </summary>
        /// <returns></returns>
        public string CreateUserId { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <returns></returns>
        public string CreateUserName { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        /// <returns></returns>
        public DateTime? ModifyDate { get; set; }
        /// <summary>
        /// 修改用户主键
        /// </summary>
        /// <returns></returns>
        public string ModifyUserId { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        public string ModifyUserName { get; set; }
        #endregion

        #region 扩展操作
        /// <summary>
        /// 新增调用
        /// </summary>
        public override void Create()
        {
            this.Field_Id = Guid.NewGuid().ToString();
            this.CreateDate = DateTime.Now;
            this.CreateUserId = OperatorProvider.Provider.Current().UserId;
            this.CreateUserName = OperatorProvider.Provider.Current().UserName;
        }
        /// <summary>
        /// 编辑调用
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