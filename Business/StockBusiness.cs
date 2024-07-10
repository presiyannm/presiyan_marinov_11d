using presiyan_marinov_11d.Data;
using presiyan_marinov_11d.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presiyan_marinov_11d.Business
{
    internal class StockBusiness
    {
        private ApplicationDbContext _dbContext;

        public StockBusiness()
        {
            _dbContext = new ApplicationDbContext();
        }

        public void CreateStock(string name, decimal price, int quantity, string providerName)
        {
            var provider = _dbContext.Providers.Where(x => x.Name == providerName).FirstOrDefault();

            if(provider is null)
            {
                Console.WriteLine("Such provider doesnt exist");

                return;
            }

            var newStock = new Stock(name, price, quantity, provider);

            _dbContext.Stocks.Add(newStock);

            Console.WriteLine("Stock added successfully");

            _dbContext.SaveChanges();
        }

        public void ReadStockById(int id)
        {
            var stock = _dbContext.Stocks.Find(id);

            if(stock == null)
            {
                Console.WriteLine("Such stock doesnt exist");
            }

            Console.WriteLine($"Name: {stock.ProductName} Price: {stock.ProductPrice} Quantity: {stock.Quantity}");
        }

        public void ReadAllStocks()
        {
            if(_dbContext.Stocks == null)
            {
                Console.WriteLine("Doesn't have any stocks");
            }

            foreach(var stock in _dbContext.Stocks)
            {
                Console.WriteLine($"Stock name: {stock.ProductName} Stock id: {stock.Id} Stock price: {stock.ProductPrice} Stock quantity: {stock.Quantity}");
            }
        }

        public void UpdateStockById(int id)
        {
            var stock = _dbContext.Stocks.Find(id);

            if (stock == null)
            {
                Console.WriteLine("Such stock doesnt exist");
            }

            Console.WriteLine("Write new stock: Name, Price and Quantity");

            string[] newStock = Console.ReadLine().Split(' ');

            string newName = newStock[0];
            decimal newPrice = decimal.Parse(newStock[1]);
            int newQuantity = int.Parse(newStock[2]);

            stock.ProductName = newName;
            stock.ProductPrice = newPrice;
            stock.Quantity = newQuantity;

            Console.WriteLine("Stock changed successfully");

            _dbContext.SaveChanges();
        }

        public void DeleteStockById(int id)
        {
            var stock = _dbContext.Stocks.Find(id);

            if (stock == null)
            {
                Console.WriteLine("Such stock doesnt exist");
            }

            _dbContext.Stocks.Remove(stock);

            Console.WriteLine("Stock removed successfully");

            _dbContext.SaveChanges();
        }
    }
}
