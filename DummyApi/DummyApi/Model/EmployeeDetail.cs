namespace DummyApi.Model
{
    public class EmployeeDetail
    {
        private int empId;

        private string empName;

        private string empEmail;

        private int salary;

        public int EmpId { get => empId; set => empId = value; }
        public string EmpName { get => empName; set => empName = value; }
        public string EmpEmail { get => empEmail; set => empEmail = value; }
        public int Salary { get => salary; set => salary = value; }
    }
}
