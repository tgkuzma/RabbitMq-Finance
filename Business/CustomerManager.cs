using System.Collections.Generic;
using Business.Interfaces;
using Models;
using Models.Interfaces;

namespace Business
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerCustomerRepository;

        public CustomerManager(ICustomerRepository customerCustomerRepository)
        {
            _customerCustomerRepository = customerCustomerRepository;
        }

        public void AddCustomer(Customer customerToAdd)
        {
            _customerCustomerRepository.Add(customerToAdd);
            _customerCustomerRepository.SaveChanges();
        }

        public void DeleteCustomer(Customer customerToDelete)
        {
            _customerCustomerRepository.Delete(customerToDelete);
            _customerCustomerRepository.SaveChanges();
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerCustomerRepository.GetAll();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerCustomerRepository.GetById(id);
        }

        public void UpdateCustomer()
        {
            _customerCustomerRepository.SaveChanges();
        }
    }
}
