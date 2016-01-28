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

        }
    }
}
