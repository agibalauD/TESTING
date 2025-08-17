using NUnit.Framework;
using ATRememly.Pages;
using ATRememly.Utils;

namespace AtRememly.Tests
{
    public class CreateAccountTest
    {
        private CreateAccountPage page;

        [SetUp]
        public void Setup()
        {
            DriverFactory.InitDriver();
            page = new CreateAccountPage();
        }
        // основной тест что пользователь проходит онбординг и попадает на главную страницу 
        [Test]
        public void FullOnbordingFlow()
        {
            TestContext.WriteLine("Шаг 1: Кликаем 'Create Account'");
            page.StartAccountCreation();

            TestContext.WriteLine("Шаг 2: Два экрана 'Continue'");
            page.TapContinue(2); // два раза нажимаем "Continue"

            TestContext.WriteLine("Шаг 3: Вводим имя");
            page.EnterName("auto-test");

            TestContext.WriteLine("Шаг 4: Продолжаем после имени");
            page.TapContinue(); // после ввода имени

            TestContext.WriteLine("Шаг 5: Последний экран перед пейволлом");
            page.TapContinue();
            
            TestContext.WriteLine("Закрытие пейволл");
            page.ClosePaywallIfExists();
            
            // решить вопрос как скипнуть пейвалл 
            
            TestContext.WriteLine("Пользователь успешно прошёл регистрацию!");
        }

        [TearDown]
        public void Cleanup()
        {
            DriverFactory.QuitDriver();
        }
    }
}

