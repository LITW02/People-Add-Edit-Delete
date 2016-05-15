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

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitNew(string firstName, string lastName, int age)
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

        public ActionResult Edit(int personId)
        {
            PeopleManager manager = new PeopleManager(Properties.Settings.Default.ConStr);
            Person person = manager.GetById(personId);
            return View(person);
        }

        [HttpPost]
        public ActionResult Update(string firstName, string lastName, int age, int id)
        {
            PeopleManager manager = new PeopleManager(Properties.Settings.Default.ConStr);
            manager.Update(new Person
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Id = id
            });

            return Redirect("/people/index");
        }

    }
}
