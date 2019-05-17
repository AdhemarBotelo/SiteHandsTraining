using Moq;
using NUnit.Framework;
using SiteHand.Core.Services;
using SiteHand.Core.ViewModels;

namespace UnitTestSiteHand
{
    public class ListBooksViewTest
    {
        ListBooksViewModel ViewModel;
        RestClient restClient;

        [SetUp]
        public void Setup()
        {
            var firebaseRemoteConfMok = new Mock<IRemoteConfig>();
            firebaseRemoteConfMok.Setup(x => x.GetRemoteDataString("Print_Type"))
                .Returns("books");

            ViewModel = new ListBooksViewModel(firebaseRemoteConfMok.Object);
            restClient = new Mock<RestClient>().Object;
        }

        [Test]
        public void LoadItems()
        {
            ViewModel.IsNotFound = true;

            ViewModel.LoadItemsCommand.Execute(null);

            var items = ViewModel.Items;

            Assert.AreEqual("books", ViewModel.type.ToString());
            Assert.IsFalse(ViewModel.IsNotFound);
        }
    }
}
