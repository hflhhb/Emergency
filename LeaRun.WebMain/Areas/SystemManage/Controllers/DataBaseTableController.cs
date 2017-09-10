using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using LeaRun.Util;
using LeaRun.Util.Web;
using LeaRun.WebBase;
using LeaRun.SystemManage.Entity;
using LeaRun.SystemManage.Business;


namespace LeaRun.SystemManage.Controllers
{
    /// <summary>
    /// 版 本 1.5
    /// Copyright (c) 2017-2020 肖海根
    /// 创建人：肖海根
    /// 日 期：2016.11.18 11:02
    /// 描 述：据库表管理
    /// </summary>
    public class DataBaseTableController : MvcControllerBase
    {
        private DataBaseTableBLL dataBaseTableBLL = new DataBaseTableBLL();
        private DataBaseLinkBLL databaseLinkBLL = new DataBaseLinkBLL();

        #region 视图功能
        /// <summary>
        /// 数据库管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新建物理表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult AddTable()
        {
            DBTableEntity tableEntity = new DBTableEntity();
            string dataBaseLinkId = Util.StringUtil.cEmpty(Request["dataBaseLinkId"]);
            string tableName = Util.StringUtil.cEmpty(Request["tableName"]);
            if (tableName != string.Empty)
            {
                DataBaseLinkBLL dbLinkService = new DataBaseLinkBLL();
                DataBaseLinkEntity dataBaseLinkEntity = dbLinkService.GetEntity(dataBaseLinkId);
                //根据数据库名和表名获取表实体
                tableEntity = dataBaseTableBLL.GetDBTable(dataBaseLinkEntity.DBName, tableName);
            } 
            return View(tableEntity);
        }


        /// <summary>
        /// 新建物理表页面中，调用的新增、修改字段对话框页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddTableField()
        {  
            return View();
        }

        /// <summary>
        /// 编辑表扩展信息页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult EditTable()
        {
            DBTableEntity tableEntity = new DBTableEntity();
            string dataBaseLinkId = Util.StringUtil.cEmpty(Request["dataBaseLinkId"]);
            string tableName = Util.StringUtil.cEmpty(Request["tableName"]);
            if (tableName != string.Empty)
            {
                DataBaseLinkBLL dbLinkService = new DataBaseLinkBLL();
                DataBaseLinkEntity dataBaseLinkEntity = dbLinkService.GetEntity(dataBaseLinkId);
                //根据数据库名和表名获取表实体
                tableEntity = dataBaseTableBLL.GetDBTable(dataBaseLinkEntity.DBName, tableName);
            }
            return View(tableEntity);
        }

        /// <summary>
        /// 打开表数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAuthorize(PermissionMode.Enforce)]
        public ActionResult TableData()
        {
            return View();
        }

        /// <summary>
        /// 单独新增字段
        /// </summary>
        /// <param name="dataBaseLinkId">数据库链接ID</param>
        /// <param name="tableName">表名</param> 
        /// <returns></returns>
        [HttpGet] 
        public ActionResult AddField(string dataBaseLinkId, string tableName )
        {
            return View();
        }

        /// <summary>
        /// 单独调整字段
        /// </summary>
        /// <param name="dataBaseLinkId">数据库链接ID</param>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditField(string dataBaseLinkId, string tableName, string fieldName)
        {
            IEnumerable<DatabaseFieldEntity> fields = dataBaseTableBLL.GetTableFiledList(dataBaseLinkId, tableName);
            DatabaseFieldEntity field=  fields.FirstOrDefault(t=>t.column == fieldName);
            return View(field);
        }

