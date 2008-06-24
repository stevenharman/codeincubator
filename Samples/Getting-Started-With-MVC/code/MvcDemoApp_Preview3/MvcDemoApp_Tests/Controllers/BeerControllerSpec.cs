using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using MbUnit.Framework;
using MvcDemoApp_Preview3.Controllers;
using MvcDemoApp_Preview3.Models;
using Rhino.Mocks;

namespace MvcDemoApp_Tests.Controllers
{
    [TestFixture]
    public class When_index_is_called_on_the_beer_controller : Specification
    {
        private BeerController _controller;
        private ViewResult _result;
        private ViewDataDictionary _viewData;
        private IBeerRepository _repository;

        public override void  before_each()
        {
            _repository = Mock<IBeerRepository>();
            _controller = new BeerController(_repository);
            _repository.Stub(r => r.GetBeersForPage(1, 1)).IgnoreArguments().Return(new [] {new Beer {id = 1}});
            _repository.Stub(b => b.GetAllBeers()).Return(new[] {new Beer {id = 1}}).Repeat.Any();

            _result = _controller.Index(1) as ViewResult;
            _viewData = _result.ViewData;
        }

        [Test]
        public void then_should_verify_index_title()
        {
            _viewData["Title"].ShouldBeTheSameAs("Beer List");
        }

        [Test]
        public void then_index_model_should_contain_one_item()
        {
            ((IList<Beer>)_viewData.Model).Count.ShouldEqual(1);
        }

        [Test]
        public void then_model_items_should_be_of_type_beer()
        {
            ((IList)_viewData.Model)[0].ShouldBeOfType(typeof(Beer));
        }
    }

    [TestFixture]
    public class when_beer_please_is_called_on_the_beer_controller : Specification
    {
        private BeerController _controller;
        private ContentResult _result;
        private IBeerRepository _repository;
        private Beer _beer;

        public override void before_each()
        {
            _beer = new Beer
            {
                BeerType = new BeerType { Name = "IPA" },
                Brewery = new Brewery { Name = "New Brew", Location = "Hilliard, OH", Country = "USA", Established = "1999" },
                Name = "Good IPA",
                Description = "Good IPA"
            };

            _repository = Mock<IBeerRepository>();
            _controller = new BeerController(_repository);
            _repository.Stub(b => b.GetBeerById(1)).IgnoreArguments().Return(_beer);

            _result = _controller.BeerPlease(1) as ContentResult;
        }

        [Test]
        public void then_should_verify_html_is_in_content_response()
        {
            _result.Content.ShouldContain("<h3>Good IPA");
            _result.Content.ShouldContain("Hilliard, OH</li>");
        }
    }

    [TestFixture]
    public class when_beer_detail_is_called_on_the_beer_controller : Specification
    {
        private BeerController _controller;
        private ViewResult _result;
        private ViewDataDictionary _viewData;
        private IBeerRepository _repository;

        public override void before_each()
        {
            _repository = Mock<IBeerRepository>();
            _controller = new BeerController(_repository);
            _repository.Expect(b => b.GetBeerById(1)).IgnoreArguments().Return(new Beer());

            _result = _controller.BeerDetail(1) as ViewResult;
            _viewData = _result.ViewData;
        }

        [Test]
        public void then_should_verify_view_model_is_not_null()
        {
            _viewData.Model.ShouldNotBeNull();
        }

        [Test]
        public void then_should_verify_view_model_is_of_type_beer()
        {
            _viewData.Model.ShouldBeOfType(typeof(Beer));
        }
    }

    [TestFixture]
    public class when_edit_is_called_on_the_beer_controller : Specification
    {
        private BeerController _controller;
        private ViewResult _result;
        private ViewDataDictionary _viewData;
        private IBeerRepository _repository;

        public override void before_each()
        {
            _repository = Mock<IBeerRepository>();
            _controller = new BeerController(_repository);

            _repository.Expect(b => b.GetBeerById(1)).IgnoreArguments()
                .Return(new Beer{Type_id = 2, Brewery_id = 5} );

            _repository.Expect(t => t.GetAllBeerTypes())
                .Return(new[] {new BeerType {id = 1, Name = "IPA"}, new BeerType {id = 2, Name = "ESB"}});

            _repository.Expect(br => br.GetAllBreweries())
                .Return(new[] {new Brewery{id = 5}, new Brewery{id = 7}});

            _result = _controller.Edit(1) as ViewResult;
            _viewData = _result.ViewData;
        }

        [Test]
        public void then_should_verify_view_model_is_not_null()
        {
            _viewData.Model.ShouldNotBeNull();
        }

        [Test]
        public void then_should_verify_view_model_is_of_type_beer()
        {
            _viewData.Model.ShouldBeOfType(typeof(Beer));
        }

        [Test]
        public void then_beer_type_dropdown_should_be_in_view_data()
        {
            _viewData["Type_id"].ShouldNotBeNull();
        }

        [Test]
        public void then_beer_type_dropdown_item_1_should_be_selected()
        {
            ((SelectList) _viewData["Type_id"]).SelectedValue.ShouldEqual(2);
        }

        [Test]
        public void then_brewery_dropdown_should_be_in_view_data()
        {
            _viewData["Brewery_id"].ShouldNotBeNull();
        }

        [Test]
        public void then_brewery_dropdown_should_have_items()
        {
            ((SelectList) _viewData["Brewery_id"]).SelectedValue.ShouldEqual(5);
        }
    }
}