using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using ThucHanh_1_2_3.Models;

namespace ThucHanh_1_2_3.Controllers
{
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private List<Student> students = new List<Student>();
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
            students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Nguyen Van An",
                    Email = "an.nguyen@gmail.com",
                    Password = "AnNguyen@123",
                    Branch = Branch.IT,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "Hanoi, Vietnam",
                    DateOfBirth = new DateOnly(2000, 5, 12)
                },
                new Student
                {
                    Id = 2,
                    Name = "Tran Thi Binh",
                    Email = "binh.tran@gmail.com",
                    Password = "BinhTran!456",
                    Branch = Branch.BE,
                    Gender = Gender.Female,
                    IsRegular = false,
                    Address = "Ho Chi Minh City, Vietnam",
                    DateOfBirth = new DateOnly(2001, 8, 25)
                },
                new Student
                {
                    Id = 3,
                    Name = "Pham Duc Huy",
                    Email = "huy.pham@gmail.com",
                    Password = "HuyPham#789",
                    Branch = Branch.CE,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "Da Nang, Vietnam",
                    DateOfBirth = new DateOnly(1999, 12, 3)
                },
                new Student
                {
                    Id = 4,
                    Name = "Le Ngoc Mai",
                    Email = "mai.le@gmail.com",
                    Password = "MaiLe$123",
                    Branch = Branch.EE,
                    Gender = Gender.Female,
                    IsRegular = true,
                    Address = "Hue, Vietnam",
                    DateOfBirth = new DateOnly(2002, 3, 17)
                }
            };

        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index", students);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost("Create")]
        public IActionResult Create(Student s)
        {
            s.Id = students.Last().Id + 1;
            students.Add(s);
            return View("Index", students);
        }
    }
}