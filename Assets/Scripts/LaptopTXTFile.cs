using UnityEngine;

public class LaptopTXTFile : MonoBehaviour
{
    [SerializeField] private GameObject inputField;

    public void ClickOnTxtFile()
    {
        inputField.SetActive(true);
    }

    public void CloseTxtFile()
    {
        inputField.SetActive(false);
    }
}