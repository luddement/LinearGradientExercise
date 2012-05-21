using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using LinearGradientExercise.Controllers;
using LinearGradientExerciseTests.Setup;
using NUnit.Framework;
using Nancy;
using Nancy.Testing;
using LinearGradientExercise;

namespace LinearGradientExerciseTests.IntegrationTests
{
    [TestFixture]
    public class LinearGradientExerciseTests
    {
        private const string VerticalLinearGradientFF0000RequestUrl = "/verticalLinearGradient/ff0000";
        private Browser browser;

        [SetUp]
        public void Setup()
        {
            var homeModule = new HomeModule();

            var bootstrapper = new ConfigurableBootstrapper(with =>
            {
                with.RootPathProvider<CustomPathProvider>();
            });

            browser = new Browser(bootstrapper);
        }

        [Test]
        public void Response_ShouldReturnStatusOk_WhenRouteAndColorExists()
        {
            var response = DoGetRequest(VerticalLinearGradientFF0000RequestUrl);

            Assert.That(response.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        public void Response_ShouldReturnStatusError_WhenColorIsInvalid()
        {
            var response = DoGetRequest("/verticalLinearGradient/ff000z");

            Assert.That(response.StatusCode == HttpStatusCode.InternalServerError);
        }
        
        [Test]
        public void Response_ShouldReturnASvg()
        {
            var response = DoGetRequest(VerticalLinearGradientFF0000RequestUrl)
                .BodyAsXml();

            var svg = FindElement(response, "svg");

            Assert.That(svg != null);
        }

        [Test]
        public void Response_ShouldReturnAVerticalLinearGradient()
        {
            var response = DoGetRequest(VerticalLinearGradientFF0000RequestUrl)
                .BodyAsXml();

            var linearGradient = FindElement(response, "linearGradient");
            var isVertical = linearGradient.Attribute("y2").Value.Equals("100%");

            Assert.That(linearGradient != null);
            Assert.That(isVertical);
        }

        [Test]
        public void Response_LinearGradient_ShouldContain5Stops()
        {
            var response = DoGetRequest(VerticalLinearGradientFF0000RequestUrl)
                .BodyAsXml();

            var linearGradient = FindElement(response, "linearGradient");
            var stops = FindElements(linearGradient, "stop");

            Assert.That(stops.Count == 5);
        }

        [Test]
        [TestCase(0, "0%", "#FFCCCC")]
        [TestCase(1, "5%", "#FF9999")]
        [TestCase(2, "45%", "#FF6666")]
        [TestCase(3, "50%", "#F26161")]
        [TestCase(4, "100%", "#993D3D")]
        public void Response_LinearGradientStops_ShouldContainCorrectOffsetAndStopColor(int index, string offset, string stopColor)
        {
            var response = DoGetRequest(VerticalLinearGradientFF0000RequestUrl)
                .BodyAsXml();

            var linearGradient = FindElement(response, "linearGradient");
            var stop = FindElements(linearGradient, "stop")[index];

            Assert.That(stop.Attribute("offset").Value.Equals(offset));
            Assert.That(stop.Attribute("stop-color").Value.Equals(stopColor));
        }

        private BrowserResponse DoGetRequest(string url)
        {
            return browser.Get(url, with => with.HttpRequest());
        }

        private static XElement FindElement(XDocument result, string element)
        {
            return result.Descendants()
                .Where(x => x.Name.LocalName == element)
                .FirstOrDefault();
        }

        private static List<XElement> FindElements(XElement result, string element)
        {
            return result.Descendants()
                .Where(x => x.Name.LocalName == element)
                .ToList();
        }
    }

}
