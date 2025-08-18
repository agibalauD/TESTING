using ATRememly.Utils;
using NUnit.Framework;
using OpenQA.Selenium.Appium;

namespace AtRememly.Tests
{
    public class ScreenshotTest
    {
        private AppiumDriver driver;
        
        [SetUp]
        public void Setup()
        {
            DriverFactory.InitDriver();
        }

        [Test]
        public void MakeScreenshot()
        {
            ScreenshotExample.TakeScreenshot(driver);
            Console.WriteLine("Screenshot taken");
        }
        [TearDown]
        public void Cleanup()
        {
            DriverFactory.QuitDriver();
        }
    }
}