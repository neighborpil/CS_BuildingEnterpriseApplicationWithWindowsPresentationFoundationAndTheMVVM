using System;
using System.Windows;

namespace CRM.MVVM.Commanding
{
    public sealed class WeakEventManagerBase<TEventArgs> : IWeakEventListener where TEventArgs : EventArgs
    {
        private readonly EventHandler<TEventArgs> realHander;

        /// <summary>
        /// Initializes a new instance of the WeakEventListener class.
        /// </summary>
        /// <param name="handler">The handler for the event.</param>
        public WeakEventManagerBase(EventHandler<TEventArgs> handler)
        {
            if (handler == null)
            {
                throw new ArgumentNullException("handler");
            }

            realHander = handler;
        }

        #region IWeakEventListener Members

        /// <summary>
        /// Receives events from the centralized event manager.
        /// </summary>
        /// <param name="managerType">The type of the WeakEventManager calling this method.</param>
        /// <param name="sender">Object that originated the event.</param>
        /// <param name="e">Event data.</param>
        /// <returns>
        /// true if the listener handled the event. It is considered an error by the WeakEventManager handling in WPF to register a listener for an event that the listener does not handle. Regardless, the method should return false if it receives an event that it does not recognize or handle.
        /// </returns>
        bool IWeakEventListener.ReceiveWeakEvent(Type managerType, Object sender, EventArgs e)
        {
            var realArgs = (TEventArgs) e;

            realHander(sender, realArgs);

            return true;
        }

        #endregion
    }
}