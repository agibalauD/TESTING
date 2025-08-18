
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace ATRememly.Utils

{
    public static class ScreenshotExample
    {
        private static int screenshotCounter = 1;  
        private static int counterInitialized = 1;
        
           

        /// <summary>
        /// Делает скриншот эмулятора и сохраняет его как screenshot{N}.png.
        /// Возвращает полный путь к сохранённому файлу.
        /// </summary>
        /// <param name="driver">Экземпляр AppiumDriver из DriverFactory</param>
        /// <param name="folder">
        /// Куда сохранять (по умолчанию: {CurrentDirectory}/Screenshots)
        /// </param>
        /// <param name="prefix">Префикс имени файла (по умолчанию: "screenshot")</param>
        public static string TakeScreenshot(AppiumDriver driver, string? folder = null, string prefix = "screenshot")
        {
            if (driver == null) throw new ArgumentNullException(nameof(driver));
            
            folder ??= @"C:\Users\Daniel\Desktop\testing\screenshots";
            
            //folder ??= Path.Combine(Directory.GetCurrentDirectory(), "Screenshots"); для тестов на других машинах
            
            Directory.CreateDirectory(folder);
            EnsureCounterInitialized(folder, prefix);
            
            int index = Interlocked.Increment(ref screenshotCounter);
            
            string fileName = $"{prefix}{index}.png";
            string filePath = Path.Combine(folder, fileName);
            
            var shot = ((ITakesScreenshot)driver).GetScreenshot();
            File.WriteAllBytes(filePath, shot.AsByteArray);
            
            Console.WriteLine($"[INFO] Скриншот сохранён: {filePath}");
            return filePath;
            
        }
        private static void EnsureCounterInitialized(string folder, string prefix)
        {
            // Инициализируем счётчик по существующим файлам один раз
            if (Interlocked.CompareExchange(ref counterInitialized, 1, 0) != 0) return;

            int maxExisting = Directory.EnumerateFiles(folder, $"{prefix}*.png")
                .Select(Path.GetFileNameWithoutExtension)
                .Select(name =>
                {
                    var suffix = name!.Substring(prefix.Length);
                    return int.TryParse(suffix, out var n) ? n : 0;
                })
                .DefaultIfEmpty(0)
                .Max();

            screenshotCounter = maxExisting;
        }
    }
}