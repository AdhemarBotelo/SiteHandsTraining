using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using SiteHand.Core.Services;
using SiteHand.Core.ViewModels;

namespace UnitTestSiteHand
{
    [TestFixture(Description = "Login Process")]
    public class LoginViewTest
    {
        LoginViewModel ViewModel;

        [SetUp]
        public void Setup()
        {
            var firebaseAuthMok = new Mock<IFirebaseAuthenticator>();
            firebaseAuthMok.Setup(x => x.LoginWithEmailPasswordAsync("test@jala.com", "123qwe"))
                .ReturnsAsync("asdfasdf123123123TokenFake");

            ViewModel = new LoginViewModel(firebaseAuthMok.Object);

        }

        [Test]
        public void Login()
        {
            // Arrange
            ViewModel.IsErrorAuthentication = true;
            //Act
            ViewModel.LoginCmd.Execute(null);
            //Assert
            Assert.AreEqual(false, ViewModel.IsErrorAuthentication);
        }

        [Test]
        public void Validations() {

            ViewModel.Email.Value = "no mail valid";
            Assert.IsFalse(ViewModel.Email.IsValid,"not a valid mail");

            ViewModel.Email.Value = "test@jala.com";
            Assert.IsTrue(ViewModel.Email.IsValid);

            ViewModel.Password.Value = "a";
            Assert.IsFalse(ViewModel.Password.IsValid,"not a valid password must have at least 6 characters");

            ViewModel.Password.Value = "123qwe";
            Assert.IsTrue(ViewModel.Password.IsValid);
        }
    }
}
