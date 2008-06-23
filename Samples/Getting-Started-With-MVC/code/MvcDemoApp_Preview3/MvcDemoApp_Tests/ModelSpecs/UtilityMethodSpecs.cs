using MbUnit.Framework;
using MvcDemoApp_Preview3.Models;

namespace MvcDemoApp_Tests.ModelSpecs
{
    [TestFixture]
    public class when_total_number_of_beer_records_and_beers_per_page_are_known : Specification
    {
        [Row(12, 3)]
        [Row(10, 2)]
        [Row(5, 1)]
        [Row(1, 1)]
        [Row(7, 2)]
        [Test]
        public void then_number_of_pages_is_determinted(int totalBeers, int shouldBe)
        {
            UtilityMethods.PagesNeeded(totalBeers, 5).ShouldEqual(shouldBe);
        }
    }

    [TestFixture]
    public class when_beer_please_content_is_needed : Specification
    {
        private Beer beer;
        private string htmlContent;

        public override void before_each()
        {
            beer = new Beer
            {
                BeerType = new BeerType { Name = "IPA" },
                Brewery = new Brewery { Name = "New Brew", Location = "Hilliard, OH", Country = "USA", Established = "1999" },
                Name = "Good IPA",
                Description = "Good IPA"
            };

            htmlContent = UtilityMethods.CreateBeerPleaseContent(beer);
        }

        [Test]
        public void then_heading_should_contain_beer_name()
        {
            htmlContent.ShouldContain("<h3>Good IPA</h3>");
        }

        [Test]
        public void then_beer_type_should_be_in_a_paragraph()
        {
            htmlContent.ShouldContain("<p><b>Type:</b> IPA</p>");
        }

        [Test]
        public void then_brewery_info_should_be_in_a_list()
        {
            htmlContent.ShouldContain("<li><b>Brewery:</b> New Brew</li>");
            htmlContent.ShouldContain("<li><b>Location:</b> Hilliard, OH</li>");
            htmlContent.ShouldContain("<li><b>Established:</b> 1999</li>");
        }

        [Test]
        public void then_description_should_be_in_a_paragraph()
        {
            htmlContent.ShouldContain("<p>Good IPA</p>");
        }
    }
}