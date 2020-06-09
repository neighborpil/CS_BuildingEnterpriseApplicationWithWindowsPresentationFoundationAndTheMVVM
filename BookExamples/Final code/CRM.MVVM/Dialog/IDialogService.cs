using System;

namespace CRM.MVVM.Dialog
{
    public interface IDialogService
    {
        /// <summary>
        /// Shows the dialog message.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        bool? ShowDialogMessage(string title, string message);

        /// <summary>
        /// Shows the dialog view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        bool? ShowDialogView(object view, object viewModel);

        /// <summary>
        /// Shows the message.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        void ShowMessage(string title, string message);

        /// <summary>
        /// Shows the view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="viewModel">The view model.</param>
        void ShowView(object view, object viewModel);
    }
}