using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZedBlog.Service.Services.Abstracts;
using ZedBlog.Web.Models;

namespace ZedBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogService blogService;

        public HomeController(ILogger<HomeController> logger, IBlogService blogService)
        {
            _logger = logger;
            this.blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await blogService.GetAllBlogsAsync();

            return View(blogs);
        }

        public IActionResult Test()
        {
            //var blogs = await blogService.GetAllBlogsAsync();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}