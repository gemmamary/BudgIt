using System;
using System.Collections.Generic;
using System.Text;

namespace MyBudgetApp.Core
{
    public class Account
    {
        // Declare properties that each account will use
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public AccountType AccountType { get; set; }
    }
}
