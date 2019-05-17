using System.Threading.Tasks;
using NUnit.Framework;
using SiteHand.Core.ViewModels;

namespace UnitTestSiteHand
{
    public class DetailBookViewTest
    {
        DetailBookViewModel ViewModel;

        [SetUp]
        public void Setup()
        {

            ViewModel = new DetailBookViewModel("IdVolume");
        }

        [Test]
        public async Task GetDetailBook()
        {
            //Assert
            Assert.IsFalse(ViewModel.IsNotFound);
        }
    }
}
