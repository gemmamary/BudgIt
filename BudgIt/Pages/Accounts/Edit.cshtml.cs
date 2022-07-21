using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudgetApp.Core;
using MyBudgetApp.Data;

namespace BudgIt.Pages.Accounts
{
    public class EditModel : PageModel
    {
        private readonly IAccountData accountData;
        private readonly IHtmlHelper htmlHelper;

        public Account Account { get; set; }
        
        /// <summary>
        /// When editing an account, we want a dropdown list that displays the options from the Account Type enum. 
        /// Declaring the Accounts variable here so that we can use it in the form.
        /// </summary>
        public IEnumerable<SelectListItem> Accounts { get; set; }

        /// <summary>
        /// Sets the properties needed for the edit Account operations.
        /// </summary>
        /// <param name="accountData">This is used to access the account data fields and methods.</param>
        /// <param name="htmlHelper">This is used to get the values from the AccountType enum.</param>
        public EditModel(IAccountData accountData,
                         IHtmlHelper htmlHelper)
        {
            this.accountData = accountData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int accountId)
        {
            Account = accountData.GetById(accountId);

            Accounts = htmlHelper.GetEnumSelectList<AccountType>();

            if(Account == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
