using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace KCS.Services
{
    public interface IModuleActivator
    {
        object CreateModule(string moduleTypeName);
        object CreateModule(string moduleTypeName, object viewModel);
    }
    class ModuleActivator : IModuleActivator
    {
        Assembly moduleAssembly;
        string rootNamespace;
        public ModuleActivator(Assembly moduleAssembly, string rootNamespace)
        {
            this.moduleAssembly = moduleAssembly;
            this.rootNamespace = rootNamespace;
        }
        public object CreateModule(string moduleTypeName)
        {
            Type moduleType = moduleAssembly.GetType(rootNamespace + '.' + moduleTypeName);
            return Activator.CreateInstance(moduleType);
        }
        public object CreateModule(string moduleTypeName, object viewModel)
        {
            Type moduleType = moduleAssembly.GetType(rootNamespace + '.' + moduleTypeName);
            return Activator.CreateInstance(moduleType, new object[] { viewModel });
        }
    }
    public interface IReportActivator
    {
        object CreateReport(object reportKey);
    }
    class ReportActivator : IReportActivator
    {
        IDictionary<object, Type> reportTypes;

        public ReportActivator()
        {
            this.reportTypes = new Dictionary<object, Type>();
            
        }
        public object CreateReport(object reportKey)
        {
            Type reportType;
            if (reportTypes.TryGetValue(reportKey, out reportType))
                return Activator.CreateInstance(reportType);
            throw new ArgumentException("reportKey");
        }
    }
}
