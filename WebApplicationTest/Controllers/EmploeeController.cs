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
using Microsoft.CodeAnalysis.CSharp.Syntax;

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

        
        [HttpGet]
        public async Task<IActionResult> GetEmployees(string? FName, string? LName, string minstanding, SortState sortOrder = SortState.FNameAsc)
        {
            TempData["FName"] = FName;
            TempData["LName"] = LName;
            TempData["minstanding"] = minstanding;
            IQueryable<Emploee> users = _context.Emploees;
            //DateTime standingDate = DateTime.Now.AddMonths(Convert.ToInt32(standing) * (-1));
            DateTime standingDate = DateTime.Now.AddYears(Convert.ToInt32(minstanding)*(-1));
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
            // Фильтрация по стажу
            if (minstanding != "0"|| minstanding != null)
            {
                users = users.Where(s => s.DateOfHire < standingDate);
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

        [HttpPost]
        public async Task<IActionResult> UploadJsonFile(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    @TempData["NoFileMessage"] = "Пожалуйста выберите файл";
                   return RedirectToAction("GetEmployees");
                }
               
                using (var streamReader = new StreamReader(file.OpenReadStream()))
                {
                    var jsonString = await streamReader.ReadToEndAsync();

                    // Десериализация JSON
                    var employees = JsonSerializer.Deserialize<List<Emploee>>(jsonString);
                    if (employees != null && employees.Any())
                    {
                        // Устанавливаем Id в 0 для каждого объекта
                        foreach (var employee in employees)
                        {
                            employee.Id = 0;
                        }

                        // Добавление данных в базу данных
                        _context.Emploees.AddRange(employees);
                        await _context.SaveChangesAsync();
                        TempData["SuccessMessage"] = "Успешно добавлено";
                        return RedirectToAction("GetEmployees");
                        //return Ok("Данные успешно добавлены в базу данных.");
                    }
                    else
                    {
                        @TempData["ErrorMessage"] = "Ошибка";
                        return RedirectToAction("GetEmployees");
                    }
                }
            }
            catch (Exception ex)
            {
                @TempData["ErrorMessage"] = "Ошибка";
                return RedirectToAction("GetEmployees");
            }
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
                        string jsonString = JsonSerializer.Serialize(new[] { emploee });

                        // Создаем уникальное имя файла
                        string fileName = $"employee_{emploee.FName}_{emploee.LName}_{DateTime.Now:yyyyMMddHHmmss}.json";

                        //// Записываем JSON в массив байтов
                        //byte[] fileContents = Encoding.UTF8.GetBytes(jsonString);

                        // Возвращаем файловый поток клиенту
                        return File(Encoding.UTF8.GetBytes(jsonString), "application/json", fileName);
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
