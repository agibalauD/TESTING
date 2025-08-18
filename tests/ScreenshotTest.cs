using ATRememly.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using System.IO;

namespace AtRememly.Tests
{
    public class ScreenshotTest
    {
   

        [SetUp]
        public void Setup()
        {
            DriverFactory.InitDriver();
        }

        [Test]
        public void TakeScreenshotTest()
        {
            Screenshot screenshot = ((ITakesScreenshot).GetScreenshot();
            

            var path = Path.Combine(Directory.GetCurrentDirectory(), "screenshotClosely.png");
            screenshot.SaveAsFile("screenshot.png");
            Console.WriteLine($"Screenshot saved to: {path}");
        }

        [TearDown]
        public void Cleanup()
        {
            DriverFactory.QuitDriver();
        }
    }
}