using Business;
using Business.Interfaces;
using Data;
using Data.Interfaces;
using Data.Repositories;
using Models.Interfaces;
using Ninject.Modules;

namespace Finance
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomerManager>().To<CustomerManager>();
            Bind<ICustomerRepository>().To<CustomerRepository>();
            Bind<IRepositoryEvents>().To<RepositoryEvents>();
        }
    }
}