using NUnit.Framework;

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
    }
}
