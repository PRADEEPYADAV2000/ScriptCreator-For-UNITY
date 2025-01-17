using UnityEditor;
using UnityEngine;
using System.IO;

public class JSONFileCreator : EditorWindow
{
    private string fileName = "NewFile";

    [MenuItem("Tools/Create JSON File")]
    public static void ShowWindow()
    {
        GetWindow<JSONFileCreator>("Create JSON File");
    }

    private void OnGUI()
    {
        GUILayout.Label("Create a New JSON File", EditorStyles.boldLabel);

        fileName = EditorGUILayout.TextField("File Name", fileName);

        if (GUILayout.Button("Create JSON File"))
        {
            CreateJSONFile();
        }
    }

    private void CreateJSONFile()
    {
        string folderPath = Application.dataPath + "/GeneratedJSON";

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string filePath = Path.Combine(folderPath, fileName + ".json");

        if (File.Exists(filePath))
        {
            Debug.LogWarning("File already exists! Choose a different name.");
            return;
        }

        File.WriteAllText(filePath, "{}"); // Creates an empty JSON file with "{}"
        Debug.Log($"JSON file created at: {filePath}");
        AssetDatabase.Refresh();
    }
}
