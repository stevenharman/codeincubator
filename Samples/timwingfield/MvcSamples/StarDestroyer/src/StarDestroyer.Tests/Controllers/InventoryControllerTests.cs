using System.Collections.Generic;
using System.Web.Mvc;
using NBehave.Spec.NUnit;
using NUnit.Framework;
using Rhino.Mocks;
using StarDestroyer.Controllers;
using StarDestroyer.Core.Entities;
using StarDestroyer.Core.Services;

namespace StarDestroyer.Tests.Controllers
{
    public class When_calling_the_constructor_with_an_iiservice_parameter : Specification
    {
        InventoryController _controller;
        private IInventoryService _service;

        protected override void Before_each()
        {
            _service = Stub<IInventoryService>();
        }

        protected override void Because()
        {
            _controller = new InventoryController(_service);
        }

        [Test]
        public void then_the_inventory_service_should_be_the_same_as_the_one_passed_in()
        {
            _controller.Service.ShouldBeTheSameAs(_service);
        }
    }

    public class When_calling_index_on_the_inventory_controller : Specification
    {
        private ViewResult _result;
        private object _viewData;
        private InventoryController _controller;
        private IList<AssaultItem> _aiList;
        private IInventoryService _service;

        protected override void Before_each()
        {
            _aiList = new List<AssaultItem>
                          {
                              new AssaultItem {Description = "Stormtrooper"},
                              new AssaultItem {Description = "AT-ST"}
                          };
            _service = Stub<IInventoryService>();
            _service.Stub(x => x.GetAllAssaultItems()).Return(_aiList);

            _controller = new InventoryController(_service);
        }

        protected override void Because()
        {
            _result = _controller.Index();
            _viewData = _result.ViewData.Model;
        }

        [Test]
        public void then_a_view_should_be_returned()
        {
            _result.ShouldNotBeNull();
        }

        [Test]
        public void then_the_view_model_should_be_of_type_ilist_assault_item()
        {
            _viewData.GetType().ShouldEqual(typeof(List<AssaultItem>));
        }

        [Test]
        public void then_get_all_assault_items_should_be_called_on_the_service()
        {
            _service.AssertWasCalled(x => x.GetAllAssaultItems());
        }
    }

    public class When_calling_the_details_action_without_an_id : Specification
    {
        private RedirectToRouteResult _result;
        private InventoryController _controller;
        private IInventoryService _service;

        protected override void Before_each()
        {
            _service = Stub<IInventoryService>();
            _controller = new InventoryController(_service);
        }

        protected override void Because()
        {
            _result = _controller.Details(null) as RedirectToRouteResult;
        }

        [Test]
        public void then_the_controller_should_redirect_to_the_index_action()
        {
            _result.RouteValues["action"].ShouldEqual("Index");
        }

        [Test]
        public void then_get_assault_item_by_id_is_not_called_on_the_controller()
        {
            _service.AssertWasNotCalled(x => x.GetAssaultItemById(2));
        }
    }

    public class When_calling_the_details_action_with_an_id : Specification
    {
        private ViewResult _result;
        private object _viewData;
        private InventoryController _controller;
        private IInventoryService _service;
        private AssaultItem _item;

        protected override void Before_each()
        {
            _item = new AssaultItem {Description = "AT-AT", LoadValue = 72};
            _service = Stub<IInventoryService>();
            _service.Stub(x => x.GetAssaultItemById(2)).Return(_item);

            _controller = new InventoryController(_service);
        }

        protected override void Because()
        {
            _result = (ViewResult) _controller.Details(2);
            _viewData = _result.ViewData.Model;
        }

        [Test]
        public void then_a_view_should_be_returned()
        {
            _result.ShouldNotBeNull();
        }

        [Test]
        public void then_the_view_model_should_be_of_type_assault_item()
        {
            _viewData.GetType().ShouldEqual(typeof(AssaultItem));
        }

        [Test]
        public void then_the_view_data_is_the_same_returned_from_the_service()
        {
            _viewData.ShouldBeTheSameAs(_item);
        }

        [Test]
        public void then_get_assault_item_by_id_is_called_on_the_service()
        {
            _service.AssertWasCalled(x => x.GetAssaultItemById(2));
        }
    }
}