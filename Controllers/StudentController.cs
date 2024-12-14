using CRUD_Opration.Data;
using CRUD_Opration.Models;
using CRUD_Opration.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        //saving data to the sql database 
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

        [HttpGet]
        public  async Task<IActionResult> list()
        {
            var student = await dbContext.Students.ToListAsync();
            return View(student);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) {
            var student = await dbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.Id);
            if(student is not null )
            {
            student.Name = viewModel.Name;
            student.Email = viewModel.Email;
            student.Phone = viewModel.Phone;
            student.Subscribe = viewModel.Subscribe;

             await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("list", "Student");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await dbContext.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (student is not null)
            {
                dbContext.Remove(student);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("list", "Student");
        }
    }
}
