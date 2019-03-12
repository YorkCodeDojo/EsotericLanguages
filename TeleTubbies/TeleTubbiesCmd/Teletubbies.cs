using System;
namespace TeletubbiesCmd
{
    partial class Program
    {
        class Teletubbies
        {
            public string TinkyWinky { get; set; }
            public string Dipsy { get; set; }
            public string LaaLaa { get; set; }
            public string Po { get; set; }

            public void Set(string who, string what)
            {
                switch (who)
                {
                    case "Tinky Winky":
                        TinkyWinky = what;
                        break;

                    case "Dipsy":
                        Dipsy = what;
                        break;

                    case "Laa Laa":
                        LaaLaa = what;
                        break;

                    case "Po":
                        Po = what;
                        break;

                    default:
                        Console.WriteLine("I don't know who " + who + " is!");
                        break;
                }
            }

            public string Read(string who)
            {
                switch (who)
                {
                    case "Tinky Winky":
                        return TinkyWinky;

                    case "Dipsy":
                        return Dipsy;

                    case "Laa Laa":
                        return LaaLaa;

                    case "Po":
                        return Po;

                    default:
                        Console.WriteLine("I don't know who " + who + " is!");
                        return "";
                }
            }
        }
    }
}
