using System.Collections.Generic;
using Models;

namespace Business.Interfaces
{
    public interface ICustomerManager
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void AddCustomer(Customer customerToAdd);
        void DeleteCustomer(Customer customerToDelete);
        void UpdateCustomer(bool isFromIntegrations = false);
    }
}