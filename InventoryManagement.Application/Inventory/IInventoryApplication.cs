using _0_FrameWork.Application;
using InventoryManagement.Application.Contract.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Inventory
{
    public interface IInventoryApplication 
    {
        OperationResult Creat(CreateInventory command);
        OperationResult Edit(EditInventory command);
        OperationResult Increase(IncreaseInventory increase);
        OperationResult Reduce(ReduceInventory decreases);
        OperationResult Reduce(List<ReduceInventory> decreases);
        EditInventory GetDetails(long id);
        List<InventoryViewModel> Search(InventroySearchModel searchModel);
        List<InventoryOperationViewModel> GetOperationLog(long inventoryId);

    }
}
