using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;
using System.Web.WebPages;
using RazorGenerator.Mvc;
using System.IO;

[assembly: System.Web.PreApplicationStartMethod(typeof(LeaRun.Application.Web.WebActivator), "start")]

namespace LeaRun.Application.Web
{
    public static class WebActivator
    { 
        public static void start()
        { 
            RegisterPrecompiledMVCEngines();
        }

        private static void RegisterPrecompiledMVCEngines()  //加载所有模块dll
        {
            string dllpath = Assembly.GetExecutingAssembly().CodeBase.Replace("LeaRun.WebMain.DLL", "").Replace("file:///", "");
             
            IList<PrecompiledViewAssembly> views = new List<PrecompiledViewAssembly>();
            foreach (string file in Directory.EnumerateFiles(dllpath, "*.Web.dll"))
            {
                var assembly = Assembly.Load(AssemblyName.GetAssemblyName(file));
                BuildManager.AddReferencedAssembly(assembly);
                views.Add(new PrecompiledViewAssembly(assembly));
            }
            var engine = new CompositePrecompiledMvcEngine(views.ToArray());
            ViewEngines.Engines.Add(engine);
            VirtualPathFactoryManager.RegisterVirtualPathFactory(engine);

        }
    }
}