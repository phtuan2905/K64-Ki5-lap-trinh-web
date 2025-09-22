using LTW_Day05Lab_TH.Models;
using Microsoft.AspNetCore.Mvc;

namespace LTW_Day05Lab_TH.Controllers
{
    public class ManagerController : Controller
    {
        public List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                id = "001",
                fullName = "Nguyễn Văn A",
                gender = 1,
                phone = "0901234567",
                email = "a.nguyen@example.com",
                salary = 1000,
                status = employeeStatus.Active,
            },
            new Employee()
            {
                id = "002",
                fullName = "Trần Thị B",
                gender = 0,
                phone = "0901234567",
                email = "b.tran@example.com",
                salary = 1200,
                status = employeeStatus.Inactive,
            },
            new Employee()
            {
                id = "003",
                fullName = "Lê Văn C",
                gender = 1,
                phone = "0901234567",
                email = "c.le@example.com",
                salary = 9000,
                status = employeeStatus.Active,
            }
        };

        public IActionResult Employees()
        {
            return View(employees);
        }
    }
}
