using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Tests
{
    [TestClass]
    public class LoginTests
    {
        private Users sut = new Users();

        public LoginTests()
        {
            sut.Add(new Accountant(11, "bernie", "123", "Bernie Sanders"));
            sut.Add(new Accountant(12, "trump", "456", "Donald Trump"));
            sut.Add(new Manager(13, "funderwood", "789", "Frank Underwood", 6.50, 400.00,
                DistrictName.RuralIndonesia));
            sut.Add(new Manager(14, "cunderwood", "012", "Claire Underwood", 7.25, 645.00,
                DistrictName.Sydney));
            sut.Add(new Engineer(15, "alex", "345", "Alex Tan", 4.50, 420.00,
                DistrictName.Sydney));
            sut.Add(new Engineer(16, "kim", "678", "Kim", 6.50, 400.00,
                DistrictName.RuralIndonesia));
            sut.Add(new Engineer(17, "linda", "901", "Linda", 6.50, 400.00,
                DistrictName.RuralIndonesia));
            sut.Add(new Engineer(18, "jess", "234", "Jessica", 6.50, 400.00,
                DistrictName.Sydney));
        }

        [TestMethod]
        public void Login_With_CorrectDetails()
        {

            var loginAttempt = sut.Login("bernie", "123");
            Assert.AreEqual(loginAttempt.Username, "bernie");

            loginAttempt = sut.Login("trump", "456");
            Assert.AreEqual(loginAttempt.Username, "trump");

            loginAttempt = sut.Login("funderwood", "789");
            Assert.AreEqual(loginAttempt.Username, "funderwood");

            loginAttempt = sut.Login("cunderwood", "012");
            Assert.AreEqual(loginAttempt.Username, "cunderwood");

            loginAttempt = sut.Login("alex", "345");
            Assert.AreEqual(loginAttempt.Username, "alex");

            loginAttempt = sut.Login("kim", "678");
            Assert.AreEqual(loginAttempt.Username, "kim");

            loginAttempt = sut.Login("linda", "901");
            Assert.AreEqual(loginAttempt.Username, "linda");

            loginAttempt = sut.Login("jess", "234");
            Assert.AreEqual(loginAttempt.Username, "jess");
        }

        [TestMethod]
        public void NotLogin_With_WrongPassword()
        {
            var loginAttempt = sut.Login("bernie", "wrong");
            Assert.IsNull(loginAttempt);
            loginAttempt = sut.Login("bernie", "wrongagain");
            Assert.IsNull(loginAttempt);
            loginAttempt = sut.Login("linda", "verywrong");
            Assert.IsNull(loginAttempt);
            loginAttempt = sut.Login("alex", "wrong!");
            Assert.IsNull(loginAttempt);
        }

        [TestMethod]
        public void NotLogin_With_BlankOrWhitespaced_Password()
        {
            var loginAttempt = sut.Login("bernie", "");
            Assert.IsNull(loginAttempt);
            loginAttempt = sut.Login("jess", " ");
            Assert.IsNull(loginAttempt);
            loginAttempt = sut.Login("kim", "    ");
            Assert.IsNull(loginAttempt);
        }

        [TestMethod]
        public void NotLogin_With_WrongUsername()
        {
            var loginAttempt = sut.Login("wrongusername", "some password");
            Assert.IsNull(loginAttempt);
            loginAttempt = sut.Login("d094t", "some password");
            Assert.IsNull(loginAttempt);
            loginAttempt = sut.Login("dokgoi5", "some password");
            Assert.IsNull(loginAttempt);
            loginAttempt = sut.Login("lksjfo5", "some password!");
            Assert.IsNull(loginAttempt);
        }

        [TestMethod]
        public void RejectDuplicateUsernameRegistration()
        {
            sut.Add(new Engineer(20, "popular", "secret", "Charlie", 6.50, 400.00,
                DistrictName.Sydney));
            sut.Add(new Manager(20, "popular", "secret2", "Delta", 6.50, 400.00,
                DistrictName.Sydney));
        }
    }
}
