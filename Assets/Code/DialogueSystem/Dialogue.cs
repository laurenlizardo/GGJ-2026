using System.Collections.Generic;
using UnityEngine;
using LaurenLizardo.ToTheMasquerade.EventSystem;

namespace LaurenLizardo.ToTheMasquerade.DialogueSystem
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/Dialogue")]
    public class Dialogue : ScriptableObject
    {
        [SerializeField] private string _name;
        public string Name => _name;
        
        [SerializeField] private string _line;
        public string Line => _line;
    
        public List<VoidEventChannel> VoidEventChannels = new List<VoidEventChannel>();
    }
}