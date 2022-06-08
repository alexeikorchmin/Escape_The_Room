using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DoubleClick : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent OnAction;

    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private bool triggerOnDoubleClick = true;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.clickCount > 1) OnAction?.Invoke();
        else if (!triggerOnDoubleClick) OnAction?.Invoke();
    }

    public void Log(string value) => Debug.Log(value);
}