using System.Collections.Generic;
using Business.Interfaces;
using Models;
using Models.Interfaces;

namespace Business
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void AddCustomer(Customer customerToAdd, bool isFromIntegrations = false)
        {
            _customerRepository.Add(customerToAdd);
            _customerRepository.SaveChanges(isFromIntegrations);
        }

        public void DeleteCustomer(Customer customerToDelete, bool isFromIntegrations = false)
        {
            _customerRepository.Delete(customerToDelete);
            _customerRepository.SaveChanges(isFromIntegrations);
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public void UpdateCustomer(bool isFromIntegrations)
        {
            _customerRepository.SaveChanges(isFromIntegrations);
        }
    }
}
