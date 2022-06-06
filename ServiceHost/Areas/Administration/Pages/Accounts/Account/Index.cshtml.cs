
using AccountManagement.Application.Contraccts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Accounts.Account
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public AccountSearchModel SearchModel;
        public List<AccountViewModel> Accounts;
        public SelectList Roles;

      //  private readonly IRoleApplication _roleApplication;
        private readonly IAccountApplication _accountApplication;

        public IndexModel(IAccountApplication accountApplication/*, IRoleApplication roleApplication*/)
        {
            //_roleApplication = roleApplication;
            _accountApplication = accountApplication;
        }

        public void OnGet(AccountSearchModel searchModel)
        {
          //  Roles = new SelectList(_roleApplication.List(), "Id", "Name");
            Accounts = _accountApplication.serach(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            //var command = new RegisterAccount
            //{
            //    Roles = _roleApplication.List()
            //};
            var command = new CreateAccount
            {

            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateAccount command)
        {
            var result = _accountApplication.Careat(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var account = _accountApplication.GetDetails(id);
            //account.Roles = _roleApplication.List();
            return Partial("Edit", account);
        }

        public JsonResult OnPostEdit(EditAccount command)
        {
            var result = _accountApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetChangePassword(long id)
        {
            var command = new ChangePassword { Id = id };
            return Partial("ChangePassword", command);
        }

        public JsonResult OnPostChangePassword(ChangePassword command)
        {
            var result = _accountApplication.ChangePassword(command);
            return new JsonResult(result);
        }
    }
}
