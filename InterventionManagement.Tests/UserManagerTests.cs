using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Models;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Tests
{
    [TestClass]
    public class UserManagerTests
    {
        [TestInitialize]
        public void Setup()
        {
            UserManager.Add(new Accountant(11, "bernie", "123", "Bernie Sanders"));
            //_sut.Add(new Accountant(12, "jjsj", "456", "John Jones-Smith, Jr."));
            UserManager.Add(new Manager(13, "funderwood", "789", "Frank Underwood", 6.50m, 400.00m,
                District.RuralIndonesia));
            UserManager.Add(new Manager(14, "cunderwood", "012", "Claire Underwood", 7.25m, 645.00m,
                District.Sydney));
            UserManager.Add(new Engineer(15, "alex", "345", "Alex Tan", 4.50m, 420.00m,
                District.Sydney));
            UserManager.Add(new Engineer(16, "kim", "678", "Kim", 6.50m, 400.00m,
                District.RuralIndonesia));
            UserManager.Add(new Engineer(17, "linda", "901", "Linda", 6.50m, 400.00m,
                District.RuralIndonesia));
            UserManager.Add(new Engineer(18, "jess", "234", "Jessica", 6.50m, 400.00m,
                District.Sydney));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            UserManager.Users.Clear();
        }

        [TestMethod]
        public void Login_CorrectDetails_UsernamesMatch()
        {

            var loginAttempt = UserManager.Login("bernie", "123");
            Assert.AreEqual(loginAttempt.Username, "bernie");

            loginAttempt = UserManager.Login("funderwood", "789");
            Assert.AreEqual(loginAttempt.Username, "funderwood");

            loginAttempt = UserManager.Login("cunderwood", "012");
            Assert.AreEqual(loginAttempt.Username, "cunderwood");

            loginAttempt = UserManager.Login("alex", "345");
            Assert.AreEqual(loginAttempt.Username, "alex");

            loginAttempt = UserManager.Login("kim", "678");
            Assert.AreEqual(loginAttempt.Username, "kim");

            loginAttempt = UserManager.Login("linda", "901");
            Assert.AreEqual(loginAttempt.Username, "linda");

            loginAttempt = UserManager.Login("jess", "234");
            Assert.AreEqual(loginAttempt.Username, "jess");
        }

        [TestMethod]
        public void Login_WrongPassword_NullUser()
        {
            var loginAttempt = UserManager.Login("bernie", "wrong");
            Assert.IsNull(loginAttempt);
            loginAttempt = UserManager.Login("bernie", "wrongagain");
            Assert.IsNull(loginAttempt);
            loginAttempt = UserManager.Login("linda", "verywrong");
            Assert.IsNull(loginAttempt);
            loginAttempt = UserManager.Login("alex", "wrong!");
            Assert.IsNull(loginAttempt);
        }

        [TestMethod]
        public void Login_BlankPassword_NullUser()
        {
            var loginAttempt = UserManager.Login("bernie", "");
            Assert.IsNull(loginAttempt);
            loginAttempt = UserManager.Login("jess", " ");
            Assert.IsNull(loginAttempt);
            loginAttempt = UserManager.Login("kim", "    ");
            Assert.IsNull(loginAttempt);
        }

        [TestMethod]
        public void Login_WrongUsername_NullUser()
        {
            var loginAttempt = UserManager.Login("wrongusername", "some password");
            Assert.IsNull(loginAttempt);
            loginAttempt = UserManager.Login("d094t", "some password");
            Assert.IsNull(loginAttempt);
            loginAttempt = UserManager.Login("dokgoi5", "some password");
            Assert.IsNull(loginAttempt);
            loginAttempt = UserManager.Login("lksjfo5", "some password!");
            Assert.IsNull(loginAttempt);
        }

        /*[TestMethod]
        [ExpectedException(typeof(NameRegexException))]
        public void CreateUser_Regex()
        {
            var test = new UserManager();

            test.Add(new Accountant(42, "hello", "password", "Alex Tan=="));
        }*/
        /*
        [TestMethod]
        public void RejectDuplicateUsernameRegistration()
        {
            _sut.Add(new Engineer(20, "popular", "secret", "Charlie", 6.50, 400.00,
                District.Sydney));
            _sut.Add(new Manager(20, "popular", "secret2", "Delta", 6.50, 400.00,
                District.Sydney));
        }
        */
    }
}
