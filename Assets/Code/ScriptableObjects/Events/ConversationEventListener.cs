using UnityEngine;

public class ConversationEventListener : MonoBehaviour
{
    private ConversationEventChannel _eventChannel;
    public ConversationEvent OnEventRaised;

    private void OnEnable()
    {
        if (_eventChannel == null)
            return;
        _eventChannel.AddListener(this);
    }

    private void OnDisable()
    {
        if (_eventChannel == null)
            return;
        _eventChannel.RemoveListener(this);
    }
    
    public void RaiseEvent(Conversation conversation)
    {
        OnEventRaised?.Invoke(conversation);
    }
}