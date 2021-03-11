using System;
using System.Linq;
using Assignment5.Models;
using Microsoft.AspNetCore.Mvc;
namespace Assignment5.Components
{
    public class NavigationMenuViewComponents : ViewComponent
    {
        private IDaintreeRepository repository;

        //accessing database repository
        public NavigationMenuViewComponents (IDaintreeRepository r)
        {
            repository = r;


        }

        //gathering all distinct classifications
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["category"];

            return View(repository.Books
                .Select(x => x.Classification)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
