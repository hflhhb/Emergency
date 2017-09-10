using LeaRun.SystemManage.Entity;

namespace LeaRun.SystemManage.Service
{
    public interface ISubSystemService
    {
        APP_Application GetById(string app_Id);
        System.Data.DataTable GetPageDataTable(string strSql, string orderField, bool isAsc, int pageSize, int pageIndex, out int totalRecord);
        bool DeleteById(string app_Id);
    }
}