using System;
using System.Linq;
using System.Text;
using Business.Interfaces;
using Models;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using SharedCustomer = Models.Shared.Customer;

namespace Integrations.ReceiveingEvents
{
    public class SharedIntegrationEvents
    {
        private readonly ICustomerManager _customerManager;

        public SharedIntegrationEvents(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        public EventHandler<BasicDeliverEventArgs> GetCustomerAddedHandler()
        {
            return (model, ea) =>
            {
                var sharedCustomer = JsonConvert.DeserializeObject<SharedCustomer>(Encoding.UTF8.GetString(ea.Body));
                var customer = _customerManager.GetCustomerById(sharedCustomer.IntegrationObjectId);
                if (customer == null)
                {
                    AddCustomer(sharedCustomer);
                    Console.WriteLine("Finance customer (from Shared) with name {0} added", sharedCustomer.FullName);
                }
                else
                {
                    UpdateCustomer(sharedCustomer, customer);
                    Console.WriteLine("Finance customer with name {0} updated", sharedCustomer.FullName);
                }
            };
        }

        public EventHandler<BasicDeliverEventArgs> GetCustomerModifiedHandler()
        {
            return (model, ea) =>
            {
                var sharedCustomer = JsonConvert.DeserializeObject<SharedCustomer>(Encoding.UTF8.GetString(ea.Body));
                var customer = _customerManager.GetAllCustomers().FirstOrDefault(mi => mi.MasterId == sharedCustomer.Id);

                UpdateCustomer(sharedCustomer, customer);
                
                Console.WriteLine("Finance customer with name {0} updated", sharedCustomer.FullName);
            };
        }

        public EventHandler<BasicDeliverEventArgs> GetCustomerDeletedHandler()
        {
            return (model, ea) =>
            {
                var sharedCustomer = JsonConvert.DeserializeObject<SharedCustomer>(Encoding.UTF8.GetString(ea.Body));
                var customer = _customerManager.GetAllCustomers().FirstOrDefault(mi => mi.MasterId == sharedCustomer.Id);

                _customerManager.DeleteCustomer(customer, true);

                Console.WriteLine("Finance customer with name {0} deleted", sharedCustomer.FullName);
            };
        }

        private void AddCustomer(SharedCustomer sharedCustomer)
        {
            var customer = new Models.Customer
            {
                BillingAddress = sharedCustomer.BillingAddress,
                FirstName = sharedCustomer.FullName.Split(Convert.ToChar(" "))[0],
                LastName = sharedCustomer.FullName.Split(Convert.ToChar(" "))[1],
                MasterId = sharedCustomer.Id
            };

            _customerManager.AddCustomer(customer, true);
        }

        private void UpdateCustomer(SharedCustomer sharedCustomer, Customer customer)
        {
            customer.BillingAddress = sharedCustomer.BillingAddress;
            customer.FirstName = sharedCustomer.FullName.Split(Convert.ToChar(" "))[0];
            customer.LastName = sharedCustomer.FullName.Split(Convert.ToChar(" "))[1];
            customer.MasterId = sharedCustomer.Id;
            _customerManager.UpdateCustomer(true);
        }
    }
}