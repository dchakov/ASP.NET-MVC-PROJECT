namespace RealEstates.Services.Web.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IEmailHiderTests
    {
        [TestMethod]
        public void EmailShouldBeHideCorrectly()
        {
            const string Email = "pesho@gmail.com";
            IEmailHider emailHider = new EmailHider();
            var actual = emailHider.HideEmail(Email);
            Assert.AreEqual("pes**@gma**.com", actual);
        }

        [TestMethod]
        public void EmailShoudNotHideWHenThreeSymbolsInUsername()
        {
            const string Email = "pes@gmail.com";
            IEmailHider emailHider = new EmailHider();
            var actual = emailHider.HideEmail(Email);
            Assert.AreEqual("pes@gma**.com", actual);
        }

        [TestMethod]
        public void EmailShoudNotHideWHenThreeSymbolsInDomain()
        {
            const string Email = "pesho@abv.bg";
            IEmailHider emailHider = new EmailHider();
            var actual = emailHider.HideEmail(Email);
            Assert.AreEqual("pes**@abv.bg", actual);
        }
    }
}
