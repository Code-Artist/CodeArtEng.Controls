using NUnit.Framework;
using System.Net.Http.Headers;

namespace CodeArtEng.Controls.UnitTests
{
    [TestFixture]
    class LabeledTextBoxTests
    {
        [Test]
        public void ComboBoxSelectedText()
        {
            LabeledTextBox lb = new LabeledTextBox();
            lb.IsDropDownList = true;
            lb.DropDownListItems = new string[] { "Item1", "Item2", "Item3" };
            lb.DropDownListSelectedIndex = 1;

            Assert.AreEqual("Item2", lb.Text);
        }

        [Test]
        public void ComboBoxItems()
        {
            LabeledTextBox lb = new LabeledTextBox();
            lb.IsDropDownList = true;
            lb.DropDownListItems = new string[] { "Item1", "Item2", "Item3" };
            Assert.AreEqual(lb.DropDownListItems.Length, 3);
            lb.DropDownListItems = new string[] { "Test" };
            Assert.AreEqual(lb.DropDownListItems.Length, 1);
        }
    }
}
