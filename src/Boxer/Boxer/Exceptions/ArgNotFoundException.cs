using System;

namespace Boxer.Exceptions
{
    public class ArgNotFoundException : Exception
    {
        public ArgNotFoundException(string message) : base(message)
        {
        }
    }
}
