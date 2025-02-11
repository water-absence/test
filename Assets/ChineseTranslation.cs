using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.Events;
using ZombieDriveGame;

public class ChineseTranslation : MonoBehaviour
{
    public TranslationPair[] translationPairs;
    private Dictionary<string, string> translationDict;

    void Start()
    {
        InitializeTranslation();
        TranslateTexts();

        ZDGGameController gameController = FindObjectOfType<ZDGGameController>();
        if (gameController != null)
        {
            gameController.onGameOver.AddListener(TranslateTexts);
        }
        else
        {
            Debug.LogWarning("ZDGGameController not found. TranslateTexts will not be called on game over.");
        }
    }

    public void TranslateTexts()
    {
        TMP_Text[] allTexts = FindObjectsOfType<TMP_Text>();
        foreach (TMP_Text text in allTexts)
        {
            if (translationDict.ContainsKey(text.text))
            {
                text.text = translationDict[text.text];
            }
        }
    }

    private void InitializeTranslation()
    {
        translationDict = new Dictionary<string, string>();
        foreach (TranslationPair pair in translationPairs)
        {
            translationDict[pair.englishText] = pair.chineseText;
        }
    }

    private void OnDestroy()
    {
        ZDGGameController gameController = FindObjectOfType<ZDGGameController>();
        if (gameController != null)
        {
            gameController.onGameOver.RemoveListener(TranslateTexts);
        }
    }
}

[System.Serializable]
public class TranslationPair
{
    public string englishText;
    public string chineseText;
}