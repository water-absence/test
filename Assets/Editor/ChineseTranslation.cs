using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ChineseTranslation : MonoBehaviour
{
    public TranslationPair[] translationPairs;
    private Dictionary<string, string> translationDict;

    void Start()
    {
        // ³õÊ¼»¯×Öµä
        translationDict = new Dictionary<string, string>();
        foreach (TranslationPair pair in translationPairs)
        {
            translationDict[pair.englishText] = pair.chineseText;
        }

        TMP_Text[] allTexts = FindObjectsOfType<TMP_Text>();
        foreach (TMP_Text text in allTexts)
        {
            if (translationDict.ContainsKey(text.text))
            {
                text.text = translationDict[text.text];
            }
        }
    }
}

[System.Serializable]
public class TranslationPair
{
    public string englishText;
    public string chineseText;
}