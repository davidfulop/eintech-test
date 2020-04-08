using NSubstitute;
using NUnit.Framework;
using PeopleManager.Web.ControllerLogic;
using PeopleManager.Web.Controllers;
using PeopleManager.Web.Models.Search;

namespace PeopleManager.Web.UnitTests.Controllers
{
    public class SearchControllerTests
    {
        private SearchController _subject;
        private ISearchControllerLogic _mockLogic;

        [SetUp]
        public void Before_Each()
        {
            _mockLogic = Substitute.For<ISearchControllerLogic>();
            _mockLogic.GetIndexModel(Arg.Any<string>())
                .Returns(new SearchIndexModel());
            _subject = new SearchController(_mockLogic);
        }
        
        [Test, Ignore("Rider has a problem restoring the correct ViewFeatures package.")]
        public void Index_passes_down_input_to_logic()
        {
//            const string input = "test string";
//            _subject.Index(input);
//
//            _mockLogic.Received(1).GetIndexModel(input);
        }
        
        [Test, Ignore("Rider has a problem restoring the correct ViewFeatures package.")]
        public void Index_returns_view_with_correct_model()
        {
//            const string input = "test string";
//            var result = _subject.Index(input) as ViewResult;
//            
//            Assert.That(result, Is.Not.Null);
//            Assert.That(result.Model, Is.InstanceOf<SearchIndexModel>());
        }
    }
}
