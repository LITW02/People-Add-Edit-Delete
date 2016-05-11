using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication18.Models;

namespace MvcApplication18.Controllers
{
    public class PeopleController : Controller
    {
        public ActionResult Index()
        {
            PeopleManager manager = new PeopleManager(Properties.Settings.Default.ConStr);
            return View(manager.GetAll());
        }

        [HttpPost]
        public ActionResult Add(string firstName, string lastName, int age)
        {
            PeopleManager manager = new PeopleManager(Properties.Settings.Default.ConStr);
            manager.Add(new Person
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age
            });

            return Redirect("/people/index");
        }

        public ActionResult Delete(int personId)
        {
            PeopleManager manager = new PeopleManager(Properties.Settings.Default.ConStr);
            manager.Delete(personId);
            return Redirect("/people/index");
        }

    }
}
