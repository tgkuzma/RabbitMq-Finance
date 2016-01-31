using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Business.Interfaces;
using Models;

namespace Finance
{
    public partial class Form1 : Form
    {
        private readonly ICustomerManager _customerManager;
        private List<Customer> _customersToUpdate;
        private List<Customer> _customersToDelete;

        public Form1(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            _customerManager.AddCustomer(new Customer
            {
                BillingAddress = new Address
                {
                    City = txtCreateCity.Text,
                    State = txtCreateState.Text,
                    Street = txtCreateStreetAddress.Text,
                    ZipCode = txtCreateZipCode.Text
                },
                FirstName = txtCreateFirstName.Text,
                LastName = txtCreateLastName.Text
            });

            LoadCustomersToDelete();
            LoadCustomersToUpdate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadCustomersToUpdate();
            LoadCustomersToDelete();
        }

        private void LoadCustomersToDelete()
        {
            _customersToDelete = _customerManager.GetAllCustomers();
            var customer = _customersToDelete.FirstOrDefault();
            HydrateDeleteGroup(customer);
        }

        private void HydrateDeleteGroup(Customer customer)
        {
            txtDeleteAddress.Text = customer.BillingAddress.Street;
            txtDeleteCity.Text = customer.BillingAddress.City;
            txtDeleteFirstName.Text = customer.FirstName;
            txtDeleteLastName.Text = customer.LastName;
            txtDeleteState.Text = customer.BillingAddress.State;
            txtDeleteZipCode.Text = customer.BillingAddress.ZipCode;
        }

        private void HydrateUpdateGroup(Customer customer)
        {
            txtUpdateAddress.Text = customer.BillingAddress.Street;
            txtUpdateCity.Text = customer.BillingAddress.City;
            txtUpdateFirstName.Text = customer.FirstName;
            txtUpdateLastName.Text = customer.LastName;
            txtUpdateState.Text = customer.BillingAddress.State;
            txtUpdateZipCode.Text = customer.BillingAddress.ZipCode;
        }

        private void LoadCustomersToUpdate()
        {
            _customersToUpdate = _customerManager.GetAllCustomers();
            var customer = _customersToUpdate.FirstOrDefault();
            HydrateUpdateGroup(customer);
        }
    }
}
