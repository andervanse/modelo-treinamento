using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControlePendencias.Web.Controllers;
using System.Web.Mvc;

namespace ControlePendencias.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            using (HomeController controller = new HomeController())
            {
                // Act
                ViewResult result = controller.Index() as ViewResult;

                // Assert
                Assert.IsNotNull(result);
            }
        }       
    }
}
