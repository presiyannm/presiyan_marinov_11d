using presiyan_marinov_11d.Data;
using presiyan_marinov_11d.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presiyan_marinov_11d.Business
{
    public class ProviderBusiness
    {
        private ApplicationDbContext _dbContext;

        public ProviderBusiness()
        {
            _dbContext = new ApplicationDbContext();
        }

        public void CreateProvider(string name, string email)
        {
            var newProvider = new Provider(name, email);

            _dbContext.Providers.Add(newProvider);

            Console.WriteLine("Provider added successfully");

            _dbContext.SaveChanges();
        }

        public void ReadProviderById(int id)
        {
            var provider = _dbContext.Providers.Find(id);

            if (provider == null)
            {
                Console.WriteLine("Such provider doesn't exist");
            }
            else
            {
                Console.WriteLine($"{provider.Name} {provider.Email}");
            }
        }

        public void ShowAllProviders()
        {
            if (_dbContext.Providers == null)
            {
                Console.WriteLine("Doesn't have any providers");
            }
            else
            {
                foreach (var provider in _dbContext.Providers)
                {
                    Console.WriteLine($"Provider Id: {provider.Id} Provider Name: {provider.Name} Provider Email: {provider.Email}");
                }
            }
        }

        public void UpdateProviderById(int id)
        {
            var provider = _dbContext.Providers.Find(id);

            if (provider == null)
            {
                Console.WriteLine("Such provider doesn't exist");
            }

            Console.WriteLine("Write new provider: Name, Email");

            string[] UpdatedClient = Console.ReadLine().Split(' ');

            string newName = UpdatedClient[0];
            string newEmail = UpdatedClient[1];

            provider.Name = newName;
            provider.Email = newEmail;

            Console.WriteLine("Provider changed successfully");

            _dbContext.SaveChanges();
        }

        public void DeleteProviderById(int id)
        {
            var provider = _dbContext.Providers.Find(id);

            if (provider == null)
            {
                Console.WriteLine("Such provider doesn't exist");
            }

            _dbContext.Providers.Remove(provider);

            Console.WriteLine("Provider successfully removed");

            _dbContext.SaveChanges();
        }
    }
}
