using ATRememly.Pages;
using ATRememly.Utils;
       
namespace AtRememly.Tests;

[TestFixture]
public class LoginTest
{
    private LoginPage _page;

    [SetUp]
    public void Setup()
    {
        DriverFactory.InitDriver();
        _page = new LoginPage();
    }
[Test]
public void Login()
    {
        TestContext.WriteLine("тап по кнопке логина");
        _page.TapLogin();
        
        TestContext.WriteLine("тап по выбору google аккаунта");
        _page.ChooseGoogleLogin();
        
        TestContext.WriteLine("Выбор аккаунта google");
        _page.SelectAccount();
        
        TestContext.WriteLine("Проверка попадания на главный экран");
        bool isMainVisible = _page.IsMainScreenVisible();
        
        Assert.That(isMainVisible, "Главный экран не отобразился, логин прошёл некорректно.");
        TestContext.WriteLine("Успешный вход. Тест пройден");
    }
    [TearDown]
    public void Cleanup()
    {
        DriverFactory.QuitDriver();
    }
}