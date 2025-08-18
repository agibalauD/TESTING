using ATRememly.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
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
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

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