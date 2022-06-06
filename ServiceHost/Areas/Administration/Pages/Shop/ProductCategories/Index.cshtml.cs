using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;
using System.Collections.Generic;


namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategories
{
   
    public class IndexModel : PageModel
    {
        public ProductCategoryShearchModel SearchModel;
        public List<ProducCategoryViewModel> ProductCategories;

        private readonly IProductCategoeyApplication _productCategoryApplication;

        public IndexModel(IProductCategoeyApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

       
        public void OnGet(ProductCategoryShearchModel searchModel)
        {
            ProductCategories = _productCategoryApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreatProductCategory());
        }

     
        public JsonResult OnPostCreate(CreatProductCategory command)
        {
            var result = _productCategoryApplication.Creat(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _productCategoryApplication.GetDetails(id);
            return Partial("Edit", productCategory);
        }

    
        public JsonResult OnPostEdit(EditProductCategoey command)
        {
            //if (ModelState.IsValid)
            //{
            //}

            var result = _productCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}