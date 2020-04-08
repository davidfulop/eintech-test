using NSubstitute;
using NUnit.Framework;
using PeopleManager.Web.ControllerLogic;
using PeopleManager.Web.Controllers;
using PeopleManager.Web.Models.AddPerson;

namespace PeopleManager.Web.UnitTests.Controllers
{
    public class AddPersonControllerTests
    {
        private AddPersonController _subject;
        private IAddPersonControllerLogic _mockLogic;

        [SetUp]
        public void Before_Each()
        {
            _mockLogic = Substitute.For<IAddPersonControllerLogic>();
            _mockLogic.GetIndexModel()
                .Returns(new AddPersonIndexModel());
            _mockLogic.AddPerson(Arg.Any<AddPersonIndexModel>())
                .Returns(new AddPersonModel());
            _subject = new AddPersonController(_mockLogic);
        }

        [Test, Ignore("Rider has a problem restoring the correct ViewFeatures package.")]
        public void Index_returns_view_with_correct_model()
        {
//            var result = _subject.Index() as ViewResult;
//            
//            Assert.That(result, Is.Not.Null);
//            Assert.That(result.Model, Is.InstanceOf<AddPersonIndexModel>());
        }
        
        [Test, Ignore("Rider has a problem restoring the correct ViewFeatures package.")]
        public void AddPerson_passes_down_input_to_logic()
        {
//            var input = new AddPersonIndexModel();
//            _subject.AddPerson(input);
//
//            _mockLogic.Received(1).AddPerson(input);
        }
        
        [Test, Ignore("Rider has a problem restoring the correct ViewFeatures package.")]
        public void AddPerson_returns_view_with_correct_model()
        {
//            var input = new AddPersonIndexModel();
//            var result = _subject.AddPerson(input) as ViewResult;
//            
//            Assert.That(result, Is.Not.Null);
//            Assert.That(result.Model, Is.InstanceOf<AddPersonModel>());
        }
        
    }
}
