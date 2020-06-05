namespace CH02_DesignPattenrs.MvpPattern
{
    public interface IEmployeeView
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        string Company { get; set; }
    }
}