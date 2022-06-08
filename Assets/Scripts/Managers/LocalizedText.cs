using TMPro;
using UnityEngine;

public class LocalizedText : MonoBehaviour
{
    [SerializeField] private string key;

    private LocalizationManager localizationManager;
    private TMP_Text text;

    private void Awake()
    {
        CheckIsLocalizationManagerAndTextNull();

        localizationManager.OnLanguageChanged += UpdateText;
    }

    private void Start()
    {
        UpdateText();
    }

    protected virtual void UpdateText()
    {
        if (gameObject == null) return;

        CheckIsLocalizationManagerAndTextNull();

        text.text = localizationManager.GetLocalizedValue(key);
    }

    private void CheckIsLocalizationManagerAndTextNull()
    {
        if (localizationManager == null)
        {
            localizationManager = GameObject.FindGameObjectWithTag("LocalizationManager").GetComponent<LocalizationManager>();
        }

        if (text == null)
        {
            text = GetComponent<TMP_Text>();
        }
    }

    private void OnDestroy()
    {
        localizationManager.OnLanguageChanged -= UpdateText;
    }
}