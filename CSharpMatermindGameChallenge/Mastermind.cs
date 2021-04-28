
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
        private List<CodePeg> code;

        public Mastermind(List<CodePeg> code)
        {
            this.code = code;
        }

        public List<ResultPeg> GetHints(List<CodePeg> guess)
        {
            // Implement the logic here
            if (!ValidGuessList(guess)) throw new InvalidListException("Invalid List");

            return null;
        }

        private bool ValidGuessList(List<CodePeg> guess)
        {
            return guess != null && guess.Count != this.code.Count; 
        }
    }


}
