using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CRM.BL.WF
{
    public sealed class ConcreteEngine : IConfigure, IEvents
    {

        public IConfigure LoadAssembly(string assemblyName)
        {
            throw new NotImplementedException();
        }

        public IConfigure LoadAssembly(Assembly assembly)
        {
            throw new NotImplementedException();
        }

        public IConfigure LoadActivity(string activityName)
        {
            throw new NotImplementedException();
        }

        public IConfigure LoadActivity(Activity activity)
        {
            throw new NotImplementedException();
        }

        public IEvents Configure()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            throw new NotImplementedException();
        }

        public IEvents OnComplete(Action onComplete)
        {
            throw new NotImplementedException();
        }

        public IEvents OnError(Action<Exception> onError)
        {
            throw new NotImplementedException();
        }

        public IEvents OnCancelled(Action onCancelled)
        {
            throw new NotImplementedException();
        }


        public IConfigure AddParamters(IDictionary<string, object> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
