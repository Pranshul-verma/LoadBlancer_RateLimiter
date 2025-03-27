namespace DummyApi.Model
{
    public interface IEmployeeDetail
    {
        string EmpEmail { get; set; }
        int EmpId { get; set; }
        string EmpName { get; set; }
        int Salary { get; set; }
    }
}