using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Assignment5.Models;
using Assignment5.Models.ViewModels;

namespace Assignment5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IDaintreeRepository _repository;

        public int PageSize = 5;

        public HomeController(ILogger<HomeController> logger, IDaintreeRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int pg = 1)
        {
            return View(new ProjectListViewModel
            {
                Books = _repository.Books
                    .Where(p => category == null || p.Classification == category)
                    .OrderBy(p => p.BookID)
                    .Skip((pg - 1) * PageSize)
                    .Take(PageSize)
                    ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pg,
                    ItemsPerPage = PageSize,
                    TotalNumItems = category == null ? _repository.Books.Count() : _repository.Books.Where(x => x.Classification == category).Count()
                },
                CurrentCategory = category,
            });
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
