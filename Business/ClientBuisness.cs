using presiyan_marinov_11d.Data;
using presiyan_marinov_11d.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presiyan_marinov_11d.Business
{
    public class ClientBuisness
    {
        private ApplicationDbContext _dbContext;

        public ClientBuisness()
        {
            _dbContext = new ApplicationDbContext();
        }

        public void ReadClientById(int socialSecurityNumber)
        {
            var client = _dbContext.Clients.Find(socialSecurityNumber);

            if (client == null)
            {
                throw new ArgumentNullException(nameof(Client));
            }

            Console.WriteLine($"{client.SocialSecurityNumber}, {client.FirstName}, {client.FamilyName}, {client.TownName}, {client.TotalValueSum}");

        }

        public void CreateNewClient(int socialSecurityNumber,
            string firstName, string lastName,
            string townName, decimal totalValueSum)
        {
            var newClient = new Client(socialSecurityNumber, firstName, lastName, townName, totalValueSum);

            _dbContext.Clients.Add(newClient);

            Console.WriteLine("Client added successfully");

            _dbContext.SaveChanges();

        }

        public void UpdateClientById(int socialSecurityNumber)
        {
            var client =  _dbContext.Clients.Find(socialSecurityNumber);

            if (client == null)
            {
                throw new ArgumentNullException(nameof(Client));
            }

            Console.WriteLine($"Client information: \n {client.FirstName}, {client.FamilyName}, {client.TownName}, {client.TotalValueSum}");

            Console.WriteLine("Write new: First Name, Last Name, Town Name and Total Value");

            string newClient = Console.ReadLine();

            string[] newClientSplit = newClient.Split(' ');

            string newFirstName = newClientSplit[0];
            string newLastName = newClientSplit[1];
            string newTownName = newClientSplit[2];
            decimal newTotalValueSum = decimal.Parse(newClientSplit[3]);

            
            client.FirstName = newFirstName;
            client.FamilyName = newLastName;
            client.TownName = newTownName;
            client.TotalValueSum = newTotalValueSum;

            Console.WriteLine("Client updated successfully");

             _dbContext.SaveChanges();
        }

        public void RemoveClientById(int socialSecurityNumber)
        {
            var client = _dbContext.Clients.Find(socialSecurityNumber);

            if (client == null)
            {
                throw new ArgumentNullException(nameof(Client));
            }

            _dbContext.Clients.Remove(client);

            Console.WriteLine("Client removed successfully");

            _dbContext.SaveChanges();

        }

        public void ShowAllCLients()
        {
            if (_dbContext.Clients == null)
            {
                Console.WriteLine("There are no records of clients");
            }
            else
            {

                foreach (var client in _dbContext.Clients)
                {
                    Console.WriteLine($"Client SCN: {client.SocialSecurityNumber}, Client First Name: {client.FirstName}, Client Last Name: {client.FamilyName}, Client Town Name: {client.TownName}, Client Total Value Sum: {client.TotalValueSum}");
                }
            }

        }


    }
}
