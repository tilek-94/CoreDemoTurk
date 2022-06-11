using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController:Controller
    {
        private readonly BlogManager bm = new(new EfBlogRepository());
        public IActionResult ExportStaticExcelBlogList()
        {
            List<Blog> blogList = bm.GetList();
            using(var workbook=new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Категори блоков");
                worksheet.Cell(1,1).Value = "ID";
                worksheet.Cell(1,2).Value = "Имя блоков";
               int BlogRowCount = 2;
                foreach(var item in blogList)
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.BlogID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogTitle;
                    BlogRowCount++;
                }
                using(var stream=new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content= stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }

            }
           
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }

    }
}
