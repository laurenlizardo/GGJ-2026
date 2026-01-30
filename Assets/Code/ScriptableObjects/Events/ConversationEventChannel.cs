using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New ConversationEventChannel", menuName = "ScriptableObjects/Conversation Event Channel")]
public class ConversationEventChannel : ScriptableObject
{
    private List<ConversationEventListener> _listeners = new List<ConversationEventListener>();

    public void AddListener(ConversationEventListener listener)
    {
        if (!_listeners.Contains(listener))
            _listeners.Add(listener);
    }

    public void RemoveListener(ConversationEventListener listener)
    {
        if (_listeners.Contains(listener))
            _listeners.Remove(listener);
    }

    public void Raise(Conversation conversation)
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
            _listeners[i].RaiseEvent(conversation);
    }
}