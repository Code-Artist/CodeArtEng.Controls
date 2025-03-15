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

                        Assert.That(lb.Text,Is.EqualTo("Item2"));
        }

        [Test]
        public void ComboBoxItems()
        {
            LabeledTextBox lb = new LabeledTextBox();
            lb.IsDropDownList = true;
            lb.DropDownListItems = new string[] { "Item1", "Item2", "Item3" };
                        Assert.That(3,Is.EqualTo(lb.DropDownListItems.Length));
            lb.DropDownListItems = new string[] { "Test" };
                        Assert.That(1,Is.EqualTo(lb.DropDownListItems.Length));
        }
    }
}
