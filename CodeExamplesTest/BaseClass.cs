using Moq;
using System.Web;
using System.Web.Mvc;

namespace CodeExamplesTest.Tests
{
    public class BaseClass
    {
        public Mock<ControllerContext> controllerContext;
        public Mock<HttpContextBase> contextBase;

        public BaseClass(string sessionVarName, string sessionValue)
        {
            controllerContext = new Mock<ControllerContext>();
            contextBase = new Mock<HttpContextBase>();

            controllerContext.Setup(x => x.HttpContext).Returns(contextBase.Object);
            controllerContext.Setup(cc => cc.HttpContext.Session[sessionVarName]).Returns(sessionValue);
        }
        public BaseClass()
        {
        }
    }
}
