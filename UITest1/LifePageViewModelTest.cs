using NUnit.Framework;

namespace UITest1
{
    [TestFixture]
    public class LifePageViewModelTest
    {
        [Test]
        public void ExecuteNavigationCommand()
        {
            var viewModel = new LifePageViewModel();
            var command = viewModel.NavigationCommand;
            Assert.IsNotNull(command);
            Assert.IsTrue(command.CanExecute(null));
        }
    }
}
