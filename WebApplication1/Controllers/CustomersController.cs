using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {
        WebAppContext db = new WebAppContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.ToList();
            return View(customers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var customerViewModel = new CustomersViewModel();
            var membershipType = db.MembershipTypes.ToList();
            customerViewModel.MembershipTypes = membershipType;
            customerViewModel.Customer = new Customer();        
            return View(customerViewModel);
        }


        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
            }
           return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }

    }
}