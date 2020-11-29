namespace Boxer.Args.Verbs
{
    public class ScriptVerb : IVerb
    {
        public ScriptVerb()
        {
            Name = "script";
            Help = "Executes scripts and installs aplications in sandbox";
        }

        public string Name { get; }

        public string Help { get; }
    }
}
