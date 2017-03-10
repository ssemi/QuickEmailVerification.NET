using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickEmailVerification.NET;
using System.Threading.Tasks;


namespace QuickEmailVerification.Tests
{
    [TestClass]
    public class ApiTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Apikey_is_Empty()
        {
            var quickEmail = new Quickemailverification("");
            var flag = await quickEmail.Verify("email@email.com");
            Assert.IsFalse(flag);
        }

        [TestMethod]
        public async Task Apikey_is_Not_Valid()
        {
            var quickEmail = new Quickemailverification("apikey");
            var result = await quickEmail.VerifyInfo("email@email.com");
            Assert.AreEqual(result.Code, (int)HttpStatusCode.Unauthorized);
            Assert.IsFalse(result.Success);
            Assert.AreEqual(result.Message, "Invalid api key");
        }
    }
}
