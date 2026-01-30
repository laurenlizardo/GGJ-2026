using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New VoidEventChannel", menuName = "ScriptableObjects/Void Event Channel")]
public class VoidEventChannel : ScriptableObject
{
    private List<VoidEventListener> _listeners = new List<VoidEventListener>();

    public void AddListener(VoidEventListener listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }

    public void RemoveListener(VoidEventListener listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }

    public void Raise()
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
            _listeners[i].RaiseEvent();
    }
}