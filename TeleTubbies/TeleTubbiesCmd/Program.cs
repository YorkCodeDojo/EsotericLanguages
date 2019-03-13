using System;
using System.Text.RegularExpressions;
namespace TeletubbiesCmd
{
    partial class Program
    {
        private static readonly Regex regexIs = new Regex("^(?<who>(Tinky Winky)|(Dipsy)|(Laa Laa)|(Po)) is (?<what>.+)$");
        private static readonly Regex regexAsk = new Regex("^Ask (?<who>(Tinky Winky)|(Dipsy)|(Laa Laa)|(Po))$");
        private static readonly Regex regexWhispers = new Regex("^(?<who>(Tinky Winky)|(Dipsy)|(Laa Laa)|(Po)) whispers to (?<who2>(Tinky Winky)|(Dipsy)|(Laa Laa)|(Po))$");
        private static readonly Regex regexYells = new Regex("^(?<who>(Tinky Winky)|(Dipsy)|(Laa Laa)|(Po)) yells to (?<who2>(Tinky Winky)|(Dipsy)|(Laa Laa)|(Po))$");
        private static readonly Regex regexSpeaks = new Regex("^(?<who>(Tinky Winky)|(Dipsy)|(Laa Laa)|(Po)) speaks to (?<who2>(Tinky Winky)|(Dipsy)|(Laa Laa)|(Po))$");
        private static readonly Regex regexTell = new Regex("^Tell (?<who>(Tinky Winky)|(Dipsy)|(Laa Laa)|(Po)) (?<question>.+)$");
        private static readonly Regex regexRob = new Regex("^(?<robber>(Tinky Winky)|(Dipsy)|(Laa Laa)|(Po)) robs (?<victim>(Tinky Winky)|(Dipsy)|(Laa Laa)|(Po))$");
        private static readonly Regex regexVote = new Regex("^Vote on (?<question>.+)$");

        /*
         * Po = Yes
         * Laa Laa = No
         * Tinky Winky = Yes
         * Dipsy = No
         * 
         * Vote on brexit
         *      Undecided (if number of yes == no)
         *      Yes (yes > no)
         *      No (no > yes)
         */



        static void Main(string[] args)
        {
            var teletubbies = new Teletubbies();

            var rnd = new Random();
            var command = "";
            while (command != "byebye")
            {
                Console.WriteLine();
                Console.Write(">");
                command = Console.ReadLine();

                var ok = false;
                ok = ok || IsCommand(teletubbies, command);
                ok = ok || AskCommand(teletubbies, command);
                ok = ok || WhispersCommand(teletubbies, command);
                ok = ok || YellsCommand(teletubbies, command);
                ok = ok || SpeaksCommand(teletubbies, command);
                ok = ok || TellCommand(teletubbies, command);
                ok = ok || RobsCommand(teletubbies, command);
                ok = ok || VoteCommand(teletubbies, command);
                ok = ok || CallElectionCommand(teletubbies, command);

                if (rnd.Next(0, 5) == 0)
                    Quote();

                if (!ok)
                {
                    Console.WriteLine("Tinky Winky, Dipsy, Laa Laa and Po don't understand you!");
                }
            }
        }

        private static void Quote()
        {
            var rnd = new Random();
            var quotes = new string[] 
            {
                "Big Hug!",
                "Time for Tubby bye-bye! Time for Tubby bye-bye!",
                "Teletubbies love each other very much.",
                "Over the hills and far away, Teletubbies come to play."
            };
            var quote = quotes[rnd.Next(quotes.Length)];
            Console.WriteLine(quote);
        }

        private static bool CallElectionCommand(Teletubbies teletubbies, string command)
        {
            var matched = (command == "Call Election");
            if (matched)
            {
                var rnd = new Random();
                var person = rnd.Next(4);

                switch (person)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Dipsy is now the leader");
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Laa Laa is now the leader");
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Tinky Winky is now the leader");
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Po is now the leader");
                        break;
                }
            }

