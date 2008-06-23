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
}