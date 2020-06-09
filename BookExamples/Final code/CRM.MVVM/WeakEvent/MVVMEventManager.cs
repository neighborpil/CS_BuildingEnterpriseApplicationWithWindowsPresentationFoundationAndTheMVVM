using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CRM.MVVM.WeakEvent
{
    public sealed class MVVMEventManager : WeakEventManager
    {
        #region Overrides of WeakEventManager

        /// <summary>
        /// 
        /// </summary>
        private RoutedEventHandler handler = (s, e) =>
        {
            CurrentManager.DeliverEvent(s, e);
            return;
        };

        /// <summary>
        /// When overridden in a derived class, starts listening for the event being managed. After <see cref="M:System.Windows.WeakEventManager.StartListening(System.Object)"/>  is first called, the manager should be in the state of calling <see cref="M:System.Windows.WeakEventManager.DeliverEvent(System.Object,System.EventArgs)"/> or <see cref="M:System.Windows.WeakEventManager.DeliverEventToList(System.Object,System.EventArgs,System.Windows.WeakEventManager.ListenerList)"/> whenever the relevant event from the provided source is handled.
        /// </summary>
        /// <param name="source">The source to begin listening on.</param>
        protected override void StartListening(object source)
        {
            ((Button)source).Click += handler;
            return;
        }

        /// <summary>
        /// When overridden in a derived class, stops listening on the provided source for the event being managed.
        /// </summary>
        /// <param name="source">The source to stop listening on.</param>
        protected override void StopListening(object source)
        {
            ((Button)source).Click -= handler;
            return;
        }

        #endregion

        /// <summary>
        /// Gets the current manager.
        /// </summary>
        /// <value>The current manager.</value>
        public static MVVMEventManager CurrentManager
        {
            get
            {
                var manager_type = typeof(MVVMEventManager);
                var manager = WeakEventManager.GetCurrentManager(manager_type) as MVVMEventManager;

                if (manager == null)
                {
                    manager = new MVVMEventManager();
                    WeakEventManager.SetCurrentManager(manager_type, manager);
                }

                return manager;
            }
        }

        /// <summary>
        /// Adds the listner.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="listner">The listner.</param>
        public static void AddListner(object source, IWeakEventListener listner)
        {
            CurrentManager.ProtectedAddListener(source, listner);
        }

        /// <summary>
        /// Removes the listner.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="listner">The listner.</param>
        public static void RemoveListner(object source, IWeakEventListener listner)
        {
            CurrentManager.ProtectedRemoveListener(source, listner);
        }
    }
}
