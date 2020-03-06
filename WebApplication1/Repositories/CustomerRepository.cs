using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using AutoMapper;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class CustomerRepository
    {
        private readonly WebAppContext _context;

        public CustomerRepository(WebAppContext context)
        {
            _context = context;
        }

        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.Include(c => c.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }

        public List<MembershipType> GetMembershipTypes()
        {
            return _context.MembershipTypes.ToList();
        }


        public Customer GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
            
        }

        public void DeleteCustomer(int id)
        {
            var customer = GetCustomerById(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        public IEnumerable<Customer> GetBirthDateCustomers()
        {
            var today = DateTime.Today;
            var todayBirth = _context.Customers.Where(b => b.BirthDate.Value.Day == today.Day && b.BirthDate.Value.Month == today.Month).ToList();

            return todayBirth;
        }
    }
}