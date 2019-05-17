using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SiteHand.Core.ViewModels;

namespace UnitTestSiteHand
{
    public class SettingViewTest
    {
        SettingsViewModel ViewModel;

        [SetUp]
        public void Setup()
        {
            ViewModel = new SettingsViewModel();
        }

        [Test]
        public void LogOut() {
            ViewModel.LogOutCmd.Execute(null);
        }
    }
}
