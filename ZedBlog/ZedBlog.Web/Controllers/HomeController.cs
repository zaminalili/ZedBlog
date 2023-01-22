using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZedBlog.Service.Services.Abstract;
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

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Test()
        {
            var blogs = await blogService.GetAllBlogAsync();
            return View(blogs);
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