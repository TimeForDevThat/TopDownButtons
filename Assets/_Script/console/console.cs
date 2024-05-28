using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class console : MonoBehaviour
{
    [SerializeField] TMP_Text ConsoleText;
    [SerializeField] TMP_Text ContentText;
    [SerializeField] TMP_InputField InputField;
    [SerializeField] Button SendButton;

    [SerializeField] GameObject PanelHelp;
    [SerializeField] TMP_Text HelpText;

    private List<ChatCodes> commands = new List<ChatCodes>();
    private List<GameObject> HelpPanelChatCommands = new List<GameObject>();

    private ConsoleInput consoleInput;

    public static console Console;

    private void OnDisable()
    {
        InputField.text = String.Empty;
        PanelHelp.SetActive(false);
        ClearConsole();
    }

    private void Awake()
    {
        Console = this;
        consoleInput = new ConsoleInput();
        consoleInput.Console.Enable();

        FindCommands();
        AddListerners();
    }

    private void HelpAppend() {
        InputField.text = ContentText.text;
        InputField.MoveTextEnd(false);
    }

    private void AddListerners()
    {
        consoleInput.Console.AppendText.performed += e => HelpAppend();
        consoleInput.Console.EnterText.performed += e => {
            SendButton?.onClick.Invoke();
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
        };

        SendButton.onClick.AddListener(Send);
        InputField.onValueChanged.AddListener(InputValueChanged);
        InputField.onSelect.AddListener(e =>
        {
            InputField.text = String.Empty;
            PanelHelp.SetActive(true);
            InputValueChanged(string.Empty);
        });

        InputField.onDeselect.AddListener(e =>
        {
            PanelHelp.SetActive(false);
            HelpText.text = string.Empty;
        });
    }

    private void FindCommands()
    {
        var MonoBehaviours = FindObjectsOfType<MonoBehaviour>();

        foreach (var MonoBehaviour in MonoBehaviours)
        {
            var methods = MonoBehaviour.GetType()
                .GetMethods()
                .Where(method => Attribute.IsDefined(method, typeof(CommmandAttribute)));

            foreach (var method in methods)
            {
                var attribute = (CommmandAttribute)Attribute.GetCustomAttribute(method, typeof(CommmandAttribute));
                commands.Add(new ChatCodes(MonoBehaviour, method, attribute.ParamsTypes));
            }
        }
    }

    private object[] GatParameters(List<Type> Types, List<String> Strings)
    {
        object[] Parameters = new object[Types.Count];

        if (Types.Count != Strings.Count)
        {
            WriteConsole($"неверная команда: {Types.Count}", Color.red);
            return null;
        }
        else
        {
            for (int i = 0; i < Types.Count; i++)
            {
                try
                {
                    if (Types[i] == typeof(string)) Parameters[i] = Strings[i];
                    else if (Strings[i] == "null") Parameters[i] = null;
                    else if (Types[i] == typeof(int)) Parameters[i] = int.Parse(Strings[i]);
                    else if (Types[i] == typeof(float)) Parameters[i] = float.Parse(Strings[i]);
                    else if (Types[i] == typeof(double)) Parameters[i] = float.Parse(Strings[i]);
                    else if (Types[i] == typeof(GameObject)) Parameters[i] = Resources.Load($"Prefabs/{Strings[i]}") as GameObject;
                    else if (Types[i] == typeof(Transform)) Parameters[i] = GameObject.Find(Strings[i]).transform;
                }
                catch
                {
                    WriteConsole($"неверная команда", Color.red);
                    return null;
                }
            }
            return Parameters;
        }
    }

    private void Send() => Send(InputField.text);

    private void Send(string Text) {
        List<string> Strings = new();
        Strings.AddRange(Text.Split(' '));
        InputField.text = String.Empty;

        IEnumerable<ChatCodes> SendCommands = commands.OfType<ChatCodes>().Where(i => i.Method.Name == Strings[0]);
        if (SendCommands.Count() == 0) {
            WriteConsole($"Команда не найдена", Color.red);
            return;
        }
        List<string> tempList = new();
        tempList.AddRange(Strings.Skip(1));
        object[] param = GatParameters(SendCommands.First().ParamTypes, tempList);
        if (param == null) {
            return;
        }
        SendCommands.First().Method.Invoke(SendCommands.First().Target, param);
    }

    private void InputValueChanged(string value) {
        for (int i = 0; i < HelpPanelChatCommands.Count; i++) {
            Destroy(HelpPanelChatCommands[i]);
        }
        HelpPanelChatCommands.Clear();

        List<ChatCodes> SendCommands = new();
        SendCommands.AddRange(commands.OfType<ChatCodes>().Where(i => i.Method.Name.StartsWith(value)));

        for (int i = 0; i < SendCommands.Count; i++) {
            TMP_Text TempText = Instantiate(HelpText, PanelHelp.transform).GetComponent<TMP_Text>();
            HelpPanelChatCommands.Add(TempText.gameObject);
            TempText.text = SendCommands[i].Method.Name;
        }

        if (SendCommands.Count == 0 || string.IsNullOrEmpty(InputField.text)) {
            ContentText.text = String.Empty;
            return;
        }
        ContentText.text = SendCommands.First().Method.Name;
    }

    public void WriteConsole(string Text) {
        ConsoleText.text += $"\n{Text}";
    }

    public void WriteConsole(string Text, Color color)
    {
        ConsoleText.text += $"\n<color=#{color.ToHexString()}>{Text}</color>";
    }

    public List<ChatCodes> GatCommands() {
        List<ChatCodes> temp = new();
        temp.AddRange(commands.ToArray());
        return temp;
    }

    public void ClearConsole() { 
        ConsoleText.text = string.Empty;
    }
}

[Serializable]
public struct ChatCodes
{
    public ChatCodes(object _Target, MethodInfo _Method, List<Type> _ParamTypes) { 
        Target = _Target;
        Method = _Method;
        ParamTypes = _ParamTypes;
    }
    public object Target;
    public MethodInfo Method;
    public List<Type> ParamTypes;
}
