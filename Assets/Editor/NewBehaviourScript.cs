using UnityEngine;
using System.IO;

public class ProjectStructurePrinter : MonoBehaviour
{
    void Start()
    {
        string projectPath = Application.dataPath;
        string[] allFiles = Directory.GetFiles(projectPath, "*", SearchOption.AllDirectories);
        string[] allFolders = Directory.GetDirectories(projectPath, "*", SearchOption.AllDirectories);

        Debug.Log("Project File Structure:");
        foreach (string folder in allFolders)
        {
            string relativePath = folder.Replace(projectPath, "Assets");
            Debug.Log("Folder: " + relativePath);
        }

        foreach (string file in allFiles)
        {
            string relativePath = file.Replace(projectPath, "Assets");
            Debug.Log("File: " + relativePath);
        }
    }
}