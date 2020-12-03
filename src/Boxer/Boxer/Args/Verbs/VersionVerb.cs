namespace Boxer.Args.Verbs
{
    public class VersionVerb : IVerb
    {
        public VersionVerb()
        {
            Name = new string[] { "version", "--version", "-v" };
            Help = "Displays the version of the project in the format: MAJOR.MINOR.BUILD.REVISION";
        }

        public string[] Name { get; }

        public string Help { get; }
    }
}
