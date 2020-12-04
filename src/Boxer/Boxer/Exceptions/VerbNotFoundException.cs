using System;

namespace Boxer.Exceptions
{
    public class VerbNotFoundException : Exception
    {
        public VerbNotFoundException(string message) : base(message)
        {
        }
    }
}
