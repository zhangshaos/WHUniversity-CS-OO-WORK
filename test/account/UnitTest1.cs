// 时间: 2019-11-29
// 版本: 19.11.29
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
                { "gender", "male" },
                { "stu_id", "2017138" },
                { "pwd", "123456" },
                { "privilege", "0" }
            };
            Assert.AreEqual(Error.USER_REGISTERED, root.Register(ref register));

            Dictionary<string, string> register1 = new Dictionary<string, string> {
                { "name", "chauncey zhang" },
                { "gender", "male" },
                { "stu_id", null }, // 主键不可以为空,其他可以
                { "pwd", "123456" },
                { "privilege", "0" }
            };
            Assert.AreEqual(Error.PARAM_FORMAT_ERROR, root.Register(ref register1));

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
                { "stu_id", "2017138" },
                { "pwd", "123456" }
            };
            Assert.AreEqual(Error.OK, root.Login(ref login));

            Dictionary<string, string> login2 = new Dictionary<string, string> {
                { "stu_id", "2017111" },
                { "pwd", "123456" }
            };
            Assert.AreEqual(Error.USER_UNEXISTED, root.Login(ref login2));

            Dictionary<string, string> login3 = new Dictionary<string, string> {
                { "stu_id", "2017138" },
                { "pwd", "12356" }
            };
            Assert.AreEqual(Error.USER_PWD_ERROR, root.Login(ref login3));

            Dictionary<string, string> login4 = new Dictionary<string, string> {
                { "stu_id", "2017138" },
                { "pwd", null }
            };
            Assert.AreEqual(Error.USER_PWD_ERROR, root.Login(ref login4));
        }

        [TestMethod]
        public void TestAccountDetails() {
            Account root = new Account();
            Dictionary<string, string> details = root.AccountDetails(2017138, "123456");
            Assert.AreEqual(true, details["valid"] == "true");
            Assert.AreEqual(false, details.ContainsKey("msg"));

            Dictionary<string, string> details1 = root.AccountDetails(2017138, "12456");
            Assert.AreEqual(true, details1["valid"] == "false");

            Dictionary<string, string> details2 = root.AccountDetails(2017, "12456");
            Assert.AreEqual(true, details2["valid"] == "false");
        }
    }
}
