namespace LTW_Day05Lab_TH.Models
{
    public enum employeeStatus
    {
        Active,
        Inactive,
    }

    public class Employee
    {
        public string id;
        public string fullName;
        public int gender;
        public string phone;
        public string email;
        public float salary;
        public employeeStatus status;
    }
}
