using CRUD_Opration.Data;
using CRUD_Opration.Models;
using CRUD_Opration.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Opration.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Add(AddStudentViewModel viewModel )
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribe = viewModel.Subscribe
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return View();
        }
    }
}
