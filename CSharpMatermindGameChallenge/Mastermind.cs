
namespace Mastermind
{
    using System.Collections.Generic;
    using System;
    using System.Threading;
    using System.Collections;

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

            // Shuffle hints
            hints.Shuffle();

            // Return result
            return hints;
        }

        // Method called when a valid list is passed and compare it with the code
        public List<ResultPeg> StartGuess(List<CodePeg> code, List<CodePeg> guess)
        {
            List<ResultPeg> results = new List<ResultPeg>();

            // We first evaluate black to remove it in case they match 
            List<int> unevaluatedCodePegs = Logic.GetBlacks(code, guess, results);

            // Then we get the whites ones
            Logic.GetWhites(code, unevaluatedCodePegs, guess, results);

            return results;
        }
    }
    public static class ThreadSafeRandom
    {
        [ThreadStatic] private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }

    static class Extensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    public class Logic
    {
        //Methods that evaluates black ocurrences
        public static List<int> GetBlacks(List<CodePeg> code, List<CodePeg> guess, List<ResultPeg> hints)
        {
            List<int> leftCode = new List<int>();

            int codeCount = code.Count;
            for (int codeIndex = 0, guessIndex = 0; codeIndex < codeCount; codeIndex++, guessIndex++)
            {
                //Both color and position are equal
                if (code[codeIndex].Equals(guess[guessIndex]))
                {
                    hints.Add(ResultPeg.Black);
                    guess.RemoveAt(guessIndex);
                    guessIndex--;
                }
                else
                {
                    leftCode.Add(codeIndex);
                }
            }

            return leftCode;
        }

        //Methods that evaluates white ocurrences
        public static void GetWhites(List<CodePeg> code, List<int> toEvaluateIndexes, List<CodePeg> guess, List<ResultPeg> hints)
        {
            for (int x = 0; x < guess.Count; x++)
            {
                for (int y = 0; y < toEvaluateIndexes.Count; y++)
                {
                    if (code[toEvaluateIndexes[y]].Equals(guess[x]))
                    {
                        hints.Add(ResultPeg.White);
                        break;
                    };
                }
            }
        }
    }

    public class Rules
    {
        // Method that validates List
        public static bool ValidGuessList(List<CodePeg> code, List<CodePeg> guess)
        {
            // List is not null and contains the same pegs as code
            return guess != null && guess.Count == code.Count;
        }
    }

    public class InvalidListException : Exception
    {
        public InvalidListException() { }
        public InvalidListException(string message) : base(message) { }
        public InvalidListException(string message, Exception inner) : base(message, inner) { }
    }
}
