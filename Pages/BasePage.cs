using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ATRememly.Utils;

namespace ATRememly.Pages;

public class BasePage
{
    protected readonly AppiumDriver _driver;
    protected readonly WebDriverWait _wait;

    public BasePage()
    {
        _driver = DriverFactory.driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
    }

    protected IWebElement WaitForElement(By Locator)
    {
        return _wait.Until(ExpectedConditions.ElementExists(Locator));
    }

    protected bool IsElemetVisible(By Locator)
    {
        try
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(Locator));
            return true;
        }
        catch
        {
            return false;
        }
    }
}
        
        
    
