using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using presiyan_marinov_11d.Business;
using presiyan_marinov_11d.Data;

namespace presiyan_marinov_11d.View
{
    internal class Display
    {

        private ClientBuisness clientBusiness;
        private StockBusiness stockBusiness;
        private ProviderBusiness providerBusiness;

        public Display()
        {
            clientBusiness = new ClientBuisness();
            stockBusiness = new StockBusiness();
            providerBusiness = new ProviderBusiness();
        }
        public void DisplayWelcome()
        {
            Console.WriteLine("Hello to Comsis Menu");
        }

        public void DisplaySeparator()
        {
            Console.WriteLine(new string('-', 40));
        }

        public void DisplayMenu()
        {
            Console.WriteLine("1. Create new Client, Stock or Provider");
            Console.WriteLine("2. Read Client, Stock or Provider information");
            Console.WriteLine("3. Update Client, Stock or Provider information");
            Console.WriteLine("4. Delete Client, Stock or Provider information");
            Console.WriteLine("5. Show All Clients, Stocks and Providers");
            Console.WriteLine("6 Exit menu");
        }

        public void StartPresentation()
        {
            DisplayWelcome();
            DisplaySeparator();

            bool exit = false;
            while (!exit)
            {
                DisplayMenu();
                Console.Write("Select an option: ");
                string input = Console.ReadLine();


                switch (input)
                {

                    case "1":
                        Console.WriteLine("Choose what to create: 1 Client, 2 Stock, 3 Provider");

                        int createChoice = int.Parse(Console.ReadLine());

                        if (createChoice == 1)
                        {
                            Console.WriteLine("Write new client's: Social Security Number, First Name, Last Name, Town Name and Total Value Sum");

                            string newClient = Console.ReadLine();

                            string[] newClientSplit = newClient.Split(' ');

                            int newSocialSecurityNumber = int.Parse(newClientSplit[0]);
                            string newFirstName = newClientSplit[1];
                            string newLastName = newClientSplit[2];
                            string newTownName = newClientSplit[3];
                            decimal newTotalValueSum = decimal.Parse(newClientSplit[4]);

                            clientBusiness.CreateNewClient(newSocialSecurityNumber, newFirstName, newLastName, newTownName, newTotalValueSum);

                        }

                        else if (createChoice == 2)
                        {
                            Console.WriteLine("Write new stock's: Name, Price, Quantity and Provider's Name");

                            string newProduct = Console.ReadLine();

                            string[] newProductSplit = newProduct.Split(' ');

                            string newProductName = newProductSplit[0];
                            decimal newProductPrice = decimal.Parse(newProductSplit[1]);
                            int newProductQuantity = int.Parse(newProductSplit[2]);
                            string newProvidername = newProductSplit[3];

                            stockBusiness.CreateStock(newProductName, newProductPrice, newProductQuantity, newProvidername);
                        }

                        else if (createChoice == 3)
                        {
                            Console.WriteLine("Write new provider's: Name and Email");

                            string[] newProvider = Console.ReadLine().Split(' ');

                            string newProviderName = newProvider[0];
                            string newProviderEmail = newProvider[1];

                            providerBusiness.CreateProvider(newProviderName, newProviderEmail);
                        }

                        else
                        {
                            Console.WriteLine("Wrong input");
                        }

                        break;
                    case "2":
                        Console.WriteLine("Choose what to read: 1 Client, 2 Stock, 3 Provider");

                        int readChoice = int.Parse(Console.ReadLine());

                        if (readChoice == 1)
                        {
                            Console.WriteLine("To read a client's information you must write his Social Security Number");

                            int socialSecurityNumberRead = int.Parse(Console.ReadLine());

                            clientBusiness.ReadClientById(socialSecurityNumberRead);
                        }

                        else if (readChoice == 2)
                        {
                            Console.WriteLine("To read a stock's information you must write it's Id");

                            int stockId = int.Parse(Console.ReadLine());

                            stockBusiness.ReadStockById(stockId);
                        }

                        else if (readChoice == 3)
                        {
                            Console.WriteLine("To read a provider's information you must write it's Id");

                            int providerId = int.Parse(Console.ReadLine());

                            providerBusiness.ReadProviderById(providerId);
                        }

                        else
                        {
                            Console.WriteLine("Wrong input");
                        }

                        break;
                    case "3":
                        Console.WriteLine("Choose what to update: 1 Client, 2 Stock, 3 Provider");

                        int updateChoice = int.Parse(Console.ReadLine());

                        if (updateChoice == 1)
                        {
                            Console.WriteLine("To update a client's information you must write his Social Security Number");

                            int socialSecurityNumberUpdate = int.Parse(Console.ReadLine());

                            clientBusiness.UpdateClientById(socialSecurityNumberUpdate);
                        }

                        else if (updateChoice == 2)
                        {
                            Console.WriteLine("To update a stock's information you must write it's Id");

                            int stockId = int.Parse(Console.ReadLine());

                            stockBusiness.UpdateStockById(stockId);
                        }

                        else if (updateChoice == 3)
                        {
                            Console.WriteLine("To update a provider's information you must write it's Id");

                            int providerId = int.Parse(Console.ReadLine());

                            providerBusiness.UpdateProviderById(providerId);
                        }

                        else
                        {
                            Console.WriteLine("Wrong input");
                        }

                        break;
                    case "4":
                        Console.WriteLine("Choose what to delete: 1 Client, 2 Stock, 3 Provider");

                        int deleteChoice = int.Parse(Console.ReadLine());

                        if (deleteChoice == 1)
                        {
                            Console.WriteLine("To delete a client you must write his Social Security Number");

                            int socialSecurityNumberDelete = int.Parse(Console.ReadLine());

                            clientBusiness.RemoveClientById(socialSecurityNumberDelete);
                        }

                        else if (deleteChoice == 2)
                        {
                            Console.WriteLine("To delete a stock you must write it's Id");

                            int stockId = int.Parse(Console.ReadLine());

                            stockBusiness.DeleteStockById(stockId);
                        }

                        else if (deleteChoice == 3)
                        {
                            Console.WriteLine("To delete a provider you must write it's Id");

                            int providerId = int.Parse(Console.ReadLine());

                            providerBusiness.DeleteProviderById(providerId);
                        }

                        else
                        {
                            Console.WriteLine("Wrong input");
                        }

                        break;
                    case "5":
                        Console.WriteLine("All clients, stocks and products");

                        clientBusiness.ShowAllCLients();
                        stockBusiness.ReadAllStocks();
                        providerBusiness.ShowAllProviders();

                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                DisplaySeparator();
            }

            Console.WriteLine("Thank you for using the Comsis Menu.");
        }
    }
}
