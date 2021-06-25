using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyBudgetApp.Core;
using MyBudgetApp.Data;

namespace BudgIt.Pages.Accounts
{
    public class DetailModel : PageModel
    {
        private readonly IAccountData accountData;
        public Account Account { get; set; }

        public DetailModel(IAccountData accountData)
        {
            this.accountData = accountData;
        }
        public IActionResult OnGet(int accountId)
        {
            Account = accountData.GetById(accountId);

            if (Account == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
