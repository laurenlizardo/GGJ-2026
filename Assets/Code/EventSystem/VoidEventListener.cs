using UnityEngine;

namespace LaurenLizardo.ToTheMasquerade.EventSystem
{
    public class VoidEventListener : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel _eventChannel;
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
}