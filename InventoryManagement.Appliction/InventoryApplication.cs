using _0_FrameWork.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Application.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Appliction
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IIiventoryRepository _iiventoryRepository;
        public InventoryApplication(IIiventoryRepository iiventoryRepository)
        {
            _iiventoryRepository = iiventoryRepository;
        }
        public OperationResult Creat(CreateInventory command)
        {
            var operation = new OperationResult();
            if (_iiventoryRepository.Exists(x => x.ProductId == command.ProductId))
                return operation.Faild(ApplicationMessages.DuplicatedRecord);

            var inventory = new Inventory(command.ProductId, command.UnitPrice);
            _iiventoryRepository.Creat(inventory);
            _iiventoryRepository.SaveChanges();
            return operation.seccedded();
        }

        public OperationResult Edit(EditInventory command)
        {
            var operation = new OperationResult();
            var inventory = _iiventoryRepository.Get(command.Id);

            if (inventory != null)
                return operation.Faild(ApplicationMessages.RecordNontFound);
            if (_iiventoryRepository.Exists(x => x.ProductId == command.ProductId && x.Id != command.Id))
                return operation.Faild(ApplicationMessages.DuplicatedRecord);

            inventory.Edit(command.ProductId, command.UnitPrice);
            _iiventoryRepository.SaveChanges();
            return operation.seccedded();

        }

        public EditInventory GetDetails(long id)
        {
            return _iiventoryRepository.GetDetails(id);
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryId)
        {
            return _iiventoryRepository.GetOperationLog(inventoryId);
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            var operation = new OperationResult();
            var inventory = _iiventoryRepository.Get(command.InvetoryId);

            if (inventory == null)
                return operation.Faild(ApplicationMessages.RecordNontFound);

            const long operatorId = 1;
            inventory.Increase(command.Count, operatorId, command.Description);
            _iiventoryRepository.SaveChanges();
            return operation.seccedded();
        }

        public OperationResult Reduce(ReduceInventory command)
        {
           
                var operation = new OperationResult();
                var inventory = _iiventoryRepository.Get(command.InventoryId);

                if (inventory == null)
                    return operation.Faild(ApplicationMessages.RecordNontFound);

                const long operatorId = 1;
                inventory.Reduce(command.Count, operatorId, command.Description, 0);
                _iiventoryRepository.SaveChanges();
                return operation.seccedded();
            
        }
        public OperationResult Reduce(List<ReduceInventory> command)
        {
            var operation = new OperationResult();

            const long operatorId = 1;
            foreach (var item in command)
            {
                var inventory = _iiventoryRepository.GetBy(item.ProudctId);
                inventory.Reduce(item.Count, operatorId, item.Description,item.OrderId);
            }
            _iiventoryRepository.SaveChanges();
            return operation.seccedded();
        }

        public List<InventoryViewModel> Search(InventroySearchModel searchModel)
        {
            return _iiventoryRepository.Search(searchModel);
        }
    }
}
