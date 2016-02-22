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
            const string email = "pesho@gmail.com";
            IEmailHider emailHider = new EmailHider();
            var actual = emailHider.HideEmail(email);
            Assert.AreEqual("pes**@gma**.com", actual);
        }

        [TestMethod]
        public void EmailShoudNotHideWHenThreeSymbolsInUsername()
        {
            const string email = "pes@gmail.com";
            IEmailHider emailHider = new EmailHider();
            var actual = emailHider.HideEmail(email);
            Assert.AreEqual("pes@gma**.com", actual);
        }

        [TestMethod]
        public void EmailShoudNotHideWHenThreeSymbolsInDomain()
        {
            const string email = "pesho@abv.bg";
            IEmailHider emailHider = new EmailHider();
            var actual = emailHider.HideEmail(email);
            Assert.AreEqual("pes**@abv.bg", actual);
        }
    }
}
