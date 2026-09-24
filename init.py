import os

folder = ".cvc"
agents_file = "AGENTS.MD"
file_name = ".env"
## init function creates a 
def init():
    try: 
        os.mkdir(folder)
        path = os.getcwd()
        full_path = os.path.join(path,folder)
        agent_path = os.path.join(full_path,agents_file)
        file_path = os.path.join(full_path,file_name)
        '''
        The reason for creating  agents.md in the .cvc folder is mainly a seperation of concern for AI agents from the root directory as a coding agent and  in the .cvc 
        folder to see which snapshots can be used for next question
        '''
        with open(agent_path,"w") as f:
            f.write("// This file defines the behaviour of agents on what folders or what files it has access to and the rules it need to follow while they are accessing the snapshots ")
        with open(file_path,"w") as f:
            f.write("AI_MODEL=\n")
            f.write("API_KEY=\n")
            f.write("SECRET_API_KEY=\n")
        print(f"initialized in the {path}")
    except FileExistsError:
        print("already initialized  in the current directory")
    except Exception as e:
        print(f"Error:{e}")
