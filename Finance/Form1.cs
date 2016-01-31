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
            lblDeleteId.Text = customer.Id.ToString();
        }

        private void HydrateUpdateGroup(Customer customer)
        {
            txtUpdateAddress.Text = customer.BillingAddress.Street;
            txtUpdateCity.Text = customer.BillingAddress.City;
            txtUpdateFirstName.Text = customer.FirstName;
            txtUpdateLastName.Text = customer.LastName;
            txtUpdateState.Text = customer.BillingAddress.State;
            txtUpdateZipCode.Text = customer.BillingAddress.ZipCode;
            lblUpdateId.Text = customer.Id.ToString();
        }

        private void LoadCustomersToUpdate()
        {
            _customersToUpdate = _customerManager.GetAllCustomers();
            var customer = _customersToUpdate.FirstOrDefault();
            HydrateUpdateGroup(customer);
        }

        private void btnUpdateNext_Click(object sender, EventArgs e)
        {
            var customer = _customersToUpdate.FirstOrDefault(i => i.Id > Convert.ToInt32(lblUpdateId.Text));
            if (customer != null)
            {
                HydrateUpdateGroup(customer);
            }
        }

        private void btnUpdatePrevious_Click(object sender, EventArgs e)
        {
            var customer = _customersToUpdate.LastOrDefault(i => i.Id < Convert.ToInt32(lblUpdateId.Text));
            if (customer != null)
            {
                HydrateUpdateGroup(customer);
            }
        }

        private void btnDeleteNext_Click(object sender, EventArgs e)
        {
            var customer = _customersToDelete.FirstOrDefault(i => i.Id > Convert.ToInt32(lblDeleteId.Text));
            if (customer != null)
            {
                HydrateDeleteGroup(customer);
            }
        }

        private void btnDeletePrevious_Click(object sender, EventArgs e)
        {
            var customer = _customersToDelete.LastOrDefault(i => i.Id < Convert.ToInt32(lblDeleteId.Text));
            if (customer != null)
            {
                HydrateDeleteGroup(customer);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var customerToUpdate = _customersToUpdate.FirstOrDefault(i => i.Id == Convert.ToInt32(lblUpdateId.Text));

             customerToUpdate.BillingAddress.Street = txtUpdateAddress.Text;
             customerToUpdate.BillingAddress.City = txtUpdateCity.Text;
             customerToUpdate.FirstName= txtUpdateFirstName.Text;
             customerToUpdate.LastName = txtUpdateLastName.Text;
             customerToUpdate.BillingAddress.State = txtUpdateState.Text;
             customerToUpdate.BillingAddress.ZipCode = txtUpdateZipCode.Text;

            _customerManager.UpdateCustomer();

            LoadCustomersToUpdate();
            LoadCustomersToDelete();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var customerToDelete = _customersToDelete.FirstOrDefault(i => i.Id == Convert.ToInt32(lblDeleteId.Text));
            _customerManager.DeleteCustomer(customerToDelete);

            LoadCustomersToUpdate();
            LoadCustomersToDelete();

        }
    }
}
