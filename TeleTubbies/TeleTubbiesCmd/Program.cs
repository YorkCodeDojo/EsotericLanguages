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

        static void Main(string[] args)
        {
            var teletubbies = new Teletubbies();


            var command = "";
            while (command != "byebye")
            {
                Console.WriteLine();
                Console.Write(">");
                command = Console.ReadLine();

                var ok = false;
                ok = ok || IsCommand(teletubbies,  command);
                ok = ok || AskCommand(teletubbies,  command);
                ok = ok || WhispersCommand(teletubbies,  command);
                ok = ok || YellsCommand(teletubbies,  command);
                ok = ok || SpeaksCommand(teletubbies,  command);
                ok = ok || TellCommand(teletubbies,  command);

                if (!ok)
                {
                    Console.WriteLine("Tinky Winky, Dipsy, Laa Laa and Po don't understand you!");
                }
            }
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
