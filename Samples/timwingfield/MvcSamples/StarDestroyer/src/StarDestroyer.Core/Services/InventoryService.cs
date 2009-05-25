using System;
using System.Collections.Generic;
using StarDestroyer.Core.Entities;
using StarDestroyer.Core.Repository;

namespace StarDestroyer.Core.Services
{
    public interface IInventoryService
    {
        IList<AssaultItem> GetAllAssaultItems();
        AssaultItem GetAssaultItemById(int id);
    }

    public class InventoryService : IInventoryService
    {
        private IRepository<AssaultItem> _repository;

        public InventoryService() : this(null) { }

        public InventoryService(IRepository<AssaultItem> repository)
        {
            _repository = repository ?? new Repository<AssaultItem>();
        }

        public IList<AssaultItem> GetAllAssaultItems()
        {
            return _repository.GetAll();
        }

        public AssaultItem GetAssaultItemById(int id)
        {
            return _repository.GetById(id);
        }
    }
}