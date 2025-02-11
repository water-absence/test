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
            new TranslationPair { englishText = "GAME OVER", chineseText = "��Ϸ����" },
            new TranslationPair { englishText = "SCORE", chineseText = "����" },
            new TranslationPair { englishText = "HIGH SCORE", chineseText = "��߷�" },
            new TranslationPair { englishText = "ZOMBIE DRIVE", chineseText = "��ʬ��ʻԱ" },
            new TranslationPair { englishText = "GO", chineseText = "����" },
            new TranslationPair { englishText = "READY", chineseText = "׼��" },
            new TranslationPair { englishText = "MORE GAMES", chineseText = "������Ϸ" },
        };
    }
}