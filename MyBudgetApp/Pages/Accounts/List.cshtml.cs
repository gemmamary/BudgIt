using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MyBudgetApp.Core;
using MyBudgetApp.Data;

namespace MyBudgetApp.Pages.Accounts
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IAccountData accountData;

        public string Message { get; set; }

        public IEnumerable<Account> Accounts { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config,
                         IAccountData accountData)
        {
            this.config = config;
            this.accountData = accountData;
        }
        public void OnGet()
        {
            Message = config["Message"];
            Accounts = accountData.GetAccounts(SearchTerm);
        }
    }
}
