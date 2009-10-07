using System;
using System.Web.Mvc;
using NUnit.Framework;
using StarDestroyer.Controllers;
using Rhino.Mocks;
using MvcContrib.TestHelper;
using NBehave.Spec.NUnit;

namespace StarDestroyer.Tests.Controllers
{
    public class When_searching_for_a_product : Specification
    {
        private ProductController _productController;
        private ActionResult _actionResult;
        private IProductRepository _productRepository;
        private Product _fakeProduct;
        private const string PRODUCT_NAME = "SomeProductName";

        protected override void Before_each()
        {
            PrepareFakes();
            
            _productController = new ProductController(_productRepository);
            base.Before_each();
        }

        private void PrepareFakes()
        {
            _fakeProduct = new Product() {Description = "PIE!", Name = "Chocolate"};
            _productRepository = Stub<IProductRepository>();
            _productRepository.Stub(x => x.GetProduct(PRODUCT_NAME)).Return(_fakeProduct);
        }

        protected override void Because()
        {
            _actionResult = _actionResult = _productController.Search(PRODUCT_NAME);
            base.Because();
        }

        [Test]
        public void Then_the_product_repository_should_be_queried()
        {
            _productRepository.AssertWasCalled(x => x.GetProduct(PRODUCT_NAME));
        }

        [Test]
        public void Then_the_search_view_should_be_displayed_to_the_user()
        {
            _actionResult.AssertViewRendered().ForView("Search").WithViewData<Product>();
        }

        [Test]
        public void Then_the_correct_product_should_be_displayed_to_the_user()
        {
            var productToView = ((ViewResult) _actionResult).ViewData.Model as Product;
            productToView.Description.ShouldEqual("PIE!");
        }

    }
}