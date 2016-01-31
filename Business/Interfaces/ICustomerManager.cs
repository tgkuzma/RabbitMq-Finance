using System.Collections.Generic;
using Models;

namespace Business.Interfaces
{
    public interface ICustomerManager
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void AddCustomer(Customer customerToAdd, bool isFromIntegrations = false);
        void DeleteCustomer(Customer customerToDelete, bool isFromIntegrations = false);
        void UpdateCustomer(bool isFromIntegrations = false);
    }
}