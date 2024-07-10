using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presiyan_marinov_11d.Data.Models
{
    public class Provider
    {
        public Provider()
        {
        }
        public Provider(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<Client> Clients { get; set; }
        public IList<Stock> Stocks { get; set; }
    }
}
