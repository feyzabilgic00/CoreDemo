using AutoMapper;
using BusinessLayer.Abstract;
using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog Id";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int blogRowCount = 2;
                foreach (var item in _blogService.GetAll())
                {
                    workSheet.Cell(blogRowCount, 1).Value = item.Id;
                    workSheet.Cell(blogRowCount, 2).Value = item.Title;
                    blogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Çalışma1.xlsx");
                }
            }
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("Blog Listesi");
                workSheet.Cell(1, 1).Value = "Blog Id";
                workSheet.Cell(1, 2).Value = "Blog Adı";

                int blogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    workSheet.Cell(blogRowCount, 1).Value = item.Id;
                    workSheet.Cell(blogRowCount, 2).Value = item.BlogName;
                    blogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Çalışma1.xlsx");
                }
            }
        }
        public List<BlogStaticModel> GetBlogList()
        {
            List<BlogStaticModel> blogModels = new List<BlogStaticModel>
            {
                new BlogStaticModel{ Id = 1, BlogName = "C# Programlama"},
                new BlogStaticModel{ Id = 2, BlogName = "Tesle Firmasının Araçları Programlama"},
                new BlogStaticModel{ Id = 3, BlogName = "2020 Olimpiyatları"},
            };
            return blogModels;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }  
    }
}
