using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public delegate void ChangeLangText();
    public event ChangeLangText OnLanguageChanged;

    private string currentLanguage;
    private Dictionary<string, string> localizedText;
    private static bool isReady = false;

    public string CurrentLanguage
    {
        get
        {
            return currentLanguage;
        }

        set
        {
            PlayerPrefs.SetString("Language", value);
            currentLanguage = PlayerPrefs.GetString("Language");
        }
    }

    public bool IsReady
    {
        get
        {
            return isReady;
        }
    }

    public void LoadLocalizedText(string langName)
    {
        string path = Application.streamingAssetsPath + "/Languages/" + langName + ".json";

        string dataAsJson = File.ReadAllText(path);

        LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

        localizedText = new Dictionary<string, string>();

        for (int i = 0; i < loadedData.items.Length; i++)
        {
            localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
        }

        PlayerPrefs.SetString("Language", langName);
        currentLanguage = PlayerPrefs.GetString("Language");
        isReady = true;

        OnLanguageChanged?.Invoke();
    }

    public string GetLocalizedValue(string key)
    {
        if (localizedText.ContainsKey(key))
        {
            return localizedText[key];
        }
        else
        {
            throw new Exception("Localized text with key \"" + key + "\" not found");
        }
    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Language"))
        {
            if (Application.systemLanguage == SystemLanguage.Russian)
            {
                PlayerPrefs.SetString("Language", "ru_RU");
            }
            else
            {
                PlayerPrefs.SetString("Language", "en_US");
            }
        }

        currentLanguage = PlayerPrefs.GetString("Language");
        LoadLocalizedText(currentLanguage);
    }
}