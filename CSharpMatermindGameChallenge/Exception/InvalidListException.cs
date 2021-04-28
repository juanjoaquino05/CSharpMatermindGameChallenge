namespace CSharpMatermindGameChallenge.Exception
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class InvalidListException : Exception
    {
        public InvalidListException()
        {
        }

        public InvalidListException(string message)
            : base(message)
        {
        }

        public InvalidListException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
