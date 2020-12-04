using System;

namespace Boxer.Exceptions
{
    public class ParamNotFoundException : Exception
    {
        public ParamNotFoundException(string message) : base(message)
        {
        }
    }
}
