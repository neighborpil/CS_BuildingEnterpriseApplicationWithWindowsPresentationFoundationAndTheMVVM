using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.BL.WF
{
    public interface IEvents
    {
        IEvents OnComplete(Action onComplete);

        IEvents OnError(Action<Exception> onError);

        IEvents OnCancelled(Action onCancelled);

        void Run();
    }
}
