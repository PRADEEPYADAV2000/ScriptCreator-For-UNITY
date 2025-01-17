using UnityEditor;
using UnityEngine;
using System.IO;

public class ScriptCreator : EditorWindow
{
    private string scriptName = "NewScript";

    [MenuItem("Tools/Script Creator")]
    public static void ShowWindow()
    {
        GetWindow<ScriptCreator>("Script Creator");
    }

    void OnGUI()
    {
        GUILayout.Label("Create a New C# Script", EditorStyles.boldLabel);
        scriptName = EditorGUILayout.TextField("Script Name", scriptName);

        if (GUILayout.Button("Create Script"))
        {
            CreateNewScript(scriptName);
        }
    }

    private void CreateNewScript(string scriptName)
    {
        // Create the path to the Assets folder
        string path = Application.dataPath + "/" + scriptName + ".cs";

        if (File.Exists(path))
        {
            Debug.LogError("A script with this name already exists!");
            return;
        }

        using (StreamWriter writer = new StreamWriter(path))
        {
            writer.WriteLine("using UnityEngine;");
            writer.WriteLine("");
            writer.WriteLine("public class " + scriptName + " : MonoBehaviour");
            writer.WriteLine("{");
            writer.WriteLine("    void Start()");
            writer.WriteLine("    {");
            writer.WriteLine("        // Start is called before the first frame update");
            writer.WriteLine("    }");
            writer.WriteLine("");
            writer.WriteLine("    void Update()");
            writer.WriteLine("    {");
            writer.WriteLine("        // Update is called once per frame");
            writer.WriteLine("    }");
            writer.WriteLine("}");
        }

        AssetDatabase.Refresh();
        Debug.Log("Script created successfully at: " + path);
    }
}
