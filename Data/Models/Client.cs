using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presiyan_marinov_11d.Data.Models
{
    public class Client
    {
        public Client()
        {
        }

        public Client(int socialSecurityNumber, string firstName, string familyName, string townName, decimal totalValueSum)
        {
            SocialSecurityNumber = socialSecurityNumber;
            FirstName = firstName;
            FamilyName = familyName;
            TownName = townName;
            TotalValueSum = totalValueSum;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SocialSecurityNumber { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string TownName { get; set; }
        public decimal TotalValueSum { get; set; }
        public IList<Stock> Stocks { get; set; }
        public IList<Provider> Providers { get; set; }
    }
}
