using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickEmailVerification.NET;


namespace QuickEmailVerification.Tests
{
    [TestClass]
    public class VerifyTest
    {
        private Quickemailverification _quickEmail;

        [TestInitialize()]
        public void Initialize()
        {
            _quickEmail = new Quickemailverification("your_APIKey_is_Here");
        }

        [TestCleanup()]
        public void Cleanup()
        {
            _quickEmail = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task Email_Is_Empty()
        {
            var model = await _quickEmail.VerifyInfo("");
            Assert.IsNull(model);
        }

        [TestMethod]
        public async Task Email_RegExpression_Is_Invalid()
        {
            var model = await _quickEmail.VerifyInfo("email");
            Assert.IsNotNull(model);
            Assert.AreEqual(model.Code, (int)HttpStatusCode.BadRequest);
            Assert.IsFalse(model.Success);
            Assert.AreEqual(model.Message, "Email is not valid.");
        }


        //[TestMethod]
        public async Task Email_VerifyInfo_Is_Invalid()
        {
            var model = await _quickEmail.VerifyInfo("email@email.com");
            Assert.IsNotNull(model);
            Assert.AreEqual(model.Code, (int)HttpStatusCode.OK);
            Assert.IsTrue(model.Success);
            Assert.AreEqual(model.Result, "invalid");
        }


        //[TestMethod]
        public async Task Email_VerifyInfo_Is_Valid()
        {
            var model = await _quickEmail.VerifyInfo("ssemibiz@yahoo.co.kr");
            Assert.IsNotNull(model);
            Assert.AreEqual(model.Code, (int)HttpStatusCode.OK);
            Assert.IsTrue(model.Success);
            Assert.AreEqual(model.Result, "valid");
        }

        //[TestMethod]
        public async Task Email_Verify_Is_invalid()
        {
            bool flag = await _quickEmail.Verify("email@email.com");
            Assert.IsFalse(flag);
        }

        //[TestMethod]
        public async Task Email_Verify_Is_Valid()
        {
            bool flag = await _quickEmail.Verify("ssemibiz@yahoo.co.kr");
            Assert.IsTrue(flag);
        }


        //[TestMethod]
        public async Task Email_Verify_Is_Force_Valid()
        {
            bool flag = await _quickEmail.Verify("ssemibiz@yahoo.co.kr", true);
            Assert.IsTrue(flag);
        }
    }
}
