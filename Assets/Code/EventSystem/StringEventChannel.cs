using UnityEngine;
using System.Collections.Generic;

namespace LaurenLizardo.ToTheMasquerade.EventSystem
{
    [CreateAssetMenu(fileName = "New StringEventChannel", menuName = "ScriptableObjects/String Event Channel")]
    public class StringEventChannel : ScriptableObject
    {
        private List<StringEventListener> _listeners = new List<StringEventListener>();
    
        public void AddListener(StringEventListener listener)
        {
            if (!_listeners.Contains(listener))
                _listeners.Add(listener);
        }
    
        public void RemoveListener(StringEventListener listener)
        {
            if (_listeners.Contains(listener))
                _listeners.Remove(listener);
        }
    
        public void Raise(string str)
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
                _listeners[i].RaiseEvent(str);
        }
    }
}