using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReplaceTextWithTMP : EditorWindow
{
    [MenuItem("Tools/Replace Text with TMP")]
    public static void Replace()
    {
        Text[] allTexts = FindObjectsOfType<Text>();
        foreach (Text text in allTexts)
        {
            GameObject go = text.gameObject;
            string textContent = text.text;
            DestroyImmediate(text);

            TMP_Text tmpText = go.AddComponent<TMP_Text>();
            tmpText.text = textContent;
        }
    }
}