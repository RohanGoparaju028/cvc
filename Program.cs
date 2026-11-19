// Main entry point for managing all commands 
using cvc.init;
using cvc.establish;
namespace cvc;

public class Program
{

    static void Main(string[] args)
    {
        if (args.Count() == 0 || args.Count() > 1)
        {
            System.Console.Write("cvc exactly take 1 parameter\n");
            return;
        }
        var command = args[0];
        switch (command)
        {
            case "help":
                System.Console.WriteLine("cvc stands for context version control. The main purpose of cvc is to track the ever changing context,design patterns and decisions that are set in the current ai agent conversation to ensure modularity and determinism when different AI models are used by same/different user ");
                System.Console.WriteLine("cvc init creates .cvc/agent.yaml for configuration and .cvc/AGENTS.md for agent instructions.");
                break;

            case "init":
                Init.Initialize(); // This function creates initialzes cvc in the current working directory
                break;
            case "establish":
                System.Console.WriteLine("cvc currently establishing a connection to your LLM model");
                var _ = Establish.Connection();
                break;
            default:
                System.Console.WriteLine($"cvc <<{command}>> is either under construction or donot supported");
                break;
        }
    }
}
