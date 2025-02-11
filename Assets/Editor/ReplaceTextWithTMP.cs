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
        ChineseTranslation translation = FindObjectOfType<ChineseTranslation>();
        if (translation == null)
        {
            translation = new GameObject("ChineseTranslation").AddComponent<ChineseTranslation>();
        }
        translation.translationPairs = GetTranslationPairs();
        translation.TranslateTexts();
    }

    private static TranslationPair[] GetTranslationPairs()
    {
        return new TranslationPair[]
        {
            new TranslationPair { englishText = "GAME OVER", chineseText = "游戏结束" },
            new TranslationPair { englishText = "SCORE", chineseText = "分数" },
            new TranslationPair { englishText = "HIGH SCORE", chineseText = "最高分" },
            new TranslationPair { englishText = "ZOMBIE DRIVE", chineseText = "僵尸驾驶员" },
            new TranslationPair { englishText = "GO", chineseText = "出发" },
            new TranslationPair { englishText = "READY", chineseText = "准备" },
            new TranslationPair { englishText = "MORE GAMES", chineseText = "更多游戏" },
        };
    }
}