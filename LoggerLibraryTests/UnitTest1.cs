using LoggerLibrary;

namespace LoggerLibraryTests
{
    [TestFixture]
    public class LoggerTests
    {

        private StringWriter consoleOutput;

        // ����� SetUp ����������� ����� ������ ������
        // � ������������ ��� ��������� ��������� �����.
        [SetUp]
        public void RedirectConsoleOutput()
        {
            consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
        }

        // ����� TearDown ����������� ����� ������� �����
        // � ������������ ��� �������������� ���������.
        [TearDown]
        public void RestoreConsoleOutput()
        {
            // ����������� ������� StringWriter.
            consoleOutput.Dispose();

            // ��������������� ����������� ����� ������ �������.
            Console.SetOut(Console.Out);
        }

        // ���� ���� ���������, ��� Logger - ����� � ������������ �����������.
        [Test]
        public void Logger_InstanceIsSingleton()
        {
            // Arrange
            Logger logger1 = Logger.GetInstance();
            Logger logger2 = Logger.GetInstance();

            // Act & Assert
            Assert.AreSame(logger1, logger2);
        }

        // ���� ���� ���������, ��� Logger ��������� ���������� ��������� � �������.
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