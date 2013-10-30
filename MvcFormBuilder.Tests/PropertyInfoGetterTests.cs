using System.Reflection;
using NUnit.Framework;

namespace FormBuilder.Tests
{
    [TestFixture]
    public class PropertyInfoGetterTests
    {
        private MyModel myModel;
        private PropertyInfo firstNamePropertyInfo;
        private PropertyInfoGetter propertyInfoGetter;

        [SetUp]
        public void SetUp()
        {
            myModel = new MyModel();
            firstNamePropertyInfo = myModel.GetType().GetProperty("FirstName");
            propertyInfoGetter = new PropertyInfoGetter();
        }

        [Test]
        public void get_by_string()
        {
            var result = propertyInfoGetter.GetPropertyInfo(typeof(MyModel), "FirstName");

            Assert.That(result, Is.EqualTo(firstNamePropertyInfo));
        }

        [Test]
        public void get_by_lambda_with_instance()
        {
            var result = propertyInfoGetter.GetPropertyInfo(myModel, x => x.FirstName);

            Assert.That(result, Is.EqualTo(firstNamePropertyInfo));
        }

        [Test]
        public void get_by_lambda_with_type()
        {
            var result = propertyInfoGetter.GetPropertyInfo<MyModel>(x => x.FirstName);

            Assert.That(result, Is.EqualTo(firstNamePropertyInfo));
        }
    }
}