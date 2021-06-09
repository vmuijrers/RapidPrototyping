using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "EventChannel", menuName = "ScriptableObjects/EventChannel")]
public class EventChannel : ScriptableObject
{
    private UnityEvent OnEvent;

    public void AddListener(UnityAction action)
    {
        OnEvent.AddListener(action);
    }

    public void RemoveListener(UnityAction action)
    {
        OnEvent.RemoveListener(action);
    }

    public void RaiseEvent()
    {
        OnEvent?.Invoke();
    }
}
