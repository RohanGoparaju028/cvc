// Program.cs is the main entry file for cvc 
using System;

namespace cvc;

public class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("cvc requires 1 parameter. See cvc help to check all available commands");
            return;
        }
        string command = args[0];
        switch (command)
        {
            case "help":
                Console.WriteLine("cvc stands for context version control.The main purpose of this tool is to version control the context that AI agents use to solve specific task in a codebase thus improving the reproduceablity between AI agents and maybe a reduction in Token Consumption");
                break;
            case "init":
                new Init();
                break;
            case "establish":
                new Establish();
                break;
            default:
                Console.WriteLine("command is not valid or under construction");
                break;
        }
    }
}
