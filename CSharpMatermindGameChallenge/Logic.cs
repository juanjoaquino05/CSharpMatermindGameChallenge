using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpMatermindGameChallenge
{
    public class Logic
    {//Methods that evaluates black ocurrences
        public static void GetBlacks(List<CodePeg> code, List<CodePeg> guess, List<ResultPeg> hints)
        {
            for (int x = 0; x < code.Count; x++)
            {
                //Both color and position are equal
                if (code[x].Equals(guess[x]))
                {
                    hints.Add(ResultPeg.Black);
                    code.RemoveAt(x);
                    guess.RemoveAt(x);
                }
            }
        }

        //Methods that evaluates white ocurrences
        public static void GetWhites(List<CodePeg> code, List<CodePeg> guess, List<ResultPeg> hints)
        {
            for (int x = 0; x < guess.Count; x++)
            {
                for (int y = 0; y < code.Count; y++)
                {
                    if (code[y].Equals(guess[x]))
                    {
                        hints.Add(ResultPeg.White);
                        break;
                    };
                }
            }
        }
    }
}
