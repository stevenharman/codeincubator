using System.Collections.Generic;
using System.Web.Mvc;
using NBehave.Spec.NUnit;
using NUnit.Framework;
using Rhino.Mocks;
using StarDestroyer.Controllers;
using StarDestroyer.Core.Entities;
using StarDestroyer.Core.Services;
using StarDestroyer.Models;

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
        public void then_the_view_model_should_be_of_type_assault_item_detail_model()
        {
            _viewData.GetType().ShouldEqual(typeof(AssaultItemDetailModel));
        }

        [Test]
        public void then_get_assault_item_by_id_is_called_on_the_service()
        {
            _service.AssertWasCalled(x => x.GetAssaultItemById(2));
        }
    }

    public class When_converting_an_assault_item_to_an_assault_item_detail_model : Specification
    {
        private AssaultItem _item;
        private AssaultItemDetailModel _model;

        protected override void Before_each()
        {
            _item = new AssaultItem {Description = "Some Description", Type = "Lame Troopers", LoadValue = 4};
        }

        protected override void Because()
        {
            _model = _item.ToDetailModel();
        }

        [Test]
        public void then_type_is_set()
        {
            _model.Type.ShouldEqual(_item.Type);
        }

        [Test]
        public void then_description_is_set()
        {
            _model.Description.ShouldEqual(_item.Description);
        }

        [Test]
        public void then_load_value_is_set()
        {
            _model.LoadValue.ShouldEqual(_item.LoadValue);
        }

        [Test]
        public void then_images_list_is_not_null()
        {
            _model.Images.ShouldNotBeNull();
        }

        [Test]
        public void then_images_list_is_empty()
        {
            _model.Images.Count.ShouldEqual(0);
        }
    }

    public class When_converting_an_assault_item_to_an_assault_item_detail_model_and_setting_up_images : Specification
    {
        private AssaultItem _item;
        private AssaultItemDetailModel _model;

        protected override void Before_each()
        {
            _item = new AssaultItem { Description = "Dark Troopers, stormtroopers, SHOCK troopers, sCOUt troopers, at-st, Speeder BIKE, Heavy blaster"};
        }

        protected override void Because()
        {
            _model = _item.ToDetailModel();
        }

        [Test]
        public void then_images_list_will_have_seven_items()
        {
            _model.Images.Count.ShouldEqual(7);
        }

        [Test]
        public void then_the_images_list_should_contain_the_shock_trooper_icon()
        {
            _model.Images.ShouldContain("Shock_trooper_icon.png");
        }
    }

    public class When_calling_the_AjaxDetails_action_with_an_id : Specification
    {
        private ViewResult _result;
        private object _viewData;
        private InventoryController _controller;
        private IInventoryService _service;
        private AssaultItem _item;

        protected override void Before_each()
        {
            _item = new AssaultItem
                        {
                            Description = "Dark Trooper squad with 7 dark troopers",
                            LoadValue = 4,
                            Type = "Dark Trooper Squad"
                        };

            _service = Stub<IInventoryService>();
            _service.Stub(x => x.GetAssaultItemById(2)).Return(_item);

            _controller = new InventoryController(_service);
        }

        protected override void Because()
        {
            _result = (ViewResult)_controller.AjaxDetails(2);
            _viewData = _result.ViewData.Model;
        }

        [Test]
        public void then_get_assault_item_by_id_is_called_on_the_service()
        {
            
        }

        [Test]
        public void then_a_view_should_be_returned()
        {
            
        }

        [Test]
        public void then_the_view_model_should_be_of_type_string()
        {
            
        }

        [Test]
        public void then_the_view_model_should_contain_html_for_an_image()
        {
            
        }

        [Test]
        public void then_the_view_modle_should_contain_html_for_a_description()
        {
            
        }
    }
}