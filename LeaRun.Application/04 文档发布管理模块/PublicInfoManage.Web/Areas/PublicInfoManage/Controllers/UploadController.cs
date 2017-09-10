using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaRun.PublicInfoManage.Controllers 
{
    /// <summary>
    /// 文件上传控制器
    /// </summary>
    public class UploadController : Controller
    {
        //
        // GET: /BusinesManage/Upload/
        /// <summary>
        /// 视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        #region 文件上传
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Upload()
        {
            string fileName = Request["name"];
            int lastIndex = fileName.LastIndexOf('.');
            string fileRelName = lastIndex == -1? fileName: fileName.Substring(0, fileName.LastIndexOf('.'));
            fileRelName = fileRelName.Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "").Replace(",", "");
            int index = Convert.ToInt32(Request["chunk"]);//当前分块序号
            var guid = Request["guid"];//前端传来的GUID号
            var dir = Server.MapPath("~/Upload/file");//文件上传目录
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd");
            dir += "\\" + currentTime;
            dir = Path.Combine(dir, fileRelName);//临时保存分块的目录
            if (!System.IO.Directory.Exists(dir))
                System.IO.Directory.CreateDirectory(dir);
            string filePath = Path.Combine(dir, index.ToString());//分块文件名为索引名，更严谨一些可以加上是否存在的判断，防止多线程时并发冲突
            var data = Request.Files["file"];//表单中取得分块文件
            //if (data != null)//为null可能是暂停的那一瞬间
            //{
            data.SaveAs(filePath);//报错
            //}
            return Json(new { erron = 0 });//Demo，随便返回了个值，请勿参考
        }
        /// <summary>
        /// 合并文件分片
        /// </summary>
        /// <returns></returns>
        public ActionResult Merge()
        {
            var guid = Request["guid"];//GUID
            var uploadDir = Server.MapPath("~/Upload/file");//Upload/file 文件夹
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd");
            uploadDir += "\\" + currentTime;
            var fileName = Request["fileName"];//文件名
            string fileRelName = fileName.Substring(0, fileName.LastIndexOf('.'));
            fileRelName = fileRelName.Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "").Replace(",", "");
            fileName = fileName.Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "").Replace(",", "");
            var dir = Path.Combine(uploadDir, fileRelName);//临时文件夹          
            var files = System.IO.Directory.GetFiles(dir);//获得下面的所有文件
            var finalPath = Path.Combine(uploadDir, fileName);//最终的文件名（demo中保存的是它上传时候的文件名，实际操作肯定不能这样）
            var fs = new FileStream(finalPath, FileMode.Create);
            foreach (var part in files.OrderBy(x => x.Length).ThenBy(x => x))//排一下序，保证从0-N Write
            {
                var bytes = System.IO.File.ReadAllBytes(part);
                fs.Write(bytes, 0, bytes.Length);
                bytes = null;
                System.IO.File.Delete(part);//删除分块
            }
            fs.Flush();
            fs.Close();
            System.IO.Directory.Delete(dir);//删除文件夹
            return Json(new { error = 0, filepath = finalPath.Substring(finalPath.IndexOf("Upload\\")).Replace(@"\", @"/"), filename = fileName });//随便返回个值，实际中根据需要返回
        }


        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public ActionResult DownFile(string filePath, string fileName)
        {
            try
            {
                filePath = Server.MapPath("~/" + filePath);
                FileStream fs = new FileStream(filePath, FileMode.Open);
                byte[] bytes = new byte[(int)fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                fs.Close();
                Response.Charset = "UTF-8";
                Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");
                Response.ContentType = "application/octet-stream";

                Response.AddHeader("Content-Disposition", "attachment; filename=" + Server.UrlEncode(fileName));
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
               
            }
            catch (Exception ex)
            {

            }
            return new EmptyResult();

        }


        #endregion
    }
}
