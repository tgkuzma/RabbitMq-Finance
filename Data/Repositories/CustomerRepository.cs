using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Interfaces;
using Integrations;
using Models;
using Models.Interfaces;
using Newtonsoft.Json;

namespace Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context, IRepositoryEvents repositoryEvents) : base(context, repositoryEvents)
        {
            repositoryEvents.ChangesSaved += OnChangesSaved;
        }

        private static async void OnChangesSaved(object sender, ChangesSavedEventArgs changesSavedEventArgs)
        {
            await SendToBus(changesSavedEventArgs.Entries);
        }

        private static async Task SendToBus(Dictionary<string, object> itemsToSend)
        {
            foreach (var entry in itemsToSend)
            {
                var message = JsonConvert.SerializeObject(entry.Value);
                IntegrationManager.SendMessage(entry.Key, "Customer", message);
            }

            var xxx = "";
        }
    }
}
