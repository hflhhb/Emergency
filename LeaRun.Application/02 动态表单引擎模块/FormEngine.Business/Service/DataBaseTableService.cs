using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text; 
using LeaRun.Data; 
using LeaRun.WebBase;
using LeaRun.SystemManage.Entity;
using LeaRun.SystemManage.IService;
using LeaRun.Util;
using LeaRun.Util.Web;

namespace LeaRun.SystemManage.Service
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.11.18 11:02
    /// 描 述：数据库管理（支持：SqlServer）
    /// </summary>
    public class DataBaseTableService : Dao<DataBaseLinkEntity>, IDataBaseTableService
    {
        private IDataBaseLinkService dataBaseLinkService =null;
        private string Platform_DBName = "LeaRunFramework_Base_2016";


        /// <summary>
        /// 带连接字符串参数的构造函数
        /// </summary>
        /// <param name="dbcontext"></param>
        public DataBaseTableService(DbContextBase dbcontext) : base(dbcontext)
        {
            dataBaseLinkService = new DataBaseLinkService(dbcontext);
        }

        #region 获取数据
        /// <summary>
        /// 得到同一服务器上的数据库列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>  
        /// <returns></returns>
        public IEnumerable<DatabaseEntity> GetDBNameList(string dataBaseLinkId)
        {
            List<DatabaseEntity> dbList = new List<DatabaseEntity>();

            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            if (dataBaseLinkEntity != null)
            {
                string sqlDB = @" Select name as DBName from master..sysdatabases 
                    where name not in('master','model','msdb','tempdb','northwind','pubs') ";
                System.Data.DataTable dtDB= new DaoFactory(DbFactory.GetDBByName(dataBaseLinkEntity.DbConnection, DatabaseType.SqlServer)).db.FindTable(sqlDB.ToString());
                foreach (System.Data.DataRow dr in dtDB.Rows)
                {
                    DatabaseEntity dbEntity = new DatabaseEntity();
                    dbEntity.Name = StringUtil.cEmpty(dr["DBName"]);
                    dbEntity.Description = StringUtil.cEmpty(dr["DBName"]);
                    dbList.Add(dbEntity);
                }

                return dbList;
            }
            else
            {
                throw new ApplicationException("数据库连接参数无效:" + dataBaseLinkId);
            }
        }

        /// <summary>
        /// 数据表列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="dbName">数据库名</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public IEnumerable<DatabaseTableEntity> GetTableInfoList(string dataBaseLinkId, string dbName,string tableName)
        {
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            if (dataBaseLinkEntity != null)
            {
                //根据物理数据表,插入或删除Base_DBTable 数据模型--表信息表
                this.SyncDataTable(dataBaseLinkId, this.Platform_DBName, dataBaseLinkEntity.DBName); 

                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("USE {0}; ", dbName).AppendLine();
                strSql.Append(@"DECLARE @TableInfo TABLE 
                                ( name VARCHAR(50) , sumrows VARCHAR(11) , reserved VARCHAR(50) , data VARCHAR(50) , index_size VARCHAR(50) , unused VARCHAR(50) , pk VARCHAR(50) )
                                DECLARE @TableName TABLE ( name VARCHAR(50) )
                                DECLARE @name VARCHAR(50)
                                DECLARE @pk VARCHAR(50)
                                INSERT INTO @TableName ( name ) 
                                SELECT o.name FROM sysobjects o , sysindexes i WHERE o.id = i.id AND o.xtype = 'U' AND i.indid < 2 ORDER BY i.rows DESC , o.name
                                WHILE EXISTS ( SELECT 1 FROM @TableName ) BEGIN SELECT TOP 1 @name = name FROM @TableName DELETE @TableName WHERE name = @name DECLARE @objectid INT SET @objectid = OBJECT_ID(@name) SELECT @pk = COL_NAME(@objectid, colid) FROM sysobjects AS o INNER JOIN sysindexes AS i ON i.name = o.name INNER JOIN sysindexkeys AS k ON k.indid = i.indid WHERE o.xtype = 'PK' AND parent_obj = @objectid AND k.id = @objectid INSERT INTO @TableInfo ( name , sumrows , reserved , data , index_size , unused ) EXEC sys.sp_spaceused @name UPDATE @TableInfo SET pk = @pk WHERE name = @name END
                                SELECT F.name , F.reserved , F.data , F.index_size , RTRIM(F.sumrows) AS sumrows , F.unused ,

                                ISNULL(P.tdescription, F.name) AS tdescription , F.pk
                                FROM @TableInfo F LEFT JOIN ( SELECT name = CASE WHEN A.colorder = 1 THEN D.name ELSE '' END , tdescription = CASE WHEN A.colorder = 1 THEN ISNULL(F.value, '') ELSE '' END
                                FROM syscolumns A LEFT JOIN systypes B ON A.xusertype = B.xusertype INNER JOIN 
                                sysobjects D ON A.id = D.id AND D.xtype = 'U' AND D.name <> 'DTPROPERTIES' 
                                LEFT JOIN sys.extended_properties F ON D.id = F.major_id WHERE A.colorder = 1 AND F.minor_id = 0 ) P ON F.name = P.name
                                WHERE 1 = 1");
                
                if (!string.IsNullOrEmpty(tableName))
                {
                    strSql.Append(" AND F.name='" + tableName + "'");
                }
                strSql.Append(" ORDER BY F.name");
                return new DaoFactory(DbFactory.GetDBByName(dataBaseLinkEntity.DbConnection, DatabaseType.SqlServer)).db.FindList<DatabaseTableEntity>(strSql.ToString());
            }
            return null;
        }

        
        /// <summary>
        /// 数据表字段列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public IEnumerable<DatabaseFieldEntity> GetTableFiledList(string dataBaseLinkId, string tableName)
        {
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            if (dataBaseLinkEntity != null)
            {
                //根据物理数据表,插入或删除Base_DBTable 数据模型--表信息表
                this.SyncFieldConfigByTableName(this.Platform_DBName , dataBaseLinkEntity.DBName, tableName);

                StringBuilder strSql = new StringBuilder();
                strSql.AppendFormat("USE {0}; ", dataBaseLinkEntity.DBName).AppendLine();
                strSql.Append(@"SELECT [number] = a.colorder , [column] = a.name , [datatype] = b.name , [length] = COLUMNPROPERTY(a.id, a.name, 'PRECISION') , [identity] = CASE WHEN COLUMNPROPERTY(a.id, a.name, 'IsIdentity') = 1 THEN '1' ELSE '' END , [key] = CASE WHEN EXISTS ( SELECT 1 FROM sysobjects WHERE xtype = 'PK' AND parent_obj = a.id AND name IN ( SELECT name FROM sysindexes WHERE indid IN ( SELECT indid FROM sysindexkeys WHERE id = a.id AND colid = a.colid ) ) ) THEN '1' ELSE '' END , [isnullable] = CASE WHEN a.isnullable = 1 THEN '1' ELSE '' END , [defaults] = ISNULL(e.text, '') , [remark] = ISNULL(g.[value], a.name)
                                FROM syscolumns a LEFT JOIN systypes b ON a.xusertype = b.xusertype INNER JOIN sysobjects d ON a.id = d.id AND d.xtype = 'U' AND d.name <> 'dtproperties' LEFT JOIN syscomments e ON a.cdefault = e.id LEFT JOIN sys.extended_properties g ON a.id = g.major_id AND a.colid = g.minor_id LEFT JOIN sys.extended_properties f ON d.id = f.major_id AND f.minor_id = 0
                                WHERE d.name = @tableName
                                ORDER BY a.id , a.colorder");
                DbParameter[] parameter = 
                {
                    DbParameters.CreateDbParameter("@tableName",tableName)
                };
                return base.db.FindList<DatabaseFieldEntity>(strSql.ToString(), parameter);
            }
            return null;
        }
        /// <summary>
        /// 数据库表数据列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接</param>
        /// <param name="tableName">表名</param>
        /// <param name="switchWhere">条件</param>
        /// <param name="logic">逻辑</param>
        /// <param name="keyword">关键字</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public DataTable GetTableDataList(string dataBaseLinkId, string tableName, string switchWhere, string logic, string keyword, Pagination pagination)
        {
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            if (dataBaseLinkEntity != null)
            {
                StringBuilder strSql = new StringBuilder();
                List<DbParameter> parameter = new List<DbParameter>();
                strSql.Append("SELECT * FROM " + tableName + " WHERE 1=1");
                if (!string.IsNullOrEmpty(keyword))
                {
                    strSql.Append(" AND " + switchWhere + "");
                    switch (logic)
                    {
                        case "Equal":           //等于
                            strSql.Append(" = ");
                            parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere, keyword));
                            break;
                        case "NotEqual":        //不等于
                            strSql.Append(" <> ");
                            parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere, keyword));
                            break;
                        case "Greater":         //大于
                            strSql.Append(" > ");
                            parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere, keyword));
                            break;
                        case "GreaterThan":     //大于等于
                            strSql.Append(" >= ");
                            parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere, keyword));
                            break;
                        case "Less":            //小于
                            strSql.Append(" < ");
                            parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere, keyword));
                            break;
                        case "LessThan":        //小于等于
                            strSql.Append(" >= ");
                            parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere, keyword));
                            break;
                        case "Null":            //为空
                            strSql.Append(" is null ");
                            parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere, keyword));
                            break;
                        case "NotNull":         //不为空
                            strSql.Append(" is not null ");
                            parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere, keyword));
                            break;
                        case "Like":            //包含
                            strSql.Append(" like ");
                            parameter.Add(DbParameters.CreateDbParameter("@" + switchWhere, '%' + keyword + '%'));
                            break;
                        default:
                            break;
                    }
                    strSql.Append("@" + switchWhere + "");
                }
                return  new DaoFactory(DbFactory.GetDBByName(dataBaseLinkEntity.DbConnection, DatabaseType.SqlServer)).Dao<DatabaseFieldEntity>().FindTable(strSql.ToString(), parameter.ToArray(), pagination);
            }
            return null;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 修改物理表说明
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param>
        /// <param name="tableDisplayName">表说明</param>
        /// <returns></returns>
        public void ModifyTableDesc(string dataBaseLinkId, string tableName, string tableDisplayName)
        {
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            //先删除表描述
            string strSQL = String.Format(" USE [{0}];    EXEC sys.sp_dropextendedproperty   @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'{1}', @level2type=NULL,@level2name=NULL ;"
                    , dataBaseLinkEntity.DBName, tableName);
            try
            {
                base.db.ExecuteNonQuery(strSQL);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //添加表描述
            strSQL = "  USE [" + dataBaseLinkEntity.DBName.Trim() + "];  EXECUTE sp_addextendedproperty 'MS_Description',  '" + tableDisplayName + "', 'user', 'dbo', 'table', '" + tableName + "' ;  ";
            base.db.ExecuteNonQuery(strSQL);
        }

        /// <summary>
        /// 得到修改物理字段说明的SQL
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldDescription">字段描述</param>
        /// <returns>返回SQL</returns>
        private string  GetModifyFieldDescSQL(string dataBaseLinkId, string tableName,string fieldName, string fieldDescription)
        {
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId); 

            try
            {
                //先删除字段描述
                string strDropSQL = string.Format(" USE [{0}];   EXEC sys.sp_dropextendedproperty   @name=N'MS_Description' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'{1}', @level2type=N'COLUMN',@level2name=N'{2}' ; "
                        , dataBaseLinkEntity.DBName, tableName, fieldName);
                base.db.ExecuteNonQuery(strDropSQL);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
             
            string strSQL = " USE [" + dataBaseLinkEntity.DBName.Trim() + "]; EXECUTE sp_addextendedproperty 'MS_Description', " + "\r\n\t'" + fieldDescription + "',\r\n\t'user', 'dbo', 'table', '" + tableName + "', 'column', '" + fieldName + "'; " ;

            return strSQL;
        }

        /// <summary>
        /// 保存数据库表表单（新增、修改）
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param>
        /// <param name="tableDisplayName">表说明</param>
        /// <param name="fieldList">字段列表</param>
        public void CreateTable(string dataBaseLinkId, string tableName, string tableDisplayName , IEnumerable<DatabaseFieldEntity> fieldList)
        {
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            
            //重新创建表
            StringBuilder sbSQL = new StringBuilder();
            sbSQL.AppendFormat(" USE [" + dataBaseLinkEntity.DBName.Trim() + "] ");
            sbSQL.Append("if exists (select 1");
            sbSQL.Append("            from  sysobjects");
            sbSQL.Append("            where  id = object_id('" + tableName + "')");
            sbSQL.Append("            and   type = 'U')");
            sbSQL.Append("   drop table " + tableName + " ");
            sbSQL.Append("\r\n");


            sbSQL.Append("create table " + tableName + " (");
            foreach (var field in fieldList)
            {
                var column = field.column;
                var datatype = field.datatype;
                if (string.Compare(datatype ,"varchar",true)==0) datatype = datatype + "(" + field.length + ")";
                var isnuallable = field.isnullable == "0" || field.isnullable == "" ? "not null" : "null";
                var primary = field.key == "0" || field.key == "" ? "" : "primary key";
                var identity = field.identity == "0" || field.identity == "" ? "" : "IDENTITY(1,1)";
                var defaultvalue = field.defaults;
                //删除默认值前后的括号
                defaultvalue = defaultvalue.Trim();
                if (defaultvalue.StartsWith("(")) defaultvalue = defaultvalue.Substring(1);
                if (defaultvalue.EndsWith(")")) defaultvalue = defaultvalue.Substring(0, defaultvalue.Length - 1);

                sbSQL.Append(" " + column + " " + datatype + " " + isnuallable + " " + primary + " " + identity + " ");
                  
                if (!string.IsNullOrEmpty(defaultvalue))
                {
                    sbSQL.Append(" default( " + defaultvalue + " )" + " ");
                }
                sbSQL.Append(",\r\n");

            }
            sbSQL.Append(") \r\n");
             
            //添加物理表描述
            string strSQL = "  USE [" + dataBaseLinkEntity.DBName.Trim() + "];  EXECUTE sp_addextendedproperty 'MS_Description',  '" + tableDisplayName + "', 'user', 'dbo', 'table', '" + tableName + "' ;  ";
            sbSQL.Append(strSQL);

            foreach (var field in fieldList)
            {
                var coloumn = field.column;
                var description = field.remark;

                //添加物理字段描述
                strSQL = " USE [" + dataBaseLinkEntity.DBName.Trim() + "]; EXECUTE sp_addextendedproperty 'MS_Description', " + "\r\n\t'" + description + "',\r\n\t'user', 'dbo', 'table', '" + tableName + "', 'column', '" + coloumn + "'; ";
                sbSQL.Append(strSQL);
            }
            base.db.ExecuteNonQuery(sbSQL.ToString());
        }

        /// <summary>
        /// 删除物理表
        /// </summary>
        /// <param name="dataBaseLinkId">数据库链接ID</param>
        /// <param name="tableName">表名</param>
        public void DeleteTable(string dataBaseLinkId, string tableName)
        {
            //先删除表描述
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            string strSql = String.Format(" USE [{0}];  if exists ( select name from sysobjects where name='{1}' and type='U' )   DROP TABLE [{1}] ; "
                    , dataBaseLinkEntity.DBName, tableName);
            base.db.ExecuteNonQuery(strSql.ToString());
        }

        /// <summary>
        /// 新增字段
        /// </summary>
        /// <param name="dataBaseLinkId">数据库链接ID</param>
        /// <param name="tableName">表名</param>
        /// <param name="fieldEntity">物理字段实体</param>
        public bool CreateField(string dataBaseLinkId, string tableName,DatabaseFieldEntity fieldEntity)
        {
             
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);

            StringBuilder sbSQL = new StringBuilder();
            if (fieldEntity != null)
            {
                sbSQL.AppendFormat("USE [{0}]; ALTER TABLE [{1}] ADD [{2}]", dataBaseLinkEntity.DBName, tableName ,fieldEntity.column );
     
                var column = fieldEntity.column;
                var datatype = fieldEntity.datatype;
                if (string.Compare(datatype ,"varchar",true)==0) datatype = datatype + "(" + fieldEntity.length + ")";
                var isnuallable = fieldEntity.isnullable == "0" || fieldEntity.isnullable == "" ? "not null" : "null";
                var primary = fieldEntity.key == "0" || fieldEntity.key == "" ? "" : "primary key";
                var identity = fieldEntity.identity == "0" || fieldEntity.identity == "" ? "" : "IDENTITY(1,1)";
                var defaultvalue = fieldEntity.defaults;
                //删除默认值前后的括号
                defaultvalue = defaultvalue.Trim();
                if (defaultvalue.StartsWith("(")) defaultvalue = defaultvalue.Substring(1);
                if (defaultvalue.EndsWith(")")) defaultvalue = defaultvalue.Substring(0, defaultvalue.Length - 1);

                sbSQL.Append(" " + datatype + " " + isnuallable + " " + primary + " " + identity + " ");
                
                if (!string.IsNullOrEmpty(defaultvalue))
                {
                    sbSQL.Append(" default( " + defaultvalue + " )" + " ");
                }
                sbSQL.AppendLine();

                //得到修改物理字段说明的SQL
                sbSQL.AppendLine(GetModifyFieldDescSQL(dataBaseLinkId, tableName, column, StringUtil.cEmpty(fieldEntity.remark)));

                base.db.ExecuteNonQuery(sbSQL.ToString());
            }

            return true;
        }

        /// <summary>
        /// 调整字段
        /// </summary>
        /// <param name="dataBaseLinkId">数据库链接ID</param>
        /// <param name="tableName">表名</param>
        /// <param name="fieldEntity">物理字段实体</param>
        public bool SaveField(string dataBaseLinkId, string tableName, DatabaseFieldEntity fieldEntity)
        {
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);

            StringBuilder sbSQL = new StringBuilder();
            if (fieldEntity != null)
            {
                sbSQL.AppendFormat("USE [{0}]; ALTER TABLE [{1}] ALTER COLUMN  [{2}]", dataBaseLinkEntity.DBName, tableName, fieldEntity.column);

                var column = fieldEntity.column;
                var datatype = fieldEntity.datatype;
                if (string.Compare(datatype ,"varchar",true)==0) datatype = datatype + "(" + fieldEntity.length + ")";
                var isnuallable = fieldEntity.isnullable == "0" || fieldEntity.isnullable == "" ? "not null" : "null";
                var primary = fieldEntity.key == "0" || fieldEntity.key == "" ? "" : "primary key";
                var identity = fieldEntity.identity == "0" || fieldEntity.identity == "" ? "" : "IDENTITY(1,1)";
                var defaultvalue = fieldEntity.defaults;

                //删除默认值前后的括号
                defaultvalue = defaultvalue.Trim();
                if (defaultvalue.StartsWith("(")) defaultvalue = defaultvalue.Substring(1);
                if (defaultvalue.EndsWith(")")) defaultvalue = defaultvalue.Substring(0,defaultvalue.Length- 1);
                 
                sbSQL.Append(" " + datatype + " " + isnuallable + " " + primary + " " + identity + " ").AppendLine();
                 
                base.db.ExecuteNonQuery(sbSQL.ToString());

                //看是否有默认值约束。
                sbSQL.AppendFormat(@"USE [{0}]; 
                                declare @constraintName varchar(200);   
                                select @constraintName=b.name from syscolumns a,sysobjects b where a.id=object_id('{1}')   
                                and b.id=a.cdefault and a.name='{2}' and b.name like 'DF%'  
                                select @constraintName  ", dataBaseLinkEntity.DBName, tableName, column);
                string str_constraintName = base.db.ExecuteScalar(sbSQL.ToString());
                
                //如果有默认值约束，先删除。
                sbSQL = new StringBuilder();
                if (str_constraintName.Length > 0)
                {
                    sbSQL.AppendFormat("USE [{0}];  ALTER TABLE [{1}] drop constraint  [{2}] ; ", dataBaseLinkEntity.DBName, tableName, str_constraintName).AppendLine();

                    sbSQL.AppendFormat("USE [{0}];  ALTER TABLE [{1}] ADD CONSTRAINT {2} default( {3} ) FOR  [{4}] ; ", dataBaseLinkEntity.DBName, tableName, str_constraintName, defaultvalue, column).AppendLine();
                }else if (defaultvalue.Length>0)
                {
                    str_constraintName = string.Format("DF_{0}_{1}_{2}", dataBaseLinkEntity.DBName, tableName, column);
                    sbSQL.AppendFormat("USE [{0}]; ALTER TABLE  [{1}]  ADD CONSTRAINT {2} default( {3} ) FOR  [{4}] ; ", dataBaseLinkEntity.DBName, tableName, str_constraintName, defaultvalue, column).AppendLine();
                }
                
                //得到修改物理字段说明的SQL
                sbSQL.AppendLine(GetModifyFieldDescSQL(dataBaseLinkId, tableName, column, StringUtil.cEmpty(fieldEntity.remark)));

                base.db.ExecuteScalar(sbSQL.ToString());
            }

            return true;
        }

        /// <summary>
        /// 修改物理字段说明
        /// </summary>
        /// <param name="dataBaseLinkId">数据库链接ID</param>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="fieldDescription">字段说明</param>
        /// <returns></returns>
        public bool ModifyFieldDesc(string dataBaseLinkId, string tableName, string fieldName,string fieldDescription)
        {
            string strSQL =GetModifyFieldDescSQL(dataBaseLinkId, tableName, fieldName, fieldDescription);
            base.db.ExecuteNonQuery(strSQL);
            return true;
        }

        /// <summary>
        /// 调整字段
        /// </summary>
        /// <param name="dataBaseLinkId">数据库链接ID</param>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        public bool DeleteField(string dataBaseLinkId, string tableName, string fieldName)
        {
            //先删除表描述
            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);

            StringBuilder sbSQL = new StringBuilder();

            //看是否有默认值约束。
            sbSQL.AppendFormat(@"USE [{0}]; 
                                declare @constraintName varchar(200);   
                                select @constraintName=b.name from syscolumns a,sysobjects b where a.id=object_id('{1}')   
                                and b.id=a.cdefault and a.name='{2}' and b.name like 'DF%'  
                                select @constraintName  ", dataBaseLinkEntity.DBName, tableName, fieldName).AppendLine();
            string str_constraintName=  base.db.ExecuteScalar(sbSQL.ToString());

            //如果有默认值约束，先删除。
            sbSQL = new StringBuilder();
            if (str_constraintName.Length > 0)
            {
                sbSQL.AppendFormat("USE [{0}];  ALTER TABLE [{1}] drop constraint  [{2}] ; ", dataBaseLinkEntity.DBName, tableName, str_constraintName).AppendLine(); 
            }

            sbSQL.AppendFormat("USE [{0}];  ALTER TABLE [{1}] DROP COLUMN [{2}] ;", dataBaseLinkEntity.DBName, tableName, fieldName ).AppendLine();

            base.db.ExecuteNonQuery(sbSQL.ToString());
            return true;
        }
        #endregion


        /// <summary>
        /// 根据物理数据表,插入或删除Base_DBTable 数据模型--表信息表
        /// </summary>
        /// <param name="dataBaseLinkId">数据库连接ID</param> 
        /// <param name="strPlatform_DBName">平台数据库名</param>
        /// <param name="strDBName">数据库名</param>
        public bool SyncDataTable(string dataBaseLinkId,string strPlatform_DBName, string strDBName)
        {
            //根据数据库表信息，插入Base_DBTable 数据模型--表信息表
            StringBuilder sbUpdate = new StringBuilder(string.Format(@" Insert Into [{0}].dbo.Base_DBTable (Table_Id,Table_DBName,Table_Name, CreateDate ,CreateUserId,CreateUserName, ModifyDate,ModifyUserId,ModifyUserName)
            select newID() as Table_Id, '{1}' as Table_DBName , s.name  as Table_Name  ,GETDATE() as CreateDate,'{2}' as CreateUserId ,'{3}'  as CreateUserName,GETDATE() as ModifyDate,'{2}' as ModifyUserId ,'{3}'  as ModifyUserName
            from [{1}].dbo.sysobjects  s left join [{0}].dbo.Base_DBTable t on (s.[name]=t.[Table_Name] and t.Table_DBName='{1}') where s.xtype='U' 
                and t.Table_DBName is Null ;", strPlatform_DBName, strDBName, OperatorProvider.Provider.Current().UserId, OperatorProvider.Provider.Current().UserName)).AppendLine();
            //不存在的物理表置删除标志。
            sbUpdate.AppendLine(string.Format(@" Update [{0}].dbo.Base_DBTable set Table_DeleteFlag='1'  from [{0}].dbo.Base_DBTable t left join [{1}].dbo.sysobjects  s on (s.[name]=t.[Table_Name] and t.Table_DBName='{1}' and  s.xtype='U'  ) 
                where t.Table_DBName='{1}' and  t.Table_DBName is Not Null  and  s.name is null ; ", strPlatform_DBName, strDBName));

            string sqlUpdate = sbUpdate.ToString();

            DataBaseLinkEntity dataBaseLinkEntity = dataBaseLinkService.GetEntity(dataBaseLinkId);
            base.db.ExecuteNonQuery(sqlUpdate);

            return true;
        }


        /// <summary>
        /// 将数据库的字段信息先补充到DBTableField表
        /// 然后在DBTableField字段信息配置表中，根据表名获得字段信息
        /// </summary> 
        /// <param name="strPlatform_DBName">平台数据库名</param>
        /// <param name="strDBName">数据库名</param>
        /// <param name="strTableName">表名</param>
        /// <returns></returns>
        public bool SyncFieldConfigByTableName(string strPlatform_DBName, string strDBName, string strTableName)
        {

            //------获取表的字段信息
            string sql = string.Empty;
            if (strDBName.Length > 0)
            {
                sql += string.Format(" USE {0} ; \r\n ", strDBName);
            }

            //根据数据库新增字段
            sql += String.Format(@"
                    Insert into [{0}].dbo.[Base_DBTableField] (Field_Id,Field_DBName, Field_TableName,Field_ColOrder,Field_Name ,Field_Desc,Field_IsIdentity,Field_IsPK,Field_Type,Field_Length ,Field_Precision,Field_Scale,Field_IsNullable,Field_DefaultValue , CreateDate ,CreateUserId,CreateUserName, ModifyDate,ModifyUserId,ModifyUserName)
                    SELECT newID() as Field_Id,
                    '{1}' as Field_DBName ,
                    Field_TableName= Convert(varchar(36),d.name) , 
                    Field_ColOrder=a.colorder,
                    Field_Name=a.name , 
                    Field_Desc=Convert(varchar(80) ,isnull(g.[value],'')) ,
                    Field_IsIdentity=(case   when   COLUMNPROPERTY(   a.id,a.name,'IsIdentity')=1   then   '1'else   '0'   end),
                    Field_IsPK=(case   when   exists(SELECT   1   FROM   sysobjects   where   xtype='PK'   and   name   in   (
                    SELECT   name   FROM   sysindexes   WHERE   indid   in(
                    SELECT   indid   FROM   sysindexkeys   WHERE   id   =   a.id   AND   colid=a.colid
                    )))   then   '1'   else   '0'   end),
                    Field_Type=b.name,
                    Field_Length=a.length,
                    Field_Precision=COLUMNPROPERTY(a.id,a.name,'PRECISION'),
                    Field_Scale=isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0),
                    Field_IsNullable=case   when   a.isnullable=1   then   '1'else   '0'   end,
                    Field_DefaultValue=isnull(e.text,'') ,
                    CreateDate =GETDATE() ,
                    CreateUserId= '{3}' ,
                    CreateUserName= '{4}'  ,
                    ModifyDate =GETDATE()  ,
                    ModifyUserId= '{3}' ,
                    ModifyUserName = '{4}'   
                FROM   syscolumns   a
                left   join   systypes   b   on   a.xusertype=b.xusertype
                inner  join   sysobjects   d   on   a.id=d.id     and   d.xtype='U'   and     d.name<>'dtproperties'
                left   join   syscomments   e   on   a.cdefault=e.id
                left   join   sys.extended_properties   g   on   a.id=g.major_id   and   a.colid=g.minor_id
                left   join   sys.extended_properties   f   on   d.id=f.major_id   and   f.minor_id=0
                left   join [{0}].dbo.[Base_DBTableField] DBTableField on (DBTableField.Field_DBName='{1}' and d.name=DBTableField.Field_TableName and a.name=DBTableField.Field_Name )
                where   d.name='{2}'  and DBTableField.Field_Name is null        --如果只查询指定表,加上此条件
                order   by   a.id,a.colorder ; ", strPlatform_DBName,strDBName, strTableName, OperatorProvider.Provider.Current().UserId, OperatorProvider.Provider.Current().UserName);

            //根据数据库更新字段属性
            sql += "\r\n" + String.Format(@"
                    Update [{0}].dbo.[Base_DBTableField]  Set 
                    Field_ColOrder=a.colorder, 
                    Field_Desc=Convert(varchar(80) ,isnull(g.[value],'')) ,
                    Field_IsIdentity=case   when   COLUMNPROPERTY(   a.id,a.name,'IsIdentity')=1   then   '1'else   '0'   end,
                    Field_IsPK=case   when   exists(SELECT   1   FROM   sysobjects   where   xtype='PK'   and   name   in   (
                    SELECT   name   FROM   sysindexes   WHERE   indid   in(
                    SELECT   indid   FROM   sysindexkeys   WHERE   id   =   a.id   AND   colid=a.colid
                    )))   then   '1'   else   '0'   end,
                    Field_Type=b.name,
                    Field_Length=a.length,
                    Field_Precision=COLUMNPROPERTY(a.id,a.name,'PRECISION'),
                    Field_Scale=isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0),
                    Field_IsNullable=case   when   a.isnullable=1   then   '1'else   '0'   end,
                    Field_DefaultValue=isnull(e.text,'') 
                FROM   syscolumns   a
                left   join   systypes   b   on   a.xusertype=b.xusertype
                inner  join   sysobjects   d   on   a.id=d.id     and   d.xtype='U'   and     d.name<>'dtproperties'
                left   join   syscomments   e   on   a.cdefault=e.id
                left   join   sys.extended_properties   g   on   a.id=g.major_id   and   a.colid=g.minor_id
                left   join   sys.extended_properties   f   on   d.id=f.major_id   and   f.minor_id=0
                left   join [{0}].dbo.[Base_DBTableField] DBTableField on (DBTableField.Field_DBName='{1}' and d.name=DBTableField.Field_TableName and a.name=DBTableField.Field_Name )
                where   d.name='{2}'  and DBTableField.Field_Name is not null  ; ", strPlatform_DBName, strDBName, strTableName);
      
            base.db.ExecuteNonQuery(sql);

            //设置字段删除标志
            sql = string.Format(" USE {0} ; \r\n ", strDBName);
                sql += "\r\n" + String.Format(@"
                    Update [{0}].dbo.[Base_DBTableField]  Set  Field_DeleteFlag='1'                           
                FROM [{0}].dbo.[Base_DBTableField]  field
                left join 
                (
                    select a.Name as FieldName, d.name  as TableName From syscolumns   a
                    left   join   systypes   b   on   a.xusertype=b.xusertype
                    inner  join   sysobjects   d   on   a.id=d.id     and   d.xtype='U'   and     d.name<>'dtproperties'   
                    where   d.name='{2}'  
                )  f               
                on ( field.Field_DBName='{1}' and f.TableName=field.Field_TableName and f.FieldName=field.Field_Name )
                where field.Field_DBName='{1}' and field.Field_TableName ='{2}'  and f.FieldName is  null  ; ", strPlatform_DBName,strDBName, strTableName);
            base.db.ExecuteNonQuery(sql);
               
            return true;
        }


    }
}