            return matched;
        }
        private static bool VoteCommand(Teletubbies teletubbies, string command)
        {
            var match = regexVote.Match(command);
            if (match.Success)
            {
                var question = match.Groups["question"].Value;

                var numberOfNos = 0;
                numberOfNos = numberOfNos + (teletubbies.Read("Dipsy") == "No" ? 1 : 0);
                numberOfNos = numberOfNos + (teletubbies.Read("Tinky Winky") == "No" ? 1 : 0);
                numberOfNos = numberOfNos + (teletubbies.Read("Laa Laa") == "No" ? 1 : 0);
                numberOfNos = numberOfNos + (teletubbies.Read("Po") == "No" ? 1 : 0);

                var numberOfYes = 0;
                numberOfYes = numberOfYes + (teletubbies.Read("Dipsy") == "Yes" ? 1 : 0);
                numberOfYes = numberOfYes + (teletubbies.Read("Tinky Winky") == "Yes" ? 1 : 0);
                numberOfYes = numberOfYes + (teletubbies.Read("Laa Laa") == "Yes" ? 1 : 0);
                numberOfYes = numberOfYes + (teletubbies.Read("Po") == "Yes" ? 1 : 0);

                if (numberOfNos == numberOfYes)
                    Console.WriteLine($"The vote on {question} was undecided.");

                if (numberOfNos > numberOfYes)
                    Console.WriteLine($"They voted against {question}.");

                if (numberOfNos < numberOfYes)
                    Console.WriteLine($"They voted for {question}.");
            }

            return match.Success;
        }
        private static bool RobsCommand(Teletubbies teletubbies, string command)
        {
            var match = regexRob.Match(command);
            if (match.Success)
            {
                var robber = match.Groups["robber"].Value;
                var victim = match.Groups["victim"].Value;

                var currentValueFromVictim = teletubbies.Read(victim);
                var currentValueFromRobber = teletubbies.Read(robber);

                teletubbies.Set(robber, currentValueFromRobber + currentValueFromVictim);
                teletubbies.Set(victim, "");

            }

            return match.Success;
        }
        private static bool TellCommand(Teletubbies teletubbies, string command)
        {
            var match = regexTell.Match(command);
            if (match.Success)
            {
                var who = match.Groups["who"].Value;
                var question = match.Groups["question"].Value;
                Console.Write($"{who} asks what is {question}? ");
                teletubbies.Set(who, Console.ReadLine());
            }

            return match.Success;
        }
        private static bool WhispersCommand(Teletubbies teletubbies, string command)
        {
            var match = regexWhispers.Match(command);
            if (match.Success)
            {
                var who = match.Groups["who"].Value;
                var who2 = match.Groups["who2"].Value;
                var what = teletubbies.Read(who);
                teletubbies.Set(who2, what.ToLower());
            }

            return match.Success;
        }

        private static bool YellsCommand(Teletubbies teletubbies, string command)
        {
            var match = regexYells.Match(command);
            if (match.Success)
            {
                var who = match.Groups["who"].Value;
                var who2 = match.Groups["who2"].Value;
                var what = teletubbies.Read(who);
                teletubbies.Set(who2, what.ToUpper());
            }

            return match.Success;
        }

        private static bool SpeaksCommand(Teletubbies teletubbies, string command)
        {
            var match = regexSpeaks.Match(command);
            if (match.Success)
            {
                var who = match.Groups["who"].Value;
                var who2 = match.Groups["who2"].Value;
                var what = teletubbies.Read(who);
                teletubbies.Set(who2, what);
            }

            return match.Success;
        }
        private static bool IsCommand(Teletubbies teletubbies, string command)
        {
            var match = regexIs.Match(command);
            if (match.Success)
            {
                teletubbies.Set(match.Groups["who"].Value, match.Groups["what"].Value);
            }

            return match.Success;
        }

        private static bool AskCommand(Teletubbies teletubbies, string command)
        {
            var match = regexAsk.Match(command);
            if (match.Success)
            {
                var who = match.Groups["who"].Value;
                var what = teletubbies.Read(who);
                Console.WriteLine($"{who} says {what}");
            }

            return match.Success;
        }
    }
}
