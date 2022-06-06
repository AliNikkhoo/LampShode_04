using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using System.Collections.Generic;


namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
   
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> Products;
        public SelectList ProductCategories;

        private readonly IProductApplication _productApplication;
        private readonly IProductCategoeyApplication _productCategoeyApplication;
        public IndexModel(IProductApplication productApplication,IProductCategoeyApplication productCategoeyApplication)
        {
            _productApplication = productApplication;
            _productCategoeyApplication = productCategoeyApplication;
        }

       
        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(_productCategoeyApplication.GetProducCategories(), "Id", "Name");
            Products = _productApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreatProduct();
            command.Categories = _productCategoeyApplication.GetProducCategories();
               
            return Partial("./Create", command);
        }

     
        public JsonResult OnPostCreate(CreatProduct command)
        {
            var result = _productApplication.Creat(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var product = _productApplication.GetDetails(id);
            product.Categories = _productCategoeyApplication.GetProducCategories();
            return Partial("Edit", product);
        }

    
        public JsonResult OnPostEdit(EditProudct command)
        {
            if (ModelState.IsValid)
            {
            }

            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }
 
    }
}