// 时间: 2019-12-9
// 版本: 19.12.9
// 摘要: 这个文件中包含了对Class Account的测试
// 作者: 章星明
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using cz;

namespace UnitTest {
    [TestClass]
    public class UnitTestAccount {
        [TestMethod]
        public void TestRegister() {
            Account root = new Account();
            Dictionary<string, string> register = new Dictionary<string, string> {
                { "name", "chauncey zhang" },
                { "gender", "男" },
                { "usrID", "120171388" },
                { "usrPwd", "123456" }
            };
            Assert.AreEqual(Error.OK, root.Register(ref register));

            Dictionary<string, string> register1 = new Dictionary<string, string> {
                { "name", "chauncey zhang" },
                { "gender", "男" },
                { "usrID", "2017138" },
                { "usrPwd", "123456" },
            };
            Assert.AreEqual(Error.USER_REGISTERED, root.Register(ref register1));

            Dictionary<string, string> register2 = new Dictionary<string, string> {
                { "name", "chauncey zhang" },
                { "stu_id", "2017138" },
                { "pwd", "123456" },
                { "privilege", "0" }
            };
            Assert.AreEqual(Error.PARAM_FORMAT_ERROR, root.Register(ref register2));
        }

        [TestMethod]
        public void TestLogin() {
            Account root = new Account();
            Dictionary<string, string> login = new Dictionary<string, string> {
                { "usrID", "2017138" },
                { "usrPwd", "123456" }
            };
            Assert.AreEqual(Error.OK, root.Login(ref login));

            Dictionary<string, string> login2 = new Dictionary<string, string> {
                { "usrID", "2017111" },
                { "usrPwd", "123456" }
            };
            Assert.AreEqual(Error.USER_UNEXISTED, root.Login(ref login2));

            Dictionary<string, string> login3 = new Dictionary<string, string> {
                { "usrID", "2017138" },
                { "usrPwd", "12356" }
            };
            Assert.AreEqual(Error.USER_PWD_ERROR, root.Login(ref login3));

            Dictionary<string, string> login4 = new Dictionary<string, string> {
                { "usrID", "2017138" },
                { "pwd", "2333" }
            };
            Assert.AreEqual(Error.PARAM_FORMAT_ERROR, root.Login(ref login4));
        }

        [TestMethod]
        public void TestAccountDetails() {
            Account root = new Account();
            Dictionary<string, string> details = new Dictionary<string, string>();
            Assert.AreEqual(true, root.AccountDetails(ref details, 2017138, "123456") == Error.OK);
            Assert.AreEqual("123456", details["usrPwd"]);

            Dictionary<string, string> details1 = new Dictionary<string, string>();
            Assert.AreEqual(true, root.AccountDetails(ref details1, 2017138, "12456") == Error.USER_PWD_ERROR);

            Dictionary<string, string> details2 = new Dictionary<string, string>();
            Assert.AreEqual(true, root.AccountDetails(ref details2, 2017, "12456") == Error.USER_UNEXISTED);
        }
    }
}
