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

            public string Display(string who, string message)
            {
                switch (who)
                {
                    case "Tinky Winky":
                        return DisplayTinkyWinky(message);

                    case "Dipsy":
                        return DisplayDispy(message);

                    case "Laa Laa":
                        return DisplayLaaLaa(message);

                    case "Po":
                        return DisplayPo(message);

                    default:
                        Console.WriteLine("I don't know who " + who + " is!");
                        return "";
                }
            }

            public string DisplayLaaLaa(string message)
            {
                message = message.PadRight(20);
                return $@"
            |\     
           |'_\    
          _| |_    
        .`_____`.     ___________________ 
      |\ /     \ /| |                     |
      |||  9 9  |||< {message} |
      \_\   -   /_/ |                     |
       .-'-----'-.   \____________________/
      (_   ___   _)
        | |___| |  
        |       |  
        (___|___)  ";
            }
            public string DisplayPo(string message)
            {
                message = message.PadRight(20);
                return $@"
            ___     
           ( o )    
           _| |_    
         .`_____`.      ___________________ 
       |\ /     \ /|  |                     |
       |||  @ @  ||| < {message} |
       \_\   =   /_/  |                     |
        .-'-----'-.   \_____________________/
       (_   ___   _)
         | |___| |  
         |       |  
         (___|___)";
            }

            public string DisplayTinkyWinky(string message)
            {
                message = message.PadRight(20);
                return $@"
         .---.    
         \ V /    
         _| |_    
       .`_____`.    ___________________ 
     |\ /     \ /| |                     |
     |||  6 6  |||< {message} |
     \_\   o   /_/ |                     |
      .-'-----'-.   \___________________ /
     (_   ___   _)
       | |___| |  
       |       |  
       (___|___)  ";
            }
            public string DisplayDispy(string message)
            {
                message = message.PadRight(20);
                return $@"
           _
          | |
         _| |_
       .`_____`.    ___________________ 
     |\ /     \ /| |                     |
     |||  o o  |||< {message} |
     \_\  ._.  /_/ |                     |
      .-'-----'-.   \___________________ /
     (_   ___   _)
       | |___| |
       |       |
       (___|___)";
            }
        }
    }
}
