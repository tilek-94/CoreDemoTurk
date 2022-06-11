using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class EmployeeTestController : Controller
    {
        public async Task< IActionResult> Index()
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44328/api/Default");
            var jsonString=await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(value);
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 class1)
        {
            var httpClint=new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(class1);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8,"application/json");
            var responseMessage = await httpClint.PostAsync("https://localhost:44328/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(class1);
        }
        [HttpGet]
        public async Task<IActionResult> EditEmployee(int id)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44328/api/Default/"+id);

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<Class1>(jsonString);
                return View(value);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            var content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PutAsync("https://localhost:44328/api/Default", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
           return View(p);
        }
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            HttpClient httpClient = new HttpClient();
            var responseMessage = await httpClient.DeleteAsync("https://localhost:44328/api/Default/" + id);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
    public class Class1
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
