using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CRM.MVVM.ViewModel
{
    public abstract class ObservableObject<T> : INotifyPropertyChanged
    {
        #region Implementation of INotifyPropertyChanged

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="property">The property.</param>
        protected virtual void OnPropertyChanged(Expression<Func<T, object>> property)
        {
            if (property == null || property.Body == null)
            {
                return;
            }

            var memberExp = property.Body as MemberExpression;
            if (memberExp == null)
            {
                return;
            }

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(memberExp.Member.Name));
            }
        }

        #endregion
    }
}