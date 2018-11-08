using System.Web.Mvc;
using AzurePipe.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzurePipeTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        
        public void Index_ActionResult_Returns_Correct_ViewBag_Result()
        {
            HomeController controllerTest = new HomeController();
            var result = controllerTest.Index() as ViewResult;
            Assert.AreEqual("Hello World!", result.ViewData["Message"]);
        }
    }
}
