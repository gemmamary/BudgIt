using MyBudgetApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyBudgetApp.Data
{
    public interface IAccountData
    {
        IEnumerable<Account> GetAccounts(string name);
    }

    // This is a class for temporary account data
    public class InMemoryAccountData : IAccountData
    {
        // Declares a list property to store all accounts
        List<Account> accounts;
        public InMemoryAccountData()
        {
            // Creates three accounts and sets properties for each, adds them to the accounts list
            accounts = new List<Account>()
            {
                new Account { Id = 1, Name = "Main Account", Balance = 102.28, AccountType = AccountType.Debit },
                new Account { Id = 2, Name = "Savings", Balance = 300, AccountType = AccountType.Debit },
                new Account { Id = 3, Name = "Credit Card", Balance = 243, AccountType = AccountType.Credit }
            };
        }

        // Gets all accounts created above
        public IEnumerable<Account> GetAccounts(string name = null)
        {
            return from a in accounts
                   where string.IsNullOrEmpty(name) || a.Name.StartsWith(name)
                   orderby a.Id
                   select a;
        }
    }
}
