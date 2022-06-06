using DiscountManagement.Application.Contract.ColleagueDiscount;
using InventoryManagement.Application.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    //[Authorize(Roles = Roles.Administator)]
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public InventroySearchModel SearchModel;
        public List<InventoryViewModel> inventory;
        public SelectList Products;

        private readonly IProductApplication _productApplication;
        private readonly IInventoryApplication _invetoryapplication;

        public IndexModel(IProductApplication ProductApplication, IInventoryApplication invetoryapplication)
        {
            _productApplication = ProductApplication;
            _invetoryapplication = invetoryapplication;
        }

        public void OnGet(InventroySearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            inventory = _invetoryapplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateInventory
            {
                Products = _productApplication.GetProducts()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateInventory command)
        {
            var result = _invetoryapplication.Creat(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var inventory = _invetoryapplication.GetDetails(id);
            inventory.Products = _productApplication.GetProducts();
            return Partial("Edit", inventory);
        }

        public JsonResult OnPostEdit(EditInventory command)
        {
            var result = _invetoryapplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetIncrease(long id)
        {
            var command = new IncreaseInventory()
            {
                InvetoryId = id
            };
            return Partial("Increase",command);
        }
        public JsonResult OnPostInCrease(IncreaseInventory command)
        {
            var result = _invetoryapplication.Increase(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetReduce(long id)
        {
            var command = new ReduceInventory()
            {
                InventoryId = id
            };
            return Partial("Reduce", command);
        }
        public JsonResult OnPostReduce(ReduceInventory command)
        {
            var result = _invetoryapplication.Reduce(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetLog(long id)
        {
            var log = _invetoryapplication.GetOperationLog(id);
                return Partial("OperationLog", log);
        }
    }
}
