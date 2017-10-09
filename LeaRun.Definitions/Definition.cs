using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeaRun.Definitions
{
    public class Definition
    {
        #region 系统常量
        /// <summary>
        /// 登录用户的SESSIONID
        /// </summary>
        public const string SESSION_USER = "EMERGENCY_SESSION_USER";
        /// <summary>
        /// 默认操作日志在页面上显示条数
        /// </summary>
        public const int DEFAULT_LOGVIEW_TAKE = 5;
        /// <summary>
        /// 通用分隔符
        /// </summary>
        public const char SPLIT = ',';
        #endregion

        #region 文档保存路径常量定义

        /// <summary>
        /// 本管理系统文档的根目录
        /// </summary>
        public const string DOCUMENTS_ROOT = @"~\Documents\";

        /// <summary>
        /// 数据导入的模板文件存储路径（路径前缀）
        /// </summary>
        public const string TEMPLATE_PREFIX = @"~\templates\";
        /// <summary>
        /// 数据导出的模板文件存储路径（路径前缀）
        /// </summary>
        public const string EXPORT_TEMPLATE_PREFIX = TEMPLATE_PREFIX + @"Export\";
        /// <summary>
        /// 数据导出的模板文件存储路径（路径前缀）
        /// </summary>
        public const string IMPORT_TEMPLATE_PREFIX = TEMPLATE_PREFIX + @"Import\";

        /// <summary>
        /// 本系统临时文件目录
        /// </summary>
        public const string DOCUMENTS_TEMP = DOCUMENTS_ROOT + @"Temp\";

        /// <summary>
        /// 数据导入文件临时存储路径（路径前缀）
        /// </summary>
        public const string IMPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"ImportTemp\";

        /// <summary>
        /// 订单一览导出的保存路径（路径前缀）
        /// </summary>
        public const string ORDERLIST_EXPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"Export\SaleOrderList\";
        /// <summary>
        /// 订单退换货一览导出的保存路径（路径前缀）
        /// </summary>
        public const string EXCHANGECONTACTS_EXPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"Export\ExchangeContactsList\";
        /// <summary>
        /// 订单退换货一览导出的保存路径（路径前缀）
        /// </summary>
        public const string REFUND_EXPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"Export\RefundContactsList\";
        /// <summary>
        /// 退款对账一览导出的保存路径（路径前缀）
        /// </summary>
        public const string CHECK_REFUND_EXPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"Export\CheckRefundsList\";
        /// <summary>
        /// 采购单一览导出的保存路径（路径前缀）
        /// </summary>
        public const string PURCHASE_EXPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"Export\PurchaseList\";

        /// <summary>
        /// 财务付款一览导出的保存路径（路径前缀）
        /// </summary>
        public const string PAYMENT_EXPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"Export\PaymentContactList\";
        /// <summary>
        /// 导出任务申请一览导出的保存路径（路径前缀）
        /// </summary>
        public const string EXPORTTASKREQUEST_EXPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"Export\ExportTaskRequest\";
        /// <summary>
        ///商品导出的保存路径（路径前缀）
        /// </summary>
        public const string PRODUCT_EXPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"Export\Products\";
        /// <summary>
        /// 促销活动一览导出的保存路径（路径前缀）
        /// </summary>
        public const string PROMOTION_EXPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"Export\PromotionList\";

        /// <summary>
        /// 财务导出的保存路径（路径前缀）
        /// </summary>
        public const string FINANCE_EXPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"Export\FinanceList\";
        /// <summary>
        /// 货款结算导出的保存路径（路径前缀）
        /// </summary>
        public const string SETTLEMENT_EXPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"Export\Settlement\";
        public const string PriceParity_EXPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"Export\PriceParity\";

        /// <summary>
        /// 充值单导出的保存路径（路径前缀）
        /// </summary>
        public const string CHARGECONTRACT_EXPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"Export\ChargeContract\";
        /// <summary>
        /// 商品单位导出的保存路径（路径前缀）
        /// </summary>
        public const string PRODUCTUNIT_EXPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"Export\ProductUnit\";
        /// <summary>
        /// 组合商品导出的保存路径（路径前缀）
        /// </summary>
        public const string PRODUCTBUNDLE_EXPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"Export\ProductBundle\";
        /// <summary>
        /// 基础数据导出的保存路径（路径前缀）
        /// </summary>
        public const string BASICDATA_EXPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"Export\BasicData\";
        /// <summary>
        /// 优惠券导出的保存路劲（路径前缀）
        /// </summary>
        public const string COUPON_EXPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"Export\Coupon\";
        /// <summary>
        /// 采购明细导出（路径前缀）
        /// </summary>
        public const string PurchaseProduct_EXPORT_PATH_PREFIX = DOCUMENTS_ROOT + @"Export\PurchaseProduct\";
        #endregion

        #region 日期相关常量定义
        /// <summary>
        /// 月份格式化字符串yyyy年MM月
        /// </summary>
        public const string MONTH_FORMAT_CN = "yyyy年MM月";

        /// <summary>
        /// 日期格式化字符串yyyy-MM-dd
        /// </summary>
        public const string DATE_FORMAT_HYPHEN = "yyyy-MM-dd";

        /// <summary>
        /// 日期时间格式化字符串yyyy-MM-dd HH:mm:ss
        /// </summary>
        public const string DATETIME_FORMAT_HYPHEN = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 日期格式化字符串yyyy/MM/dd
        /// </summary>
        public const string DATE_FORMAT_SLASH = "yyyy/MM/dd";

        /// <summary>
        /// 日期时间格式化字符串yyyy/MM/dd HH:mm:ss
        /// </summary>
        public const string DATETIME_FORMAT_SLASH = "yyyy/MM/dd HH:mm:ss";
        /// <summary>  
        /// 系统内默认开始日期(1900/01/01)
        /// </summary>
        public static DateTime LLY_MIN_DATE = DateTime.Parse("1900/01/01");
        /// <summary>  
        /// 系统内默认结束日期(2099/12/31)  
        /// </summary>
        public static DateTime LLY_MAX_DATE = DateTime.Parse("2099/12/31");

        #endregion

        #region 数据库操作结果
        /// <summary>
        /// 数据库操作结果 成功标志
        /// </summary>
        public const int DBSuccess = 1;
        /// <summary>
        /// 数据库操作结果 无影响
        /// </summary>
        public const int DBNoCount = 0;
        /// <summary>
        /// 数据库操作结果 失败标志
        /// </summary>
        public const int DBFailure = -1;
        #endregion

        #region 操作验证
        /// <summary>
        /// 操作验证SESSION名称
        /// </summary>
        public const string SESSION_VERIFY_CODE = "Session_VerifyCode";
        #endregion
    }
}
