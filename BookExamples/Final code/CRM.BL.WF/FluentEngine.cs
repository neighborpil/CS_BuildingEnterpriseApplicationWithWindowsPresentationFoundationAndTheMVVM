using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.BL.WF
{
    public static class FluentEngine
    {
        private static IConfigure engine;

        static FluentEngine()
        {
            engine = new ConcreteEngine();
        }

        public static IConfigure Init()
        {
            return engine;
        }
    }
}
