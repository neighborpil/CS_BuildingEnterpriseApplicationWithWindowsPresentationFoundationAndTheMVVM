using System.Collections.Generic;
using CRM.Domain.Domain;

namespace CRM.BL.WF
{
    internal class Test
    {
        public bool CanAddAnOrder(Customer customer, Order order)
        {
            //Init the engine class
            FluentEngine.Init()
                //load assembly and workflow
                .LoadAssembly("CRM.BL.WF.dll")
                .LoadActivity("CanAddAnOrder.xaml")
                //prepare the parameters collection
                // it should contains input/output params
                .AddParamters(new Dictionary<string, object>
                                  {
                                      {"Order", order},
                                      {"Customer", customer},
                                      {"CanAddOrder", false}
                                  })
                .Configure()
                //when the WF is done
                .OnComplete(() => { })
                //when the WF raises an error
                .OnError((ex) => { })
                .Run();
            return false;
        }
    }
}