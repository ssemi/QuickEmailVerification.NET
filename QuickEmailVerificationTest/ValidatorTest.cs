using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickEmailVerification.NET;
using System.Threading.Tasks;


namespace QuickEmailVerification.Tests
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        public void IsDomain_is_False()
        {
            bool flag = Validator.IsDomain("sss@abc11333.com");
            Assert.IsFalse(flag);
            flag = Validator.IsDomain("sss");
            Assert.IsFalse(flag);
            flag = Validator.IsDomain("sss@");
            Assert.IsFalse(flag);
            flag = Validator.IsDomain("sss@111");
            Assert.IsFalse(flag);
        }

        [TestMethod]
        public void IsDomain_is_True()
        {
            bool flag = Validator.IsDomain("ssemibiz@yahoo.co.kr");
            Assert.IsTrue(flag);
        }
        
    }
}
