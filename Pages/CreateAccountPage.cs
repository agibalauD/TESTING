
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using ATRememly.Utils;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ATRememly.Pages;

public class CreateAccountPage
{
    private readonly AppiumDriver driver;
    private readonly WebDriverWait wait;

    public CreateAccountPage()
    {
        driver = DriverFactory.driver; // глобальный драйвер
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    }

    private By CreateAccountBtn => By.XPath("//android.widget.TextView[@text=\"Create account\"]");
    private By ContinueBtn => By.XPath("//android.view.ViewGroup[@content-desc=\"Continue\"]");
    private By NameField => By.XPath("//android.widget.EditText[@text=\"Specify your name\"]");
    
    public void StartAccountCreation()
    {
        driver.FindElement(CreateAccountBtn).Click();
    }

    public void TapContinue(int times = 1)
    {
        for (int i = 0; i < times; i++)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(ContinueBtn));
            driver.FindElement(ContinueBtn).Click();
        }
    }

    public void EnterName(string name)
    {
        wait.Until(ExpectedConditions.ElementIsVisible(NameField));
        var field = driver.FindElement(NameField); // поиск поля имени
        field.Click(); // клик 
        field.SendKeys(name); // ввод текста 
    }

    public void ClosePaywallIfExists()
    {
        try
        {
            // Здесь XPath крестика, который ты нашёл в Appium Inspector
            var closeBtn =
                By.XPath(
                    "//android.widget.FrameLayout[@resource-id='app.rememly.bundleid:id/action_bar_root']//android.widget.ImageView");

            var elements = driver.FindElements(closeBtn);
            if (elements.Count > 0)
            {
                TestContext.WriteLine("Paywall найден, закрываем.");
                elements[0].Click();
            }
            else
            {
                TestContext.WriteLine("Paywall не найден — пропускаем шаг.");
            }
        }
        catch (Exception ex)
        {
            TestContext.WriteLine($"Ошибка при закрытии paywall: {ex.Message}");
        }
    }
}