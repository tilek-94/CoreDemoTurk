using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController:Controller
    {
        public IActionResult Index()
        {
            return View();      
        }
        public IActionResult Test()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writer);
            return Json(jsonWriters);
        }
        public IActionResult DeleteWriter(int id)
        {
            var writers=writer.FirstOrDefault(x=>x.Id==id);
            writer.Remove(writers);
            return Json(writers);
        }
        public IActionResult UpdateWriter(WriterClass w)
        {
            var writers=writer.FirstOrDefault(x=>x.Id==w.Id);
            writers.Name = w.Name;
            var jsonWriter=JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }
        public IActionResult GetWriterByID(int writerId)
        {
            var findwriter = writer.FirstOrDefault(x=>x.Id==writerId);
            var jsonWriter=JsonConvert.SerializeObject(findwriter);
            return Json(jsonWriter);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            writer.Add(w);
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }
        public static List<WriterClass> writer = new List<WriterClass> {
        new WriterClass
        {
            Id=1,
            Name="TIlek"
        },
        new WriterClass
        {
            Id =2,
            Name="Asan"
        },
        new WriterClass
        {
            Id =3,
            Name="Samat"
        }
        };
    }
}
