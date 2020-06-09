using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace CRM.MVVM.WeakEvent
{
    public sealed class MVVMListener : IWeakEventListener
    {
        #region Implementation of IWeakEventListener

        /// <summary>
        /// Receives events from the centralized event manager.
        /// </summary>
        /// <returns>
        /// true if the listener handled the event. It is considered an error by the <see cref="T:System.Windows.WeakEventManager"/> handling in WPF to register a listener for an event that the listener does not handle. Regardless, the method should return false if it receives an event that it does not recognize or handle.
        /// </returns>
        /// <param name="managerType">The type of the <see cref="T:System.Windows.WeakEventManager"/> calling this method.</param><param name="sender">Object that originated the event.</param><param name="e">Event data.</param>
        public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
