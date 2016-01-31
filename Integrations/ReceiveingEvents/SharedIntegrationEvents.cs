using Business.Interfaces;

namespace Integrations.ReceiveingEvents
{
    public class SharedIntegrationEvents
    {
        private readonly ICustomerManager _customerManager;

        public SharedIntegrationEvents(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
    }
}