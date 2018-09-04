using System;
using HandHistories.Objects.Hand;
using HandHistories.Parser.Parsers.Base;
using HandHistories.Parser.Parsers.Factory;

namespace ParserHands
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IHandHistoryParserFactory handHistoryParserFactory = new HandHistoryParserFactoryImpl();

            // Get the correct parser from the factory.
            IHandHistoryParser handHistoryParser = handHistoryParserFactory.GetFullHandHistoryParser(HandHistories.Objects.GameDescription.SiteName.PokerStars);

            var  handText = System.IO.File.ReadAllText("input.txt"); 

            try
            {
                // The true causes hand-parse errors to get thrown. If this is false, hand-errors will
                // be silent and null will be returned.
                HandHistory handHistory = handHistoryParser.ParseFullHandHistory(handText, true);

            }
            catch (Exception ex) // Catch hand-parsing exceptions
            {
                Console.WriteLine("Parsing Error: {0}", ex.Message); // Example logging.
            }
        }
    }
}
