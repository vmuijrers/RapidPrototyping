using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSubscriber : MonoBehaviour
{
    public EventChannel eventToSubscribeTo;
    public UnityEvent response;
    // Start is called before the first frame update
    void Start()
    {
        eventToSubscribeTo?.AddListener(new UnityAction(()=>response?.Invoke()));
    }

    public void RaiseEvent()
    {
        eventToSubscribeTo.RaiseEvent();
    }
    
}
