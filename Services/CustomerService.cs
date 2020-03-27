using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public class CustomerService : ICustomerService 
    {
        //private IList<Customer> _customers;

        //public CustomerService()
        //{
        //    _customers = new List<Customer>();
        //    _customers.Add(new Customer(1, "KinetEco"));
        //    _customers.Add(new Customer(2, "Pixelford Photography"));
        //    _customers.Add(new Customer(3, "Topsy Turvy"));
        //    _customers.Add(new Customer(4, "Leaf & Mortar"));

        //}
        //public Customer GetCustomeById(int id)
        //{
        //    return GetCustomerByIdAsync(id).Result;
        //}

        //public Task<Customer> GetCustomerByIdAsync(int id)
        //{
        //    return Task.FromResult(_customers.Single(o => Equals(o.Id, id)));
        //}

        public Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            List<Customer> customers = new List<Customer>();
            using (var context = new DB_context())
            {
                customers = context.Customers.ToList();
            }
            return Task.FromResult(customers.AsEnumerable());
        }
    }

    public interface ICustomerService
    {
        //Customer GetCustomeById(int id);
        //Task<Customer> GetCustomerByIdAsync(int id);
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}