        /// <summary>
        /// 字段关联关系页面
        /// </summary>
        /// <param name="dataBaseLinkId">数据库链接ID</param>
        /// <param name="tableName">表名</param>
        /// <param name="fieldName">字段名</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FieldRelation(string dataBaseLinkId, string tableName, string fieldName)
        {
            IList<SelectListItem> selectList = new List<SelectListItem>();

            //数据库列表
            IEnumerable<DatabaseEntity> dbList = dataBaseTableBLL.GetDBNameList(dataBaseLinkId);
            foreach (DatabaseEntity dbEntity in dbList)
            {
                SelectListItem option = new SelectListItem() { Value = StringUtil.cEmpty(dbEntity.Name), Text = StringUtil.cEmpty(dbEntity.Name) + " - " + StringUtil.cEmpty(dbEntity.Description) };
                selectList.Add(option);
            }
            ViewBag.DBList = selectList;

            //本表字段列表
            selectList = new List<SelectListItem>();
            IEnumerable<DatabaseFieldEntity> FieldList = dataBaseTableBLL.GetTableFiledList(dataBaseLinkId, tableName);
            foreach (DatabaseFieldEntity field in FieldList)
            {
                SelectListItem option = new SelectListItem() { Value = StringUtil.cEmpty(field.column), Text = StringUtil.cEmpty(field.column) + " - " + StringUtil.cEmpty(field.remark) };
                selectList.Add(option);
            }
            ViewBag.OwnFields = selectList;

            //数据字典列表
            DataItemBLL dataItemBLL = new DataItemBLL();
            IEnumerable<DataItemEntity> DictList = dataItemBLL.GetList().Where(t => t.ParentId != "0");
            selectList = new List<SelectListItem>();
            foreach (DataItemEntity dict in DictList)
            {
                SelectListItem option = new SelectListItem() { Value = StringUtil.cEmpty(dict.ItemId), Text = StringUtil.cEmpty(dict.ItemCode) + " - " + StringUtil.cEmpty(dict.ItemName) };
                selectList.Add(option);
            }
            ViewBag.DictList = selectList;

            string strDBName = AppConstant.AppPlatformDB;
            /// 根据数据库名、表名、字段名获取字段实体  
            if (dataBaseLinkId != string.Empty)
            {
                DataBaseLinkBLL dbLinkService = new DataBaseLinkBLL();
                DataBaseLinkEntity dataBaseLinkEntity = dbLinkService.GetEntity(dataBaseLinkId);
                strDBName = dataBaseLinkEntity.DBName;
            }

            DBTableFieldEntity fieldEntity = dataBaseTableBLL.GetDBTableField(strDBName, tableName, fieldName);
            ViewBag.FieldEntity = fieldEntity;
            return View(ViewBag.FieldEntity);
        }
        #endregion

        #region 联动下拉框数据源 
        /// <summary>
        /// 选择数据库后，带出主键表名下拉框
        /// </summary>
        /// <returns></returns> 
        public ContentResult PrimaryTableSelect()
        {
            try
            {
                IList<SelectListItem> selectList = new List<SelectListItem>();
                string str_dataBaseLinkId = StringUtil.cEmpty(Request["dataBaseLinkId"]);
                string str_PrimaryDBName  = StringUtil.cEmpty(Request["Field_PrimaryDBName"]);
                IEnumerable<DatabaseTableEntity> tableList = dataBaseTableBLL.GetTableInfoList(str_dataBaseLinkId, str_PrimaryDBName,string.Empty); 
                foreach (DatabaseTableEntity table in tableList)
                {
                   
                    SelectListItem option = new SelectListItem() { Value = StringUtil.cEmpty(table.name), Text = StringUtil.cEmpty(table.name) + " - " + StringUtil.cEmpty(table.tdescription) };

                    selectList.Add(option);
                }

                return Content(selectList.ToChainedJson());
            }
            catch (Exception err)
            {
                BjuiResponse BjuiResponse = new BjuiResponse();
                HttpContext.Response.StatusCode = 300; //返回错误状态吗
                BjuiResponse.statusCode = HttpContext.Response.StatusCode.ToString();
                BjuiResponse.message = err.Message;
                return Content(BjuiResponse.ToJson());
            }
        }

        /// <summary>
        /// 选择主键表名后，带出主键字段名下拉框
        /// </summary>
        /// <returns></returns> 
        public ContentResult PrimaryFieldSelect()
        {
            try
            {
                IList<SelectListItem> selectList = new List<SelectListItem>();
                string str_dataBaseLinkId = StringUtil.cEmpty(Request["dataBaseLinkId"]);
                string str_PrimaryDBName = StringUtil.cEmpty(Request["Field_PrimaryDBName"]);
                string str_PrimaryTableName = StringUtil.cEmpty(Request["Field_PrimaryTable"]);
                IEnumerable <DatabaseFieldEntity> list= dataBaseTableBLL.GetTableFiledList(str_dataBaseLinkId, str_PrimaryTableName);
                foreach (DatabaseFieldEntity field in list)
                { 
                    SelectListItem option = new SelectListItem() { Value = StringUtil.cEmpty(field.column), Text = StringUtil.cEmpty(field.column) + " - " + StringUtil.cEmpty(field.remark) };
                    selectList.Add(option);
                }

                return Content(selectList.ToChainedJson());
            }
            catch (Exception err)
            {
                BjuiResponse BjuiResponse = new BjuiResponse();
                HttpContext.Response.StatusCode = 300; //返回错误状态吗
                BjuiResponse.statusCode = HttpContext.Response.StatusCode.ToString();
                BjuiResponse.message = err.Message;
                return Content(BjuiResponse.ToJson());
            }
        }
        #endregion

