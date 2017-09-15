using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using Newtonsoft.Json.Linq;
using System;
using LeaRun.Util;
using System.IO;
using System.Web.Mvc;
using System.Text;

namespace LeaRun.PublicInfoManage.Controllers
{


    /// <summary>
    ///Office在线预览 
    /// </summary>
    public class OfficePreviewController : Controller
    {
        #region Index页面
        /// <summary>
        /// Index页面
        /// </summary> 
        /// <param name="file">例：/uploads/......XXX.xls</param>
        /// <returns></returns>
        public ActionResult Index(string file)
        {
            var data = JObject.Parse(file);
            string url =data["path"].ToString();
            string physicalPath = Server.MapPath(Server.UrlDecode(url));
            string extension = Path.GetExtension(physicalPath);

            string htmlUrl = "";
            switch (extension.ToLower())
            {
                case ".xls":
                case ".xlsx":
                    htmlUrl = PreviewExcel(physicalPath, url);
                    break;
                case ".doc":
                case ".docx":
                    htmlUrl = PreviewWord(physicalPath, url);
                    break;
                case ".txt":
                    htmlUrl = PreviewTxt(physicalPath, url);
                    break;
                case ".pdf":
                    htmlUrl = PreviewPdf(physicalPath, url);
                    break;
                case ".jpg":
                case ".jpeg":
                case ".bmp":
                case ".gif":
                case ".png":
                    htmlUrl = PreviewImg(physicalPath, url);
                    break;
                default:
                    htmlUrl = PreviewOther(physicalPath, url);
                    break;
            }
            var JsonData = new
            {
                Success = true,
                Data =htmlUrl  
            };
            return Content(JsonData.ToJson());

        }
        #endregion

        #region 预览Excel
        /// <summary>
        /// 预览Excel
        /// </summary>
        public string PreviewExcel(string physicalPath, string url)
        {
            string htmlName = Path.GetFileNameWithoutExtension(physicalPath) + ".html";
            String outputFile = Path.GetDirectoryName(physicalPath) + "\\" + htmlName;
            if (!System.IO.File.Exists(outputFile))
            {
                Microsoft.Office.Interop.Excel.Application application = null;
                Workbook workbook = null;
                application = new Microsoft.Office.Interop.Excel.Application();
                object missing = Type.Missing;
                object trueObject = true;
                application.Visible = false;
                application.DisplayAlerts = false;
                workbook = application.Workbooks.Open(physicalPath, missing, trueObject, missing, missing, missing,
                   missing, missing, missing, missing, missing, missing, missing, missing, missing);
                //Save Excelto Html
                object format = XlFileFormat.xlHtml;

                workbook.SaveAs(outputFile, format, missing, missing, missing,
                                  missing, XlSaveAsAccessMode.xlNoChange, missing,
                                  missing, missing, missing, missing);
                workbook.Close();
                application.Quit();
            }
            return Path.GetDirectoryName(Server.UrlDecode(url)) + "\\" + htmlName;
        }
        #endregion

        #region 预览Word
        /// <summary>
        /// 预览Word
        /// </summary>
        public string PreviewWord(string physicalPath, string url)
        {
            string htmlName = Path.GetFileNameWithoutExtension(physicalPath) + ".html";
            String outputFile = Path.GetDirectoryName(physicalPath) + "\\" + htmlName;
            if (!System.IO.File.Exists(outputFile))
            {
                Microsoft.Office.Interop.Word._Application application = null;
                Microsoft.Office.Interop.Word._Document doc = null;
                application = new Microsoft.Office.Interop.Word.Application();
                object missing = Type.Missing;
                object trueObject = true;
                application.Visible = false;
                application.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                doc = application.Documents.Open(physicalPath, missing, trueObject, missing, missing, missing,
                   missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
                //Save Excelto Html
                object format = WdSaveFormat.wdFormatHTML;

                doc.SaveAs(outputFile, format, missing, missing, missing,
                                  missing, XlSaveAsAccessMode.xlNoChange, missing,
                                  missing, missing, missing, missing);
                doc.Close();
                application.Quit();

                TransHTMLEncoding(outputFile);
            }
            return Path.GetDirectoryName(Server.UrlDecode(url)) + "\\" + htmlName;
        }
        #endregion

        #region 预览Txt
        /// <summary>
        /// 预览Txt
        /// </summary>
        public string PreviewTxt(string physicalPath, string url)
        {
            return Server.UrlDecode(url);
        }
        #endregion

        #region 预览Pdf
        /// <summary>
        /// 预览Pdf
        /// </summary>
        public string PreviewPdf(string physicalPath, string url)
        {
            return Server.UrlDecode(url);
        }
        #endregion

        #region 预览图片
        /// <summary>
        /// 预览图片
        /// </summary>
        public string PreviewImg(string physicalPath, string url)
        {
            return Server.UrlDecode(url);
        }
        #endregion

        #region 预览其他文件
        /// <summary>
        /// 预览其他文件
        /// </summary>
        public string PreviewOther(string physicalPath, string url)
        {
            return Server.UrlDecode(url);
        }
        #endregion


        private void TransHTMLEncoding(string strFilePath)
    {
        try
        {
            StreamReader sr = new StreamReader(strFilePath, Encoding.GetEncoding(0));
            string html = sr.ReadToEnd();
            sr.Close();
            html = System.Text.RegularExpressions.Regex.Replace(html, @"<meta[^>]*>", "<meta http-equiv=Content-Type content='text/html; charset=utf-8'>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);

            sw.Write(html);
            sw.Close();
        }
        catch (Exception ex)
        {
            
        }
    }

    }
}
