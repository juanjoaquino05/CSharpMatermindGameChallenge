
using System;
using System.Collections.Generic;

namespace Mastermind
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Initial code
                List<CodePeg> code = new List<CodePeg>() { CodePeg.Black, CodePeg.White, CodePeg.Yellow, CodePeg.White };

                // Starting game
                Mastermind game = new Mastermind(code);

                List<CodePeg> attemp = new List<CodePeg>() { CodePeg.White, CodePeg.Green, CodePeg.White, CodePeg.Yellow };

                // Get hints
                List<ResultPeg> list = game.GetHints(attemp);

                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
            catch (InvalidListException ex)
            {
                // Invalid or incomplete list passed to hints
                Console.WriteLine(ex.Message);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