        #region 获取数据
        /// <summary>
        /// 数据库表列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="keyword">关键字查询</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetTableListJson(string dataBaseLinkId, string keyword)
        {
            IEnumerable<DatabaseTableEntity> tableList = new List<DatabaseTableEntity>();
            if (dataBaseLinkId != string.Empty)
            {
                DataBaseLinkBLL dbLinkService = new DataBaseLinkBLL();
                DataBaseLinkEntity dataBaseLinkEntity = dbLinkService.GetEntity(dataBaseLinkId); 
                tableList = dataBaseTableBLL.GetTableInfoList(dataBaseLinkId, dataBaseLinkEntity.DBName, keyword); 
            }

            return ToJsonResult(tableList);
        }
        /// <summary>
        /// 数据库表字段列表 
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <param name="nameId">字段Id</param>
        /// <returns>返回树形Json</returns>
        [HttpGet]
        public ActionResult GetTableFiledTreeJson(string dataBaseLinkId, string tableName, string nameId)
        {
            List<string> nameArray = new List<string>();
            if (!string.IsNullOrEmpty(nameId))
            {
                nameArray = new List<string>(nameId.Split(','));
            }

            var data = dataBaseTableBLL.GetTableFiledList(dataBaseLinkId, tableName);
            var treeList = new List<TreeEntity>();
            TreeEntity tree = new TreeEntity();
            tree.id = tableName;
            tree.text = tableName;
            tree.value = tableName;
            tree.parentId = "0";
            tree.img = "fa fa-list-alt";
            tree.isexpand = true;
            tree.complete = true;
            tree.hasChildren = true;
            treeList.Add(tree);
            foreach (DatabaseFieldEntity item in data)
            {
                tree = new TreeEntity();
                tree.id = item.column;
                tree.text = item.remark + "（" + item.column + "）";
                tree.value = item.remark;
                tree.parentId = tableName;
                tree.img = "fa fa-wrench";
                tree.isexpand = true;
                tree.complete = true;
                tree.showcheck = true;
                tree.checkstate = nameArray.Contains(item.column) == true ? 1 : 0;
                tree.hasChildren = false;
                treeList.Add(tree);
            }
            return Content(treeList.TreeToJson());
        }

        /// <summary>
        /// 数据库表字段列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetTableFiledListJson(string dataBaseLinkId, string tableName)
        {
            var data = dataBaseTableBLL.GetTableFiledList(dataBaseLinkId, tableName);
            return ToJsonResult(data);
        }

