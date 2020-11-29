namespace Boxer
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[] { "-f", @"C:/test.ps1", "--scoop", "git, curl, fiddler", "-s", "Start-Process .", "--chocolatey", "vscode", "-s", "start-process facebook.com", "-f", @"C:/test2.ps1" };

            CommandLineArgsProcessor.Parse(args);
        }
    }
}
