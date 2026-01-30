using UnityEngine;

public class VoidEventListener : MonoBehaviour
{
    private VoidEventChannel _eventChannel;
    public VoidEvent OnEventRaised;

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
    
    public void RaiseEvent()
    {
        OnEventRaised?.Invoke();
    }
}