        /// <summary>
        /// 数据库表数据列表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表明</param>
        /// <param name="switchWhere">条件</param>
        /// <param name="logic">逻辑</param>
        /// <param name="keyword">关键字</param>
        /// <param name="pagination">分页参数</param>
        /// <returns>返回列表Json</returns>
        [HttpGet]
        public ActionResult GetTableDataListJson(string dataBaseLinkId, string tableName, string switchWhere, string logic, string keyword, Pagination pagination)
        {
            var watch = CommonHelper.TimerStart();
            var data = dataBaseTableBLL.GetTableDataList(dataBaseLinkId, tableName, switchWhere, logic, keyword, pagination);
            var JsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(JsonData);
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 保存数据库表表单（新增、修改）
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param>
        /// <param name="tableDisplayName">表说明</param>
        /// <param name="tableModuleName">所属模块名</param>
        /// <param name="tableNameSpace">实体模型的命名空间</param>
        /// <param name="tableEntityClass">默认实体的类名</param>
        /// <param name="tableDesc">备注</param>
        /// <param name="fieldListJson">字段列表Json</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult CreateTable(string dataBaseLinkId, string tableName,string tableDisplayName,string tableModuleName, string tableNameSpace,string tableEntityClass, string tableDesc, string fieldListJson)
        {
            dataBaseTableBLL.CreateTable(dataBaseLinkId, tableName, tableDisplayName, tableModuleName, tableNameSpace, tableEntityClass, tableDesc, fieldListJson);
            return Success("操作成功。");
        }

        public ActionResult ModifyTableInfo(string dataBaseLinkId, string tableName, string tableDisplayName, string tableModuleName, string tableNameSpace, string tableEntityClass, string tableDesc)
        {
            dataBaseTableBLL.ModifyTableInfo(dataBaseLinkId, tableName, tableDisplayName, tableModuleName, tableNameSpace, tableEntityClass, tableDesc);
            return Success("操作成功。");
        }
        

        /// <summary>
        /// 删除物理表
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param> 
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RemoveForm(string dataBaseLinkId, string tableName)
        {
            dataBaseTableBLL.DeleteTable(dataBaseLinkId, tableName);
            return Success("删除成功。");
        }

        /// <summary>
        /// 调整物理字段
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param> 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult CreateField(string dataBaseLinkId, string tableName)
        {
            DatabaseFieldEntity fieldEntity = new DatabaseFieldEntity();
            fieldEntity.column = StringUtil.cEmpty(Request.Form["column"]);
            fieldEntity.remark = StringUtil.cEmpty(Request.Form["remark"]);
            fieldEntity.datatype = StringUtil.cEmpty(Request.Form["datatype"]);
            fieldEntity.length = StringUtil.getInt(Request.Form["length"]);
            fieldEntity.defaults = StringUtil.cEmpty(Request.Form["defaults"]);
            fieldEntity.isnullable = StringUtil.cEmpty(Request.Form["isnullable"]);
            fieldEntity.identity = StringUtil.cEmpty(Request.Form["identity"]);
            fieldEntity.key = StringUtil.cEmpty(Request.Form["key"]);

            dataBaseTableBLL.CreateField(dataBaseLinkId, tableName, fieldEntity);
            return Success("成功新增字段。");
        }

        /// <summary>
        /// 调整物理字段
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param> 
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveField(string dataBaseLinkId, string tableName )
        {
            DatabaseFieldEntity fieldEntity = new DatabaseFieldEntity();
            fieldEntity.column = StringUtil.cEmpty(Request.Form["column"]);
            fieldEntity.remark = StringUtil.cEmpty(Request.Form["remark"]);
            fieldEntity.datatype = StringUtil.cEmpty(Request.Form["datatype"]);
            fieldEntity.length = StringUtil.getInt(Request.Form["length"]);
            fieldEntity.defaults = StringUtil.cEmpty(Request.Form["defaults"]);  
            fieldEntity.isnullable = StringUtil.cEmpty(Request.Form["isnullable"]);
            fieldEntity.identity = StringUtil.cEmpty(Request.Form["identity"]);
            fieldEntity.key = StringUtil.cEmpty(Request.Form["key"]);

            dataBaseTableBLL.SaveField(dataBaseLinkId, tableName, fieldEntity);
            return Success("保持字段成功。");
        }

        /// <summary>
        /// 删除物理字段
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param>
        /// <param name="fieldName">字段名称</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult DeleteField(string dataBaseLinkId, string tableName, string fieldName)
        {
            dataBaseTableBLL.DeleteField(dataBaseLinkId,tableName, fieldName);
            return Success("删除字段成功。");
        }

        /// <summary>
        /// 保存数据库字段扩展信息(修改）
        /// </summary>
        /// <param name="dataBaseLinkId">库连接Id</param>
        /// <param name="tableName">表名称</param>
        /// <param name="fieldName">字段名称</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveFieldRelation(string dataBaseLinkId, string tableName, string fieldName)
        {
            if (dataBaseLinkId != string.Empty)
            {
                DataBaseLinkBLL dbLinkService = new DataBaseLinkBLL();
                DataBaseLinkEntity dataBaseLinkEntity = dbLinkService.GetEntity(dataBaseLinkId);
                DBTableFieldEntity fieldEntity = dataBaseTableBLL.GetDBTableField(dataBaseLinkEntity.DBName, tableName, fieldName);
                  
                fieldEntity.Field_Desc = StringUtil.cEmpty(Request.Form["Field_Desc"]);
                fieldEntity.Field_DataSourceType = StringUtil.cEmpty(Request.Form["Field_DataSourceType"]); 
                fieldEntity.Field_EnumType = string.Empty;
                fieldEntity.Field_SelectValues = string.Empty;
                fieldEntity.Field_DictParentGUID = string.Empty;
                fieldEntity.Field_DictValueField = string.Empty;
                fieldEntity.Field_DictForeignField1 = string.Empty;
                fieldEntity.Field_DictFilterField1 = string.Empty;
                fieldEntity.Field_DictForeignField2 = string.Empty;
                fieldEntity.Field_DictFilterField2 = string.Empty;
                fieldEntity.Field_PrimaryDBName = string.Empty;
                fieldEntity.Field_PrimaryTable = string.Empty;
                fieldEntity.Field_DataSourceSQL = string.Empty;
                fieldEntity.Field_PrimaryField = string.Empty;
                fieldEntity.Field_ForeignField1 = string.Empty;
                fieldEntity.Field_PrimaryField1 = string.Empty;
                fieldEntity.Field_ForeignField2 = string.Empty;
                fieldEntity.Field_PrimaryField2 = string.Empty;
                fieldEntity.Field_ForeignField3 = string.Empty;
                fieldEntity.Field_PrimaryField3 = string.Empty;
                fieldEntity.Field_ForeignField4 = string.Empty;
                fieldEntity.Field_PrimaryField4 = string.Empty;

                if (string.Compare(fieldEntity.Field_DataSourceType, LeaRun.Util.Enums.FieldDataSourceType.Boolean.ToString(), true) == 0)
                {

                }else if (string.Compare(fieldEntity.Field_DataSourceType, LeaRun.Util.Enums.FieldDataSourceType.Enum.ToString(), true) == 0)
                {
                    fieldEntity.Field_EnumType = StringUtil.cEmpty(Request.Form["Field_EnumType"]);
                }
                else if (string.Compare(fieldEntity.Field_DataSourceType, LeaRun.Util.Enums.FieldDataSourceType.OptionList.ToString(), true) == 0)
                {

                    fieldEntity.Field_SelectValues = StringUtil.cEmpty(Request.Form["Field_SelectValues"]);
                } 
                else if (string.Compare(fieldEntity.Field_DataSourceType, LeaRun.Util.Enums.FieldDataSourceType.Dictionary.ToString(), true) == 0)
                {

                    fieldEntity.Field_DictParentGUID = StringUtil.cEmpty(Request.Form["Field_DictParentGUID"]);
                    fieldEntity.Field_DictValueField = StringUtil.cEmpty(Request.Form["Field_DictValueField"]);
                    fieldEntity.Field_DictForeignField1 = StringUtil.cEmpty(Request.Form["Field_DictForeignField1"]);
                    fieldEntity.Field_DictFilterField1 = StringUtil.cEmpty(Request.Form["Field_DictFilterField1"]);
                    fieldEntity.Field_DictForeignField2 = StringUtil.cEmpty(Request.Form["Field_DictForeignField2"]);
                    fieldEntity.Field_DictFilterField2 = StringUtil.cEmpty(Request.Form["Field_DictFilterField2"]);
                }
                else if (string.Compare(fieldEntity.Field_DataSourceType, LeaRun.Util.Enums.FieldDataSourceType.ForeignField.ToString(), true) == 0)
                {

                    fieldEntity.Field_PrimaryDBName = StringUtil.cEmpty(Request.Form["Field_PrimaryDBName"]);
                    fieldEntity.Field_PrimaryTable = StringUtil.cEmpty(Request.Form["Field_PrimaryTable"]);
                    fieldEntity.Field_DataSourceSQL = StringUtil.cEmpty(Request.Form["Field_DataSourceSQL"]);
                    fieldEntity.Field_PrimaryField = StringUtil.cEmpty(Request.Form["Field_PrimaryField"]);
                    fieldEntity.Field_ForeignField1 = StringUtil.cEmpty(Request.Form["Field_ForeignField1"]);
                    fieldEntity.Field_PrimaryField1 = StringUtil.cEmpty(Request.Form["Field_PrimaryField1"]);
                    fieldEntity.Field_ForeignField2 = StringUtil.cEmpty(Request.Form["Field_ForeignField2"]);
                    fieldEntity.Field_PrimaryField2 = StringUtil.cEmpty(Request.Form["Field_PrimaryField2"]);
                    fieldEntity.Field_ForeignField3 = StringUtil.cEmpty(Request.Form["Field_ForeignField3"]);
                    fieldEntity.Field_PrimaryField3 = StringUtil.cEmpty(Request.Form["Field_PrimaryField3"]);
                    fieldEntity.Field_ForeignField4 = StringUtil.cEmpty(Request.Form["Field_ForeignField4"]);
                    fieldEntity.Field_PrimaryField4 = StringUtil.cEmpty(Request.Form["Field_PrimaryField4"]);
                } 
                dataBaseTableBLL.SaveFieldRelation(dataBaseLinkId, tableName, fieldName , fieldEntity);
                return Success("操作成功。");
            }else
            {
                return Error("数据库链接ID参数无效！");
            }
        }
        #endregion
    }
}
