
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using superaccount;


namespace UnitTest {
    [TestClass]
    public class UnitTestAccount {
    

            [TestMethod()]
            public void AddResourceTest()
            {
                SuperAccount admin = new SuperAccount();
                Dictionary<string, string> resource_info = new Dictionary<string, string>
            {
                { "resourceID" , "1000" },
                {  "positionX"  , "50" },
                {  "positionY"  , "50" },
                {  "positionZ"  , "2" },
                { "isUsable"   , "true" },
                { "isWithPower", "true" },
                { "isNearWindow","false" }
            };
                Assert.AreEqual(cz.Error.OK, admin.AddResource(ref resource_info));
                Dictionary<string, string> resource_info2 = new Dictionary<string, string>
            {
                { "resourceID" , null },
                {  "positionX"  , "50" },
                {  "positionY"  , "50" },
                {  "positionZ"  , "2" },
                { "isUsable"   , "true" },
                { "isWithPower", "true" },
                { "isNearWindow","false" }
            };
                Assert.AreEqual(cz.Error.PARAM_FORMAT_ERROR, admin.AddResource(ref resource_info2));


            }

            [TestMethod()]
            public void DelResourceTest()
            {

            SuperAccount admin = new SuperAccount();
            Dictionary<string, string> resource_info = new Dictionary<string, string>
            {
                { "resourceID" , "1000" }
            };
                Assert.AreEqual(cz.Error.OK, admin.DelResource(ref resource_info));
               Assert.AreEqual(cz.Error.RES_UNEXISTED, admin.DelResource(ref resource_info));

            }


            [TestMethod()]
            public void UpdateResourceTest()
            {
                SuperAccount admin = new SuperAccount();
                Dictionary<string, string> resource_info = new Dictionary<string, string>
            {
                { "resourceID" , "1000" },
                {  "positionX"  , "50" },
                {  "positionY"  , "50" },
                {  "positionZ"  , "2" },
                { "isUsable"   , "true" },
                { "isWithPower", "true" },
                { "isNearWindow","false" }
            };
                Assert.AreEqual(cz.Error.RES_UNEXISTED, admin.UpdateResource(ref resource_info));
                Dictionary<string, string> resource_info2 = new Dictionary<string, string>
            {
                { "resourceID" , null },
                {  "positionX"  , "50" },
                {  "positionY"  , "50" },
                {  "positionZ"  , "2" },
                { "isUsable"   , "true" },
                { "isWithPower", "true" },
                { "isNearWindow","false" }
            };
                Assert.AreEqual(cz.Error.PARAM_FORMAT_ERROR, admin.UpdateResource(ref resource_info2));
                Dictionary<string, string> resource_info3 = new Dictionary<string, string>
            {
                { "resourceID" , "1" },
                {  "positionX"  , "50" },
                {  "positionY"  , "50" },
                {  "positionZ"  , "2" },
                { "isUsable"   , "true" },
                { "isWithPower", "true" },
                { "isNearWindow","false" }
            };
                Assert.AreEqual(cz.Error.OK, admin.UpdateResource(ref resource_info3));

            }


            [TestMethod()]
            public void DelUserTest()
            {

                SuperAccount admin = new SuperAccount();
                Dictionary<string, string> user_info = new Dictionary<string, string>
            {
                { "usrID" , "20170009" }
            };
                Assert.AreEqual(cz.Error.OK, admin.DelUser(ref user_info));
                Assert.AreEqual(cz.Error.USER_UNEXISTED, admin.DelUser(ref user_info));
            }

        }
    }

