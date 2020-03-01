using System.Data.Entity;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerRepository _custumeRepository;
        private readonly WebAppContext _context;
        
        public CustomersController()
        {
            _context = new WebAppContext();
            _custumeRepository = new CustomerRepository(_context);
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _custumeRepository.GetCustomers();
            return View(customers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var customerViewModel = new CustomersViewModel();
            var membershipType = _custumeRepository.GetMembershipTypes();
            customerViewModel.MembershipTypes = membershipType;
            customerViewModel.Customer = new Customer();        
            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
           return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customerViewModel = new CustomersViewModel
            {
                Customer = _custumeRepository.GetCustomerById(id),
                MembershipTypes = _custumeRepository.GetMembershipTypes()
            };
            return View(customerViewModel);
        }


        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(customer).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
            _custumeRepository.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}