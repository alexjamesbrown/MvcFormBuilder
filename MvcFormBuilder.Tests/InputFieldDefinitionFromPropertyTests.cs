using NUnit.Framework;

namespace FormBuilder.Tests
{
    public class MyModel
    {
        public string FirstName { get; set; }
        public int NumberOfSomethings { get; set; }
    }

    [TestFixture]
    public class InputFieldDefinitionFromPropertyTests
    {
        private MyModel myModel;

        [SetUp]
        public void SetUp()
        {
            myModel = new MyModel();
        }

        [Test]
        public void returns_definition_with_input_type_for_property_of_type_string()
        {
            var fieldDefinitionFromProperty = new InputFieldDefinitionFromProperty();
            var result = fieldDefinitionFromProperty.Get(typeof(MyModel), "FirstName");

            Assert.That(result.Type, Is.EqualTo(FieldType.Input));
        }

        [Test]
        public void returns_definition_with_input_type_for_property_of_type_int()
        {
            var fieldDefinitionFromProperty = new InputFieldDefinitionFromProperty();
            var result = fieldDefinitionFromProperty.Get(typeof(MyModel), "NumberOfSomethings");

            Assert.That(result.Type, Is.EqualTo(FieldType.Input));
        }
    }
}
