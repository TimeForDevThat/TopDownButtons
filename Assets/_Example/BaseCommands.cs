using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseCommands : MonoBehaviour
{
    [Commmand]
    public void help() {
        console.Console.WriteConsole("<size=60>Все команды:</size>", Color.cyan);
        console.Console.WriteConsole("Command Example: \"Console\"\n", Color.cyan);
        List<ChatCodes> commands = console.Console.GatCommands();
        foreach (ChatCodes command in commands) {
            string temp = "<color=white>" + command.Method.Name + "(</color>";

            for (int i = 0; i < command.ParamTypes.Count; i++) {
                temp += $"</color=yellow>{command.ParamTypes[i].Name}</color>";
                if (i != command.ParamTypes.Count - 1) temp += "<color=white>, </color>";
            }
            temp += "<color=white>)</color>";
            console.Console.WriteConsole(temp, Color.black);
        }
    }

    [Commmand]
    public void clearChat() { 
        console.Console.ClearConsole();
    }

    [Commmand]
    public void version()
    {
        string temp = "<color=white>версия игры:</color>";
        temp += $"<color=blue>{UnityEditor.PlayerSettings.bundleVersion}, {UnityEditor.PlayerSettings.productName}</color>";
        console.Console.WriteConsole(temp, Color.black);
    }

    [Commmand(typeof(int))]
    public void level(int sceneInt)
    {
        SceneManager.LoadScene(sceneInt);
        Time.timeScale = 1;
    }
}
