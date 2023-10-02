using LoggerLibrary;

namespace LoggerLibraryTests
{
    [TestFixture]
    public class LoggerTests
    {

        private StringWriter consoleOutput;

        // ћетод SetUp выполн€етс€ перед каждым тестом
        // и используетс€ дл€ настройки окружени€ теста.
        [SetUp]
        public void RedirectConsoleOutput()
        {
            consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
        }

        // ћетод TearDown выполн€етс€ после каждого теста
        // и используетс€ дл€ восстановлени€ окружени€.
        [TearDown]
        public void RestoreConsoleOutput()
        {
            // ќсвобождаем ресурсы StringWriter.
            consoleOutput.Dispose();

            // ¬осстанавливаем стандартный поток вывода консоли.
            Console.SetOut(Console.Out);
        }

        // Ётот тест провер€ет, что Logger - класс с единственным экземпл€ром.
        [Test]
        public void Logger_InstanceIsSingleton()
        {
            // Arrange
            Logger logger1 = Logger.GetInstance();
            Logger logger2 = Logger.GetInstance();

            // Act & Assert
            Assert.AreSame(logger1, logger2);
        }

        // Ётот тест провер€ет, что Logger правильно записывает сообщение в консоль.
        [Test]
        public void Logger_LogMessage_WritesToConsole()
        {
            // Arrange
            Logger logger = Logger.GetInstance();
            string message = "Test message";

            // Act
            logger.LogMessage(message);

            // Assert
            string expectedOutput = $"[{DateTime.Now}] {message}{Environment.NewLine}";
            Assert.AreEqual(expectedOutput, consoleOutput.ToString());
        }
    }
}