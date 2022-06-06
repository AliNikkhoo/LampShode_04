using _0_Framework.Application;
using _0_FrameWork.Domain;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Application.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.EfCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory> ,IIiventoryRepository
    {
        private readonly InventoryContext _inventoryContext;
        private readonly ShopContext _shopContext;
        public InventoryRepository(InventoryContext inventoryContext, ShopContext shopContext) :base(inventoryContext) 
        {
            _inventoryContext = inventoryContext;
            _shopContext = shopContext;
        }
      

        public Inventory GetBy(long ProductId)
        {
            return _inventoryContext.Inventotry.FirstOrDefault(x=>x.ProductId== ProductId);
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryContext.Inventotry.Select(x => new EditInventory 
            {
            Id=x.Id,
            ProductId=x.ProductId,  
            UnitPrice=x.UnitPrice,
            }).FirstOrDefault(x=>x.Id== id);
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            var inventory = _inventoryContext.Inventotry.FirstOrDefault(x=>x.Id==inventoryId);
            return inventory.Operations.Select(x => new InventoryOperationViewModel
            { 
            Id = x.Id,
            OperatorId = x.OperatorId,
            OrderId = x.OrderId,
            Operation = x.Operation,
            OperationDate = x.OperationDate,
            Count =x.Count,
            CurrentCount =x.CurrentCount,
            Description =x.Description,
            OperatorName ="مدیر سیستم",
            }).OrderByDescending(x=>x.Id).ToList();
            
        }

        public List<InventoryViewModel> Search(InventroySearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();

            var query = _inventoryContext.Inventotry.Select(x=>new InventoryViewModel
            {
                Id=x.Id,
                InStock=x.Instock,
                productId=x.ProductId,
                UnintPrice=x.UnitPrice,
                CurrentCount = x.CalculateCurrentCount(),
                CreationDate =x.CreationDate.ToFarsi(),
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x=>x.productId==searchModel.ProductId);

            if (searchModel.IsStock)
                query = query.Where(x=>!x.InStock);

            var inventory = query.OrderByDescending(x => x.Id).ToList();

            inventory.ForEach(item => 
            {
                item.Product = products.FirstOrDefault(x=>x.Id == item.productId)?.Name;

            });
         
            return inventory;
        }
    }
}
