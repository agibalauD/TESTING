using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;


    
namespace ATRememly.Utils
{
    public class DriverFactory
    {
        public static AndroidDriver driver;

        public static void InitDriver(string apkPath= null)
        {
            var options = new AppiumOptions(); // настройка appium 
            
            options.PlatformName = "android";
            options.DeviceName = "emulator-5554"; // имя девайса
            

            options.AutomationName = "Uiautomator2"; // драйвер 
            options.AddAdditionalAppiumOption("noReset", true);
            
            // для работы с APK файлами, нужно указать путь
            if (!string.IsNullOrEmpty(apkPath))
            {
                options.AddAdditionalAppiumOption("app", apkPath); // путь к .apk
            }
            else
            {
                // запуск через реальное устрйоство/Эмулятор без APK 
                options.AddAdditionalAppiumOption("appPackage", "app.rememly.bundleid");
                options.AddAdditionalAppiumOption("appActivity", "app.rememly.bundleid.MainActivity");
            }

            driver = new AndroidDriver
                (new Uri("http://127.0.0.1:4723/"), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public static void QuitDriver()
        {
            driver.Quit();
        }
    }
}
