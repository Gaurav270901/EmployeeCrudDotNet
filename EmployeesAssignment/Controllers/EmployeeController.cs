using AutoMapper;
using EmployeesAssignment.Data;
using EmployeesAssignment.Models.Domain;
using EmployeesAssignment.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeesAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public EmployeeController(ApplicationDbContext db , IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Employee> EmployeeDomain = await db.Employees.ToListAsync();
            var employeeList = mapper.Map<List<DisplayEmployeeDto>>(EmployeeDomain);
            return View(employeeList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddEmployeeDto employee)
        {
            if (ModelState.IsValid)
            {
                var employeeDomain = mapper.Map<Employee>(employee);
                await db.Employees.AddAsync(employeeDomain);
                await db.SaveChangesAsync();
                TempData["Success"] = "Employee Created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Employee? employeeFromDb = db.Employees.Find(id);
            if (employeeFromDb == null)
            {
                return NotFound();
            }
            
            var displayEmployee = mapper.Map<DisplayEmployeeDto>(employeeFromDb);

            
            return View(displayEmployee);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditEmployeeDto obj)
        {
            if (ModelState.IsValid)
            {
                var existingEmployee = db.Employees.Find(obj.EmployeeId);
                if (existingEmployee == null)
                {
                    return NotFound();
                }

                existingEmployee.FirstName = obj.FirstName;
                existingEmployee.LastName = obj.LastName;
                existingEmployee.BirthDate = obj.BirthDate;
                existingEmployee.Email = obj.Email;
                existingEmployee.EmploymentDate = obj.EmploymentDate;
                existingEmployee.Address = obj.Address;
                existingEmployee.City = obj.City;
                existingEmployee.State = obj.State;
                existingEmployee.Country = obj.Country;

                db.Employees.Update(existingEmployee);
                await db.SaveChangesAsync();

                TempData["Success"] = "Employee edited successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await db.Employees.FirstOrDefaultAsync(x=>x.EmployeeId== id);
            var employeeDto = mapper.Map<DisplayEmployeeDto> (employee);
            return View(employeeDto);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            Employee obj = await db.Employees.FindAsync(id);
            if (obj == null) { return NotFound(); }


            db.Employees.Remove(obj);

            await db.SaveChangesAsync();
            TempData["Sucess"] = "Employee deleted successfully";
            return RedirectToAction("Index");

        }
    }
}

