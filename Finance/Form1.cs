using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Interfaces;
using Models;

namespace Finance
{
    public partial class Form1 : Form
    {
        private readonly ICustomerManager _customerManager;

        public Form1(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Test();
            //_customerManager.AddCustomer(new Customer
            //{
            //    BillingAddress = new Address
            //    {
            //        City = txtCreateCity.Text,
            //        State = txtCreateState.Text,
            //        Street = txtCreateStreetAddress.Text,
            //        ZipCode = txtCreateZipCode.Text
            //    },
            //    FirstName = txtCreateFirstName.Text,
            //    LastName = txtCreateLastName.Text
            //});

            MessageBox.Show("");
        }

        private void Test()
        {
            _customerManager.AddCustomer(new Customer
            {
                BillingAddress = new Address
                {
                    City = "13",
                    State = "AZ",
                    Street = "Hello",
                    ZipCode = "FFF"
                },
                FirstName = "T-Dawg",
                LastName = "ldjsf"
            });
        }
    }
}
