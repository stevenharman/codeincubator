using System.Collections.Generic;
using NBehave.Spec.NUnit;
using NUnit.Framework;
using Rhino.Mocks;
using StarDestroyer.Core.Entities;
using StarDestroyer.Core.Repository;
using StarDestroyer.Core.Services;

namespace StarDestroyer.Tests.Services
{
    public class When_getting_all_assault_items : Specification
    {
        private InventoryService _service;
        private IList<AssaultItem> _aiList;
        private IList<AssaultItem> _result;
        private IRepository<AssaultItem> _repo;

        protected override void Before_each()
        {
            _aiList = new List<AssaultItem>
                          {
                              new AssaultItem {Description = "Stormtrooper"},
                              new AssaultItem {Description = "AT-ST"}
                          };

            _repo = Stub<IRepository<AssaultItem>>();
            _repo.Stub(x => x.GetAll()).Return(_aiList);

            _service = new InventoryService(_repo);
        }

        protected override void Because()
        {
            _result = _service.GetAllAssaultItems();
        }

        [Test]
        public void then_get_all_should_be_called_in_the_repository()
        {
            _repo.AssertWasCalled(x => x.GetAll());
        }

        [Test]
        public void then_returned_list_should_have_a_count_of_two()
        {
            _result.Count.ShouldEqual(2);
        }

        [Test]
        public void then_the_first_item_in_the_list_should_be_of_type_assault_item()
        {
            _result[0].GetType().ShouldBeTheSameAs(typeof (AssaultItem));
        }
    }

    public class When_getting_an_assault_item_by_id : Specification
    {
        private InventoryService _service;
        private IRepository<AssaultItem> _repo;
        private AssaultItem _result;

        protected override void Before_each()
        {
            _repo = Stub<IRepository<AssaultItem>>();
            _repo.Stub(x => x.GetById(2)).Return(new AssaultItem {Description = "AI2"});

            _service = new InventoryService(_repo);
        }

        protected override void Because()
        {
            _result = _service.GetAssaultItemById(2);
        }
        
        [Test]
        public void then_get_by_id_should_be_called_on_the_controller()
        {
            _repo.AssertWasCalled(x => x.GetById(2));
        }

        [Test]
        public void then_returned_item_description_should_be_AI2()
        {
            _result.Description.ShouldEqual("AI2");
        }
    }
}