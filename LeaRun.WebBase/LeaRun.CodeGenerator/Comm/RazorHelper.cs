using System;
using System.Collections.Generic;
using System.IO; 
using System.Web;
using RazorEngine;
using RazorEngine.Templating; // For extension methods.

namespace LeaRun.Util.Web
{
    public class RazorHelper
    {
        public static string ParseRazor(HttpContext context, string csHtmlVirtualPath, object model)
        {
            string fullPath = context.Server.MapPath(csHtmlVirtualPath);
            string cshtml = File.ReadAllText(fullPath);
            string cacheName = fullPath + File.GetLastWriteTime(fullPath);
            string html =  Engine.Razor.RunCompile(cshtml,"templateKey",null, model);
            return html;
        }
    }
}
