using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPictures
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public ProductPictureSearchModel SearchModel;
        public List<ProductPictureViewModel> ProductPictures;
        public SelectList Products;

        private readonly IProductApplication _productApplication;
        private readonly IProducPictureApplication _productPictureApplication;
        public IndexModel(IProductApplication ProductApplication, IProducPictureApplication productPictureApplication)
        {
            _productApplication = ProductApplication;
            _productPictureApplication = productPictureApplication;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            ProductPictures = _productPictureApplication.Serach(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreatProductPicture
            {
                Products = _productApplication.GetProducts()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate( CreatProductPicture command)
        {
            var result = _productPictureApplication.Creat(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productPicture = _productPictureApplication.GetDetails(id);
            productPicture.Products = _productApplication.GetProducts();
            return Partial("Edit", productPicture);
        }

        public JsonResult OnPostEdit(EditeProductPicture command)
        {
            var result = _productPictureApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _productPictureApplication.Remove(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var result = _productPictureApplication.Restore(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
