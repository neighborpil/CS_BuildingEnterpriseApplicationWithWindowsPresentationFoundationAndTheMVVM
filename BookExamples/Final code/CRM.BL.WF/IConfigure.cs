using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Activities;

namespace CRM.BL.WF
{
    public interface IConfigure
    {
        IConfigure LoadAssembly(string assemblyName);

        IConfigure LoadAssembly(Assembly assembly);

        IConfigure LoadActivity(string activityName);

        IConfigure LoadActivity(Activity activity);

        IConfigure AddParamters(IDictionary<String, Object> parameters);

        IEvents Configure();

        void Run();
    }
}
