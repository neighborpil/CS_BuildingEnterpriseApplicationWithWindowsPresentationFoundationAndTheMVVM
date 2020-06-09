using System;

namespace CRM.MVVM.ViewModel
{
    public class BaseViewModel<T> : ObservableObject<BaseViewModel<T>> where T : class
    {
        public T model;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public BaseViewModel(T model)
        {
            this.model = model;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public virtual string Title
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>The model.</value>
        public T Model
        {
            get { return model; }
            set
            {
                if (model == value)
                {
                    return;
                }
                model = value;
                OnPropertyChanged(vm => vm.Model);
            }
        }

        /// <summary>
        /// Gets the <see cref="System.String"/> with the specified column name.
        /// </summary>
        /// <value></value>
        public virtual string this[string columnName]
        {
            get
            {
                return ViewModelValidator.ValidateField(this, columnName);
            }
        }

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <value></value>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }
}