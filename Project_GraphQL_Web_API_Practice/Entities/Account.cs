using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_GraphQL_Web_API_Practice.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        
        public TypeOfAccount Type { get; set; }
       
        public string Description { get; set; }

        public Owner Owner { get; set; }
    }

    public enum TypeOfAccount
    {
        Cash,
        Savings,
        Expense,
        Income
    }
}
