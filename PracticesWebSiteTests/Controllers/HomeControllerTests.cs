using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticesWebSite.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticesWebSite.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            Assert.AreSame(1,1);
        }

        [TestMethod()]
        public void AboutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ContactTest()
        {
            Assert.Fail();
        }
    }
}