using UnityEngine;

namespace LaurenLizardo.ToTheMasquerade.EventSystem
{
    public class StringEventListener : MonoBehaviour
    {
        private StringEventChannel _eventChannel;
        public StringEvent OnEventRaised;
    
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
        
        public void RaiseEvent(string str)
        {
            OnEventRaised?.Invoke(str);
        }
    }
}