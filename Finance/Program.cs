using System;
using System.Reflection;
using System.Windows.Forms;
using Business.Interfaces;
using Ninject;

namespace Finance
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var kernel = InitializeDependencies();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(kernel.Get<Form1>());
        }

        private static IKernel InitializeDependencies()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            kernel.Get<TestConsole.Program>();
            kernel.Get<Integrations.ReceiveingEvents.SharedIntegrationEvents>();
            kernel.Get<ICustomerManager>().GetAllCustomers();

            return kernel;
        }
    }
}
