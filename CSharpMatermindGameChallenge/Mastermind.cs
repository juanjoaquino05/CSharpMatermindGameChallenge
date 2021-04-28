
namespace CSharpMatermindGameChallenge
{
    using System.Collections.Generic;

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
            if (ValidGuessList(guess)) throw new Exception("Invalid List");
        }

        private bool ValidGuessList(List<CodePeg> guess)
        {
            // Implement the logic here
            if (ValidGuessList()) throw new Exception("Invalid List");
        }
    }


}
