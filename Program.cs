// Main entry point for managing all commands 
using cvc.init;
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
                System.Console.WriteLine("cvc init is the first command that you want to use in an uninitialized repository/directory. It generates a .cvc folder that includes agent.yaml file for configuration,.env file for agent api for model building and interctions and finally configurable AGENTS.md to define the behavior of AI agents inide the .cvc folder ");
                break;

            case "init":
		Init.Initialize();
                break;
            default:
                System.Console.WriteLine($"cvc <<{command}>> is either under construction or donot supported");
                break;
        }
    }
}
