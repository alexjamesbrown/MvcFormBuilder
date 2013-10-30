using NUnit.Framework;
using System;
using System.Text;

namespace FormBuilder.Tests
{
    [TestFixture]
    public class BuilderTests
    {
        [Test]
        public void Generate_returns_expected_markup_for_type()
        {
            var builder = new Builder();

            var result = builder.Generate(typeof(MyModel));

            Assert.That(result, Is.EqualTo(@"<label for=""FirstName"">First Name</label>
<input type=""text"" id=""FirstName"" name=""FirstName"" />
<label for=""NumberOfSomethings"">Number Of Somethings</label>
<input type=""text"" id=""NumberOfSomethings"" name=""NumberOfSomethings"" />"));
        }
    }

    public class Builder
    {
        public string Generate(Type type)
        {
            //get all public properties
            var properties = type.GetProperties();

            var sb = new StringBuilder();

            foreach (var propertyInfo in properties)
            {
                sb.AppendLine(string.Format(@"<label for=""{0}"">{1}</label>", propertyInfo.Name, AddSpacesToSentence(propertyInfo.Name, true)));
                sb.Append(string.Format(@"<input type=""text"" id=""{0}"" name=""{1}"" />", propertyInfo.Name, propertyInfo.Name));
                sb.AppendLine();
            }

            return sb.ToString().Trim();
        }

        //todo: refactor out of here
        string AddSpacesToSentence(string text, bool preserveAcronyms)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                    if ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) ||
                        (preserveAcronyms && char.IsUpper(text[i - 1]) &&
                         i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                        newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }
    }
}