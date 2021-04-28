
namespace CSharpMatermindGameChallenge
{
    using System.Collections.Generic;
    using Exception;

    public enum CodePeg
    {
        Black,
        Blue,
        Green,
        Red,
        White,
        Yellow,
    }

    public enum ResultPeg
    {
        Black,
        White,
    }

    public class Mastermind
    {
        private List<CodePeg> code; // Code made by the codemaker

        public Mastermind(List<CodePeg> code)
        {
            this.code = code;
        }

        // Method called when the codebreaker tries to guess
        public List<ResultPeg> GetHints(List<CodePeg> guess)
        {
            if (!Rules.ValidGuessList(code, guess)) throw new InvalidListException("Invalid List");

            List<ResultPeg> hints = StartGuess(code, guess);

            // Return result
            return hints;
        }

        // Method called when a valid list is passed and compare it with the code
        public List<ResultPeg> StartGuess(List<CodePeg> code, List<CodePeg> guess)
        {
            List<ResultPeg> results = new List<ResultPeg>();

            // Create another list of code to not alter the original
            List<CodePeg> copyCode = new List<CodePeg>(code);

            // We first evaluate black to remove it in case they match 
            Logic.GetBlacks(copyCode, guess, results);

            // Then we get the whites ones
            Logic.GetWhites(copyCode, guess, results);

            return results;
        }
    }
}
