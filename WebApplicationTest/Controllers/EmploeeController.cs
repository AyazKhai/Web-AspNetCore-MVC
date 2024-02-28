using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using Newtonsoft.Json;
using WebApplicationTest.Models;
using WebApplicationTest.Models.MvcApp.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.IO;
using System.Text.Json;
using System.Text;

namespace WebApplicationTest.Controllers
{
    public class EmploeeController : Controller
    {
        private readonly ApplicationContext _context;
        public EmploeeController(ApplicationContext context) 
        {
            _context = context;
        }
        public ActionResult Create()//Создание пользователья
        {
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Create(Emploee emploee)
        {
            _context.Emploees.Add(emploee);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Работник успешно добавлен";
            return RedirectToAction("Create");
           
        }

        [NonAction]
        public async Task<IActionResult> GetEmployees(string? FName, string? LName)
        {
            IQueryable<Emploee> empls = _context.Emploees;

            if (!string.IsNullOrWhiteSpace(FName))
            {
                empls = empls.Where(p => p.FName.Contains(FName));
            }

            if (!string.IsNullOrWhiteSpace(LName))
            {
                empls = empls.Where(p => p.LName.Contains(LName));
            }

            IndexViewModel viewModel = new IndexViewModel
            {
                Emploees = await empls.ToListAsync(),
            };

            return View(viewModel);
            //IQueryable<Emploee> empls = _context.Emploees.Include(p => p.FName);
            //if (FName != null && FName != " ")
            //{
            //    empls = empls.Where(p => p.FName == FName);
            //}
            //if (!string.IsNullOrEmpty(FName))
            //{
            //    empls = empls.Where(p => p.FName!.Contains(FName));
            //}

            ////List<Company> companies = db.Companies.ToList();
            ////// устанавливаем начальный элемент, который позволит выбрать всех
            ////companies.Insert(0, new Company { Name = "Все", Id = 0 });

            //IndexViewModel viewModel = new IndexViewModel
            //{
            //    Emploees = empls.ToList(),
            //    //Users = users.ToList(),
            //    //Companies = new SelectList(companies, "Id", "Name", company),
            //    //Name = name
            //};
            //return (IActionResult)viewModel;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees(string? FName, string? LName, SortState sortOrder = SortState.FNameAsc)
        {
            TempData["FName"] = FName;
            TempData["LName"] = LName;
            IQueryable<Emploee> users = _context.Emploees;

            // Фильтрация по имени
            if (!string.IsNullOrWhiteSpace(FName))
            {
                users = users.Where(s => s.FName.Contains(FName));
            }

            // Фильтрация по фамилии
            if (!string.IsNullOrWhiteSpace(LName))
            {
                users = users.Where(s => s.LName.Contains(LName));
            }

            // Применение сортировки
            users = sortOrder switch
            {
                SortState.FNameDesc => users.OrderByDescending(s => s.FName),
                SortState.LNameAsc => users.OrderBy(s => s.LName),
                SortState.LNameDesc => users.OrderByDescending(s => s.LName),
                SortState.EmailAsc => users.OrderBy(s => s.Email),
                SortState.EmailDesc => users.OrderByDescending(s => s.Email),
                SortState.DateOfHireAsc => users.OrderBy(s => s.DateOfHire),
                SortState.DateOfHireDesc => users.OrderByDescending(s => s.DateOfHire),
                SortState.DateOfBirthAsc => users.OrderBy(s => s.DateOfBirth),
                SortState.DateOfBirthDesc => users.OrderByDescending(s => s.DateOfBirth),
                SortState.PositionAsc => users.OrderBy(s => s.Position),
                SortState.PositionDesc => users.OrderByDescending(s => s.Position),
                SortState.AddressAsc => users.OrderBy(s => s.Address),
                SortState.AddressDesc => users.OrderByDescending(s => s.Address),
                SortState.CityAsc => users.OrderBy(s => s.City),
                SortState.CityDesc => users.OrderByDescending(s => s.City),
                SortState.RegionAsc => users.OrderBy(s => s.Region),
                SortState.RegionDesc => users.OrderByDescending(s => s.Region),
                _ => users.OrderBy(s => s.FName),
            };

            IndexViewModel viewModel = new IndexViewModel
            {
                Emploees = await users.AsNoTracking().ToListAsync(),
                SortViewModel = new SortViewModel(sortOrder)
            };

            return View(viewModel);

            //IQueryable<Emploee> users = _context.Emploees;

            //users = sortOrder switch
            //{
            //    SortState.FNameDesc => users.OrderByDescending(s => s.FName),
            //    SortState.LNameAsc => users.OrderBy(s => s.LName),
            //    SortState.LNameDesc => users.OrderByDescending(s => s.LName),
            //    SortState.EmailAsc => users.OrderBy(s => s.Email),
            //    SortState.EmailDesc => users.OrderByDescending(s => s.Email),
            //    SortState.DateOfHireAsc => users.OrderBy(s => s.DateOfHire),
            //    SortState.DateOfHireDesc => users.OrderByDescending(s => s.DateOfHire),
            //    SortState.DateOfBirthAsc => users.OrderBy(s => s.DateOfBirth),
            //    SortState.DateOfBirthDesc => users.OrderByDescending(s => s.DateOfBirth),
            //    SortState.PositionAsc => users.OrderBy(s => s.Position),
            //    SortState.PositionDesc => users.OrderByDescending(s => s.Position),
            //    SortState.AddressAsc => users.OrderBy(s => s.Address),
            //    SortState.AddressDesc => users.OrderByDescending(s => s.Address),
            //    SortState.CityAsc => users.OrderBy(s => s.City),
            //    SortState.CityDesc => users.OrderByDescending(s => s.City),
            //    SortState.RegionAsc => users.OrderBy(s => s.Region),
            //    SortState.RegionDesc => users.OrderByDescending(s => s.Region),
            //    _ => users.OrderBy(s => s.FName),
            //};

            //IndexViewModel viewModel = new IndexViewModel
            //{
            //    Emploees = await users.AsNoTracking().ToListAsync(),
            //    SortViewModel = new SortViewModel(sortOrder)
            //};

            //return View(viewModel);
        }


     
        /*Стоит отметить, что данный метод Delete обрабатывает только запросы типа POST. Почему? Дело в том, что использование get-методов не безопасно. Например, нам могут прислать письмо с картинкой:
                <img src="http://адрес_нашего_сайта/Home/Delete/1" />
                    И при открытии письма на сервер будет отправлен get-запрос. И если бы метод Delete обрабатывал бы get-запросы, то объект с id=1 был бы удален из базы данных.*/
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Emploee emploee = new Emploee { Id = id.Value };
                _context.Entry(emploee).State = EntityState.Deleted;// Это выражение опять же сгенерирует sql-выражение DELETE.
                await _context.SaveChangesAsync();
                return RedirectToAction("GetEmployees");
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Emploee? emploee = await _context.Emploees.FirstOrDefaultAsync(p => p.Id == id);
                if (emploee != null) return View(emploee);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Emploee emploee)
        {
            _context.Emploees.Update(emploee);
            await _context.SaveChangesAsync();
            return RedirectToAction("GetEmployees");
        }
        public async Task<IActionResult> DownloadFile(int? id)
        {
            try
            {
                if (id != null)
                {
                    Emploee? emploee = await _context.Emploees.FirstOrDefaultAsync(p => p.Id == id);

                    if (emploee != null)
                    {
                        // Сериализация объекта в JSON
                        string jsonString = JsonSerializer.Serialize(emploee);

                        // Создаем уникальное имя файла
                        string fileName = $"employee_{id}_{DateTime.Now:yyyyMMddHHmmss}.json";

                        // Записываем JSON в массив байтов
                        byte[] fileContents = Encoding.UTF8.GetBytes(jsonString);

                        // Возвращаем файловый поток клиенту
                        return File(fileContents, "application/json", fileName);
                    }
                }

                return NotFound("Employee not found with the provided id.");
            }
            catch (Exception ex)
            {
                // Обработка ошибок, если необходимо
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    

        [HttpPost]
        public async Task<IActionResult> DownloadAllEmploees([FromForm] IndexViewModel model)
        {
            try
            {
                // Получаем массив id из модели
                int[] employeeIds = model.EmployeeIds;

                // Получаем объекты Emploee из базы данных
                var employees = await _context.Emploees
                    .Where(e => employeeIds.Contains(e.Id))
                    .ToListAsync();

                if (employees.Any())
                {
                    // Сериализуем объекты Emploee в JSON
                    string jsonString = JsonSerializer.Serialize(employees);

                    // Получаем уникальное имя файла
                    string fileName = $"all_employees_forusers{DateTime.Now:yyyyMMddHHmmss}.json";

                    // Составляем путь для сохранения файла на стороне клиента
                    string filePath = Path.Combine("Saves", fileName);

                    // Возвращаем файл для скачивания на стороне клиента
                    return File(Encoding.UTF8.GetBytes(jsonString), "application/json", fileName);
                }

                return NotFound("No employees found with the provided ids.");
            }
            catch (Exception ex)
            {
                // Обработка ошибок, если необходимо
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
