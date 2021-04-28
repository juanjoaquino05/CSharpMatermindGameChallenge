using CSharpMatermindGameChallenge.Exception;
using System;
using System.Collections.Generic;

namespace CSharpMatermindGameChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<CodePeg> code = new List<CodePeg>() { CodePeg.Black, CodePeg.Green, CodePeg.White, CodePeg.Yellow };

                Mastermind game = new Mastermind(code);
                game.GetHints(code);
            }
            catch (InvalidListException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Something Happens!");
            }
        }
    }
}
