namespace Boxer.Args.Verbs
{
    public class ScriptVerb : IVerb
    {
        public ScriptVerb()
        {
            Name = "script";

            //TODO: Improve help
            Help = "Use this to execute aplications in sandbox";
        }

        public string Name { get; }

        public string Help { get; }
    }
}
