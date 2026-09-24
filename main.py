import sys 
import init 


if __name__ == '__main__':
    if len(sys.argv) < 2:
        exit("The command you have entered is not a valid option. Use cvc help to use all supported operation")
    command = sys.argv[1]
    match command:
        case "init":
            init.init()
        case "help":
            print("cvc stand for  context version control,used to track and manage the context of LLM by talking snapshots of the conversation and directing the LLM to the context\n")
            print("the supported commands are:\n")
            print("cvc init: initializes cvc in the current directory.\n")
            print("cvc help: displays how commands are typed\n")
            print("cvc establish:establishes the connection to the desired llm\n")
            print("cvc get-context: creates a snashot of the conversation\n")
            print("cvc branch: creates a new brach to avoid context poisoning\n")
            print("cvc merge: used to merge different branch\n")
            print("cvc conflict-resolver: resolves any conflicts of different branching that are ready for merging\nPreffered befor entering merging")
        case _:
            print("Either functinality not implemented or not a valid option.See cvc help")
