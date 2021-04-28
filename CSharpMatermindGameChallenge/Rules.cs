using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMatermindGameChallenge
{
    public class Rules
    {
        // Method that validates List
        public static bool ValidGuessList(List<CodePeg> code, List<CodePeg> guess)
        {
            // List is not null and contains the same pegs as code
            return guess != null && guess.Count == code.Count;
        }
    }
}
