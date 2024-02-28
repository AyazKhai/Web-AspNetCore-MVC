using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplicationTest.Controllers
{
    public class TestController : Controller
    {

        public IActionResult Index() 
        {
            return View();
        }

        //public async Task Index()
        //{
        //    string content = @"<form method='post' action='/Test/PersonData '>
        //           <label>Name:</label><br />
        //        <input name='name' /><br />
        //        <label>Age:</label><br />
        //        <input type='number' name='age' /><br />
        //        <input type='submit' value='Send' />
        //    </form>";
        //    Response.ContentType = "text/html;charset=utf-8";
        //    await Response.WriteAsync(content);
        //}
        //[HttpPost]
        //public string PersonData()
        //{
        //    string name = Request.Form["name"];
        //    string age = Request.Form["age"];
        //    return $"{name}: {age}";
        //}

        //public IActionResult Index2()
        //{
        //    return new BadRequestResult();
        //}
        //public ContentResult IndexActionres()
        //{
        //    return Content("Hello METANIT.COM");
        //}

        //public PhysicalFileResult GetFile()
        //{
        //    // Путь к файлу
        //    string file_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/Hello.txt");
        //    // Тип файла - content-type
        //    string file_type = "text/plain";
        //    // Имя файла - необязательно
        //    string file_name = "hello.txt";
        //    return PhysicalFile(file_path, file_type, file_name);
        //}

        //public IActionResult GetBytes()
        //{
        //    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/Hello.txt");
        //    byte[] mas = System.IO.File.ReadAllBytes(path);
        //    string file_type = "text/plain";
        //    string file_name = "hello2.txt";
        //    return File(mas, file_type, file_name);
        //}

        //public IActionResult GetStream()
        //{
        //    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/Hello.txt");
        //    FileStream fs = new FileStream(path, FileMode.Open);
        //    string file_type = "text/plain";
        //    string file_name = "hello3.txt";
        //    return File(fs, file_type, file_name);
        //}

        //public class Dick : FileResult
        //{
        //    public Dick(string contentType) : base(contentType)
        //    {
        //    }
        //}
        //[HttpGet]
        // public async Task Index()
        // {
        //     string content = @"<form method='post'>
        //         <label>Name:</label><br />
        //         <input name='name' /><br />
        //         <label>Age:</label><br />
        //         <p><input name='names' /></p>
        //         <p><input name='names' /></p>
        //         <p><input name='names' /></p>
        //         <input type='number' name='age' /><br />
        //         <input type='submit' value='Send' />
        //     </form>";
        //     Response.ContentType = "text/html;charset=utf-8";
        //     await Console.Out.WriteLineAsync("Get method");
        //     await Response.WriteAsync(content);
        // }
        // [HttpPost]
        // public string Index(string[] names) 
        // {
        //     Console.WriteLine("Post method");
        //     string result = "";
        //     foreach (string name in names)
        //     {
        //         result = $"{result} {name}";
        //     }
        //     return result;
        // }
    }
}
