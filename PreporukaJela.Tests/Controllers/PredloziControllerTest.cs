using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PreporukaJela.Controllers;

namespace PreporukaJela.Tests.Controllers
{
    [TestClass]
    public class PredloziControllerTest
    {
        [TestMethod]
        public void Index()
        {
            PredloziController controller = new PredloziController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
