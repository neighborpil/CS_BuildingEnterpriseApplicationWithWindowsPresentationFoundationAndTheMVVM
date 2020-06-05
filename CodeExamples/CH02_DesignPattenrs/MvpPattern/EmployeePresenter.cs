using System.Net.Http;
using CH02_DesignPattenrs.Model;
using CH02_DesignPattenrs.MvcPattern;

namespace CH02_DesignPattenrs.MvpPattern
{
    public sealed class EmployeePresenter
    {
        private IEmployeeView _view;

        public EmployeePresenter(IEmployeeView view)
        {
            _view = view;
        }

        /// <summary>
        /// 초기화한다
        /// </summary>
        public void Initialize()
        {
            var model = new Employee
            {
                FirstName = "John",
                LastName = "Smith",
                Company = "Microsoft"
            };

            UpdateViewFromModel(model);
        }

        /// <summary>
        /// 모델로부터 뷰를 업데이트 한다
        /// </summary>
        /// <param name="model"></param>
        private void UpdateViewFromModel(Employee model)
        {
            this._view.FirstName = model.FirstName;
            this._view.LastName = model.LastName;
            this._view.Company = model.Company;
        }
    }

    public partial class EmployeeView : /* Form, */ IEmployeeView
    {
        private EmployeePresenter presenter;

        public EmployeeView()
        {
            // InitializeComponent();
            this.presenter = new EmployeePresenter(this);
            this.presenter.Initialize();
        }

        private string txtFirstName;

        public string FirstName
        {
            get => txtFirstName;
            set => txtFirstName = value;
        }
        public string LastName { get; set; }
        public string Company { get; set; }
    }
}