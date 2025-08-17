using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using ATRememly.Utils;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ATRememly.Pages;

public class LoginPage
{
    private readonly AppiumDriver driver;
    private readonly WebDriverWait wait;

    public LoginPage()
    {
        driver = DriverFactory.driver!;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    }

    private By LoginButton => By.XPath("//android.widget.TextView[@text=\"I already have an account, Login\"]");
    private By ChooseLoginMethod => By.XPath("//android.widget.TextView[@text=\"Sign in with Google\"]");
    private By ChooseAccount => By.XPath("(//android.widget.LinearLayout[@resource-id='com.google.android.gms:id/container'])[1]/android.widget.LinearLayout");
    
    private By GalleryTitle => By.XPath("//android.widget.TextView[@text='Gallery']");


    public void TapLogin()
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(LoginButton)).Click();
    }

    public void ChooseGoogleLogin()
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(ChooseLoginMethod)).Click();
    }

    public void SelectAccount()
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(ChooseAccount)).Click();
    }
    public bool IsMainScreenVisible()
    {
        try
        {
            wait.Until(ExpectedConditions.ElementIsVisible(GalleryTitle));
            return true;
        }
        catch
        {
            return false;
        }
    }

}
