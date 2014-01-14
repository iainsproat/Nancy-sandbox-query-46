namespace Nancy_sandbox_query_46
{
    using System;

    using Nancy;
    using Nancy.Testing;
    using NUnit.Framework;

    [TestFixture]
    public class MyModuleTest
    {
        Browser browser;

        [SetUp]
        public void SetUp()
        {
            browser = new Browser(with =>
            {
                with.Module<MyModule>();
                with.EnableAutoRegistration();
            });
        }

        [Test]
        public void Can_Get_View()
        {
            // When
            var result = browser.Get("/path/foobar/anotherAction", with => with.HttpRequest());

            // Then
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual("Hello foobar", result.Body.AsString()); //fails as parameters.Name is always null when cast to a string
        }
    }
}
